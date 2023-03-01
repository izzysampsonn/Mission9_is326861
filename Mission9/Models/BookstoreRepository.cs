using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public interface BookstoreRepository // abstract class
    {
        IQueryable<Book> Books { get; }
    }
}
