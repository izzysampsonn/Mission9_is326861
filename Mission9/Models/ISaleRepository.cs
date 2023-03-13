using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public interface ISaleRepository
    {
        IQueryable<Sale> Sales { get; }

        public void SaveSale(Sale sale);
    }
}
