using Assignment2;

namespace TestProject1
{
    public class Tests
    {
        private Product _product;
        [SetUp]
        public void Setup()
        {
            _product = new Product(50, "Samsung galaxy S24 ultra", 2000, 5000);
        }

        [Test]
        public void IncreaseStock_Should_Increase_StockAmount()
        {
            //Arrange already done

            //Act 
            _product.IncreaseStock(20); // Increase stock amount by 20

            //Assert
            Assert.That(_product.StockAmount, Is.EqualTo(5020)); // Stock should increase by 20
        }

        [Test]
        public void DecreaseStock_Should_Decrease_StockAmount()
        {
            //Arrange already done

            //Act 
            _product.DecreaseStock(10); // decrease stock amount by 10

            //Assert
            Assert.That(_product.StockAmount, Is.EqualTo(4990)); // Stock should decrease by 10
        }

        [Test]
        public void DecreaseStock_ShouldNotGoBelowMinimumStock()
        {
            // Arrange already done

            // Act
            _product.DecreaseStock(4996); // decrease stock amount by 4996

            // Assert
            Assert.That(_product.StockAmount, Is.EqualTo(5)); // Stock should remain unchanged
        }

        [Test]
        public void IncreaseStock_ShouldHandleZeroAmount()
        {
            // Arrange: Already done

            // Act
            _product.IncreaseStock(0); //Increase stock by 0

            // Assert
            Assert.That(_product.StockAmount, Is.EqualTo(5000)); // Stock should increase by 0 or remain unchanghed
        }

        [Test]
        public void ItemPrice_ShouldAcceptMaximumValue()
        {
            // Arrange
            _product = new Product(110, "Fridge", 5000, 255);

            // Act
            decimal itemPrice = _product.ItemPrice; 

            // Assert
            Assert.That(itemPrice, Is.EqualTo(5000)); // item Price should accept maximum value - 5000
        }

        [Test]
        public void ItemPrice_ShouldAcceptMinimumValue()
        {
            // Arrange
            _product = new Product(115, "Fridge", 5, 5000);

            // Act
            decimal itemPrice = _product.ItemPrice;

            // Assert
            Assert.That(itemPrice, Is.EqualTo(5)); // item Price should accept maximum value - 5
        }

    }
}