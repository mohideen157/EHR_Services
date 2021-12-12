using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Models
{
    public class RegisterEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
    }
}
