using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebBackPizzzzza.web.Services;

namespace WebBackPizzzzza.UnitTests.Services
{
    [TestClass]
    public class BasketServiceTest
    {
        private readonly IBasketService _sut = new BasketService();

        [TestMethod]
        public async Task AddToBasket_WhenAddOneItem_ExpectOneItemInBasket()
        {
            // Arrange
            const int id = 1;
            const int expected = 1;

            // Act
            await _sut.AddToBasket(id);

            var result = await _sut.ProductsInBasket();
            result.TryGetValue(id, out var actual);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task AddToBasket_WhenAddThreeItems_ExpectThreeItemsInBasket()
        {
            // Arrange
            const int id = 2;
            const int expected = 3;

            // Act
            await _sut.AddToBasket(id);
            await _sut.AddToBasket(id);
            await _sut.AddToBasket(id);

            var result = await _sut.ProductsInBasket();
            result.TryGetValue(id, out var actual);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task RemoveFromBasket_WhenAddThreeItemsRemoveOne_ExpectTwoItemsInBasket()
        {
            // Arrange
            const int id = 3;
            const int expected = 2;

            // Act
            await _sut.AddToBasket(id);
            await _sut.AddToBasket(id);
            await _sut.AddToBasket(id);
            await _sut.RemoveFromBasket(id);

            var result = await _sut.ProductsInBasket();
            result.TryGetValue(id, out var actual);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task RemoveFromBasket_WhenAddOneItemRemoveThree_ExpectZeroItemInBasket()
        {
            // Arrange
            const int id = 4;
            const int expected = 0;

            // Act
            await _sut.AddToBasket(id);
            await _sut.RemoveFromBasket(id);
            await _sut.RemoveFromBasket(id);
            await _sut.RemoveFromBasket(id);

            var result = await _sut.ProductsInBasket();
            result.TryGetValue(id, out var actual);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task RemoveFromBasket_WhenRemoveThree_ExpectZeroItemInBasket()
        {
            // Arrange
            const int id = 5;
            const int expected = 0;

            // Act
            await _sut.RemoveFromBasket(id);
            await _sut.RemoveFromBasket(id);
            await _sut.RemoveFromBasket(id);

            var result = await _sut.ProductsInBasket();
            result.TryGetValue(id, out var actual);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}