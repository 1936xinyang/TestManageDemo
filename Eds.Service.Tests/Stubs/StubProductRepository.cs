using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eds.Data;
using Eds.IRepository;

namespace Eds.Service.Tests.Stubs
{
    public class StubProductRepository : IProductRepository
    {
        public IList<Product> GetAllProductsIn(int categoryId)
        {
            IList<Product> products = new List<Product>();

            return products;
        }
    }
}
