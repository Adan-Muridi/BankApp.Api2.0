using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Disposition
    {
        public int DispositionId { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string Type { get; set; }

        public Account Account { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
