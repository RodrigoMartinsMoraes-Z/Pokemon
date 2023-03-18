using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Domain.Masters
{
    public class Master
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}
