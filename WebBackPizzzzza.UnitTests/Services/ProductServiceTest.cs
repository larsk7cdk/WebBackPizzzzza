using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebBackPizzzzza.web.Services;

namespace WebBackPizzzzza.UnitTests.Services
{
    [TestClass]
    public class ProductServiceTest
    {
        private readonly IProductService _sut = new ProductService();

        [TestMethod]
        public async Task UpdateBasket_WhenAddOneItem_ExpectOneItemInBasket()
        {
            // Arrange
            const int expected = 1;

            // Act
            await _sut.UpdateBasket(1, 1);

            var result = await _sut.GetProductById(1);
            var actual = result.Basket;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task UpdateBasket_WhenAddTwoItem_ExpectTwoItemsInBasket()
        {
            // Arrange
            const int expected = 2;

            // Act
            await _sut.UpdateBasket(1, 2);

            var result = await _sut.GetProductById(1);
            var actual = result.Basket;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task UpdateBasket_WhenRemoveOneItem_ExpectTwoItemsInBasket()
        {
            // Arrange
            const int expected = 2;

            // Act
            await _sut.UpdateBasket(1, 3);
            await _sut.UpdateBasket(1, -1);

            var result = await _sut.GetProductById(1);
            var actual = result.Basket;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task UpdateBasket_WhenRemoveMoreItemsThanInBasket_ExpectZeroItemInBasket()
        {
            // Arrange
            const int expected = 0;

            // Act
            await _sut.UpdateBasket(1, 1);
            await _sut.UpdateBasket(1, -3);

            var result = await _sut.GetProductById(1);
            var actual = result.Basket;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}