using aspdotnetcore3_datatable.Data;
using aspdotnetcore3_datatable.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace aspdotnetcore3_datatable.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly aspdotnetcore3_datatableContext _context;


        public CategoryApiController(aspdotnetcore3_datatableContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult getAllCategory()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["lemgth"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][colum]"].FirstOrDefault() +
                    "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 10;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var categoryDara = (from temcustomer in _context.Category select temcustomer);
                if (!string.IsNullOrEmpty(searchValue))
                {
                    categoryDara = categoryDara.Where(m => m.Name.Contains(searchValue));
                }
                recordsTotal = categoryDara.Count();
                var data = categoryDara.Skip(skip).Take(pageSize).ToList();


                var jsonData = new
                {
                    draw = draw,
                    recordsTotal = recordsTotal,
                    recordsFiltered = recordsTotal,
                    data = data
                };
                return Ok(jsonData);

            } catch (Exception e)
            {

            }
            return null;
        }
        //api/categoryApi/1

        [HttpGet("{id}")]
        public IActionResult getCategory()
        {
            return null;
        }
        //api/categoryApi/Create

        [HttpPost("create")]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        { MessageReturn mr = new MessageReturn();
            try
            {
                _context.Category.Add(category);
                await _context.SaveChangesAsync();

                mr.Code = "Ok";
                mr.Message = "Success";
            } catch (Exception e)
            {
                mr.Code = "FAIL";
                mr.Message = e.Message;
            }


            return CreatedAtAction("GetCatagory", new { id = category.Id }, mr);
        }
        //api/categoryApi/delete/1
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteCatagory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //api/categoryApi/edit
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        [HttpPost("update/{id}")]
        public async Task<ActionResult<MessageReturn>> PutCatagory(int id, Category category)
        {
            MessageReturn mr = new MessageReturn();
            _context.Entry(category).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                mr.Code = "Ok";
                mr.Message = "Success";
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                mr.Code = "FAIL";
                mr.Message = "FAIL";
            }
            return mr;
        }

    }
}



