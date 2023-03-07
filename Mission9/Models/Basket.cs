using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();// declare variables and instantiate

        public void AddItem (Book book, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem // add new entry to list if not there
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else // if already there just increase the quantity
            {
                line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return sum;
        }
    }


    public class BasketLineItem
    {
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
