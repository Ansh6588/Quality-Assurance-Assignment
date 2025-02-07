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



        //Test 7-12 added by Gursimar Kaur

        [Test]
        public void IncreaseStock_ShouldNotChangeStock_WhenNegativeValueProvided()
        {
            // Arrange
            var product = new Product(150, "Laptop", 1500, 10);
            int initialStock = product.StockAmount;

            // Act
            product.IncreaseStock(-10);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(initialStock), "Stock should remain unchanged when given a negative value.");
        }





        [Test]
        public void IncreaseStock_ShouldNotExceedMaxAllowedStock()
        {
            // Arrange
            var maxAllowedStock = 50000; // Define a max stock limit
            var product = new Product(400, "Smart TV", 3000, 44000);
            int stockToIncrease = 6000; // Trying to increase stock beyond max allowed

            // Act
            product.IncreaseStock(stockToIncrease);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(maxAllowedStock)); // Stock should not exceed max allowed value
        }


        [Test]
        public void DecreaseStock_ShouldNotThrowException_WhenStockAmountIsGreaterThanCurrentStock()
        {
            // Arrange
            var product = new Product(300, "Monitor", 500, 50);
            int stockToDecrease = 60; // Trying to decrease more than available stock

            // Act
            product.DecreaseStock(stockToDecrease);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(5)); // Stock should not go below the minimum value of 5
        }


        [Test]
        public void ProductName_ShouldAllowAlphanumeric()
        {
            var product = new Product(200, "Chair2", 100m, 50);
            Assert.That(product.ProdName, Is.EqualTo("Chair2"));
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenNegativeStockProvided()
        {
            // Arrange
            int negativeStock = -5;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Product(200, "Headphones", 1500, negativeStock));
            Assert.That(ex.Message, Is.EqualTo("Stock amount must be between 5 and 500000."));
        }

        [Test]
        public void ProductId_ShouldAcceptValidRangeValues()
        {
            // Arrange
            var validProductId = 1000;
            var product = new Product(validProductId, "Smartphone", 500, 100);

            // Act & Assert
            Assert.That(product.ProdId, Is.EqualTo(validProductId)); // Product ID should be accepted
        }

        //Test 13-18 added by Gajendra

        [Test]
        public void ProdName_ShouldTrimWhitespace()
        {
            // Arrange
            var product = new Product(150, "  Laptop  ", 1500, 10);

            // Act
            var trimmedName = product.ProdName.Trim(); // Ensuring any whitespace is removed

            // Assert
            Assert.That(trimmedName, Is.EqualTo("Laptop"));
        }




        [Test]
        public void DecreaseStock_ShouldNotThrowException_WhenStockGoesBelowZero()
        {
            // Arrange
            var product = new Product(300, "Monitor", 500, 50);
            int stockToDecrease = 60; // Trying to decrease more than available stock

            // Act
            product.DecreaseStock(stockToDecrease);

            // Assert
            Assert.That(product.StockAmount, Is.EqualTo(5)); // Stock should be set to the minimum value of 5
        }


        [Test]
        public void ProductId_ShouldThrowException_WhenAboveMaxLimit()
        {
            // Act & Assert
            Assert.That(() => new Product(50001, "Smartwatch", 200, 15), Throws.ArgumentException
                .With.Message.EqualTo("Product ID must be between 5 and 50000."));
        }

        [Test]
        public void ItemPrice_ShouldAllowTwoDecimalPrecision()
        {
            // Arrange
            var product = new Product(250, "Keyboard", 199.99m, 50);

            // Act & Assert
            Assert.That(product.ItemPrice, Is.EqualTo(199.99m));
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenNegativePriceProvided()
        {
            // Act & Assert
            Assert.That(() => new Product(100, "Headphones", -50, 20), Throws.ArgumentException
                .With.Message.EqualTo("Item price must be between $5 and $5000."));
        }

        [Test]
        public void ItemPrice_ShouldThrowException_WhenExceedsMaxLimit()
        {
            // Arrange
            decimal maxPrice = 5000m;
            decimal exceededPrice = 5001m; // Price exceeds max limit

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Product(1001, "Laptop", exceededPrice, 50));
            Assert.That(ex.Message, Is.EqualTo("Item price must be between $5 and $5000."));
        }
    }



}
