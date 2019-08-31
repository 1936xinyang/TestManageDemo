using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eds.Data;
using Eds.IRepository;

namespace Eds.Service.Tests.Mocks
{
    public class MockProductRepository : IProductRepository
    {
        private int _numberOfTimesCalled = 0;

        public int NumberOfTimesCalled()
        {
            return _numberOfTimesCalled;
        }

        public IList<Product> GetAllProductsIn(int categoryId)
        {
            _numberOfTimesCalled++;

            IList<Product> products = new List<Product>();

            return products;
        }
    }
}
