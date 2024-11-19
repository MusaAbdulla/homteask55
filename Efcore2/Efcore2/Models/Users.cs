using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efcore2.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
