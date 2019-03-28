using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebBackPizzzzza.web.Services;

namespace WebBackPizzzzza.UnitTests.Services
{
    [TestClass]
    public class BasketServiceTest
    {
        private readonly IBasketService _sut = new BasketService();

        const int Id = 1;

        [TestMethod]
        public async Task AddToBasket_WhenAddOneItem_ExpectOneItemInBasket()
        {
            // Arrange
            const int expected = 1;

            // Act
            _sut.ClearBasket();
            await _sut.AddToBasket(Id);

            var actual = _sut.NoOfProductsInBasket;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task AddToBasket_WhenAddThreeItems_ExpectThreeItemsInBasket()
        {
            // Arrange
            const int expected = 3;

            // Act
            _sut.ClearBasket();
            await _sut.AddToBasket(Id);
            await _sut.AddToBasket(Id);
            await _sut.AddToBasket(Id);

            var actual = _sut.NoOfProductsInBasket;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task RemoveFromBasket_WhenAddThreeItemsRemoveOne_ExpectTwoItemsInBasket()
        {
            // Arrange
            const int expected = 2;

            // Act
            _sut.ClearBasket();
            await _sut.AddToBasket(Id);
            await _sut.AddToBasket(Id);
            await _sut.AddToBasket(Id);
            await _sut.RemoveFromBasket(Id);

            var actual = _sut.NoOfProductsInBasket;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task RemoveFromBasket_WhenAddOneItemRemoveThree_ExpectZeroItemInBasket()
        {
            // Arrange
            const int expected = 0;

            // Act
            _sut.ClearBasket();
            await _sut.AddToBasket(Id);
            await _sut.RemoveFromBasket(Id);
            await _sut.RemoveFromBasket(Id);
            await _sut.RemoveFromBasket(Id);

            var actual = _sut.NoOfProductsInBasket;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task RemoveFromBasket_WhenRemoveThree_ExpectZeroItemInBasket()
        {
            // Arrange
            const int expected = 0;

            // Act
            _sut.ClearBasket();
            await _sut.RemoveFromBasket(Id);
            await _sut.RemoveFromBasket(Id);
            await _sut.RemoveFromBasket(Id);

            var actual = _sut.NoOfProductsInBasket;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task NoOfProductsInBasket_WhenAddedFiveItems_ExpectFiveItemInNoOfProducts()
        {
            // Arrange
            const int expected = 5;

            // Act
            _sut.ClearBasket();
            await _sut.AddToBasket(Id);
            await _sut.AddToBasket(Id);
            await _sut.AddToBasket(Id);
            await _sut.AddToBasket(Id);
            await _sut.AddToBasket(Id);

            var actual = _sut.NoOfProductsInBasket;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task NoOfProductsInBasket_WhenAddedFiveItemsWithTwoIds_ExpectFiveItemInNoOfProducts()
        {
            // Arrange
            const int secondId = 2;
            const int expected = 5;

            // Act
            _sut.ClearBasket();
            await _sut.AddToBasket(Id);
            await _sut.AddToBasket(Id);
            await _sut.AddToBasket(Id);
            await _sut.AddToBasket(secondId);
            await _sut.AddToBasket(secondId);

            var actual = _sut.NoOfProductsInBasket;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}