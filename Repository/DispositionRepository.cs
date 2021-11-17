using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class DispositionRepository : RepositoryBase<Disposition>, IDispositionRepository
    {
        public DispositionRepository(BankDbContext bankDbContext) : base(bankDbContext)
        {

        }
        public void CreateDisposion(Disposition disposition)
        {
            Create(disposition);
        }
    }
}
