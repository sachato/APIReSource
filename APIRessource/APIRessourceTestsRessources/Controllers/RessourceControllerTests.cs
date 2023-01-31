using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIRessource.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRessource.Controllers.Tests
{
    [TestClass()]
    public class RessourceControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var testProducts = get();
            var controller = new SimpleProductController(testProducts);

            var result = controller.GetAllProducts() as List<Product>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }
    }
}