using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ResponseDto
    {
        public bool isSuccesfull { get; set; }

        public IEnumerable<string> Errors { get; set; }

    }
}
