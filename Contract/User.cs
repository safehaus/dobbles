using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safehouse.IntranetGaming.Contract
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string AssociatedRoom { get; set; }
    }
}
