using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiesProject.Models
{
    public class LoginEntity
    {
        public static LoginEntity loginEntity { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

    }
}
