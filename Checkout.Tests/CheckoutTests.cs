using System;
using System.Collections.Generic;
using Checkout.App;
using Xunit;

namespace Checkout.Tests
{
    
    public class CheckoutTests
    {

        [Fact]
        public void CheckIfBABScanIs95()
        {
            // Arrange
            ICheckout subject = new App.Checkout();

            subject.Scan("B");
            subject.Scan("A");
            subject.Scan("B");


            // Act
            // Assert
            Assert.Equal(95, subject.GetTotal());
        }

        [Fact]
        public void CheckIfBAACABScanIs195()
        {
            // Arrange
            ICheckout subject = new App.Checkout();

            subject.Scan("B");
            subject.Scan("A");
            subject.Scan("A");
            subject.Scan("C");
            subject.Scan("A");
            subject.Scan("B");


            // Act
            // Assert
            Assert.Equal(195, subject.GetTotal());
        }

        [Fact]
        public void CheckIfNoScanIs0()
        {
            // Arrange
            ICheckout subject = new App.Checkout();

            // Act
            // Assert
            Assert.Equal(0, subject.GetTotal());
        }
    }
}
