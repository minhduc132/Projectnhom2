using Microsoft.AspNetCore.Http;

namespace EmailTest.Models
{
    public class Email
    {

        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IFormFile Attachment { get; set; }
        public string Emails { get; set; }
        public string Password { get; set; }
    }
}
