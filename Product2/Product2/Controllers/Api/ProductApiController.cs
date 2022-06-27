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
    public class ProductApiController : ControllerBase
    {
        private readonly aspdotnetcore3_datatableContext _context;


        public ProductApiController(aspdotnetcore3_datatableContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult getAllProduct()
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

                var productDara = (from temcustomer in _context.Product select temcustomer);
                if (!string.IsNullOrEmpty(searchValue))
                {
                    productDara = productDara.Where(m => m.Name.Contains(searchValue));
                }
                recordsTotal = productDara.Count();
                var data = productDara.Skip(skip).Take(pageSize).ToList();


                var jsonData = new
                {
                    draw = draw,
                    recordsTotal = recordsTotal,
                    recordsFiltered = recordsTotal,
                    data = data
                };
                return Ok(jsonData);

            }
            catch (Exception e)
            {

            }
            return null;
        }
        //api/product/1

        [HttpGet("{id}")]
        public IActionResult getProduct()
        {
            return null;
        }
        //api/productApi/Create

        [HttpPost("create")]
        public async Task<ActionResult<Product>> PostCategory(Product product)
        {
            MessageReturn mr = new MessageReturn();
            try
            {
                _context.Product.Add(product);
                await _context.SaveChangesAsync();

                mr.Code = "Ok";
                mr.Message = "Success";
            }
            catch (Exception e)
            {
                mr.Code = "FAIL";
                mr.Message = e.Message;
            }


            return CreatedAtAction("GetProduct", new { id = product.Id }, mr);
        }
        //api/ProductApi/delete/1
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteCatagory(int id)
        {
            var product = await _context.Category.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Category.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //api/productApi/edit
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetCategory(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost("update/{id}")]
        public async Task<ActionResult<MessageReturn>> PutProduct(int id, Product product)
        {
            MessageReturn mr = new MessageReturn();
            _context.Entry(product).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
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



