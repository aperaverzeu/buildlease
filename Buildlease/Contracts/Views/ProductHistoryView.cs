using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Views
{
    public class ProductHistoryView
    {
        public ProductFullView ProductFullView { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
