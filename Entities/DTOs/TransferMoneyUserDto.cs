using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TransferMoneyUserDto
    {
        public int AccountOriginId { get; set; }
        public int AccountDestinationId { get; set; }
        public decimal Amount { get; set; }

        public decimal AccountOriginBalance { get; set; }
        public decimal AccountDestinationBalance { get; set; }
        public string Operation { get; set; }
    }
}
