using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CustomerInfoDto
    {
        public Customer Customer { get; set; }
        public List<Account> Accounts { get; set; }

    }
}
