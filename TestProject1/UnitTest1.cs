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
        /*Test 1-6 added by Ansh GirishKumar Patel*/

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



        /*Test 7-12 added by Gursimar Kaur*/

        [Test]
        public void Constructor_ShouldThrowException_WithInvalidProdId()
        {
            // Arrange, Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Product(1, "Invalid", 100.0m, 50));
            Assert.That(ex.Message, Is.EqualTo("Product ID must be between 5 and 50000."));
        }


        [Test]
        public void IncreaseStock_ShouldIncreaseStock_WhenAmountIsPositive()
        {
            // Arrange
            var product = new Product(100, "Chair", 1200m, 50);

            // Act
            product.IncreaseStock(90);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(140));
        }

        [Test]
        public void DecreaseStock_ShouldReduceStock_ByExactAmount()
        {
            var product = new Product(400, "Table", 250m, 250);
            product.DecreaseStock(28);
            Assert.That(product.StockAmount, Is.EqualTo(222));
        }

        [Test]
        public void ProductName_ShouldAllowAlphanumeric()
        {
            var product = new Product(200, "Chair2", 100m, 50);
            Assert.That(product.ProdName, Is.EqualTo("Chair2"));
        }

        [Test]
        public void ProductId_ShouldAcceptMinimumValue()
        {
            var product = new Product(5, "LowID", 100m, 50);
            Assert.That(product.ProdId, Is.EqualTo(5));
        }

        [Test]
        public void StockAmount_ShouldRemainUnchanged_WhenIncreaseByZero()
        {
            var product = new Product(500, "Table", 300m, 200);
            product.IncreaseStock(0);
            Assert.That(product.StockAmount, Is.EqualTo(200));
        }

    }
}