using System;
using ArrangementApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrangementApp.Tests
{
    [TestClass]
    public class ArrangementTests
    {
        // Тест 1: конструктор за замовчуванням створює A(0, 0).
        [TestMethod]
        public void Constructor_Default_NAndMAreZero()
        {
            // Arrange
            // Act
            var a = new Arrangement();
            // Assert
            Assert.AreEqual(0, a.N);
            Assert.AreEqual(0, a.M);
        }

        // Тест 2: конструктор з параметрами записує n і m.
        [TestMethod]
        public void Constructor_ValidParameters_SetsNAndM()
        {
            // Arrange
            int n = 5, m = 2;
            // Act
            var a = new Arrangement(n, m);
            // Assert
            Assert.AreEqual(5, a.N);
            Assert.AreEqual(2, a.M);
        }

        // Тест 3: m більше за n, конструктор генерує ArgumentOutOfRangeException.
        [TestMethod]
        public void Constructor_MGreaterThanN_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int n = 3, m = 4;
            // Act + Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Arrangement(n, m));
        }

        // Тест 4: від'ємне n, конструктор генерує ArgumentOutOfRangeException.
        [TestMethod]
        public void Constructor_NegativeN_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int n = -1, m = 0;
            // Act + Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Arrangement(n, m));
        }

        // Тест 5: конструктор копіювання створює рівний об'єкт.
        [TestMethod]
        public void Constructor_Copy_CreatesEqualObject()
        {
            // Arrange
            var original = new Arrangement(7, 3);
            // Act
            var copy = new Arrangement(original);
            // Assert
            Assert.AreEqual(original, copy);
        }

        // Тест 6: властивості M не можна присвоїти значення, більше за N.
        [TestMethod]
        public void SetM_GreaterThanN_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var a = new Arrangement(5, 2);
            // Act + Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => a.M = 6);
        }

        // Тест 7: A(5, 2) = 5 * 4 = 20.
        [TestMethod]
        public void Count_N5M2_Returns20()
        {
            // Arrange
            var a = new Arrangement(5, 2);
            // Act
            long result = a.Count();
            // Assert
            Assert.AreEqual(20L, result);
        }

        // Тест 8: при m = 0 є рівно один спосіб (нічого не вибирати).
        [TestMethod]
        public void Count_MIsZero_Returns1()
        {
            // Arrange
            var a = new Arrangement(6, 0);
            // Act
            long result = a.Count();
            // Assert
            Assert.AreEqual(1L, result);
        }

        // Тест 9: A(0, 0) = 1.
        [TestMethod]
        public void Count_NAndMAreZero_Returns1()
        {
            // Arrange
            var a = new Arrangement(0, 0);
            // Act
            long result = a.Count();
            // Assert
            Assert.AreEqual(1L, result);
        }

        // Тест 10: при m = n кількість розміщень дорівнює n!; A(5, 5) = 120.
        [TestMethod]
        public void Count_MEqualsN_ReturnsFactorial()
        {
            // Arrange
            var a = new Arrangement(5, 5);
            // Act
            long result = a.Count();
            // Assert
            Assert.AreEqual(120L, result);
        }

        // Тест 11: A(20, 20) = 20! ще вміщується в long.
        [TestMethod]
        public void Count_N20M20_ReturnsMaxFactorialInLong()
        {
            // Arrange
            var a = new Arrangement(20, 20);
            // Act
            long result = a.Count();
            // Assert
            Assert.AreEqual(2432902008176640000L, result);
        }

        // Тест 12: A(21, 21) = 21! не вміщується в long, генерується OverflowException.
        [TestMethod]
        public void Count_ResultTooLarge_ThrowsOverflowException()
        {
            // Arrange
            var a = new Arrangement(21, 21);
            // Act + Assert
            Assert.ThrowsException<OverflowException>(() => a.Count());
        }

        // Тест 13: розміщення з однаковими n і m рівні.
        [TestMethod]
        public void Equals_SameNAndM_ReturnsTrue()
        {
            // Arrange
            var a = new Arrangement(5, 2);
            var b = new Arrangement(5, 2);
            // Act
            bool result = a.Equals(b);
            // Assert
            Assert.IsTrue(result);
        }

        // Тест 14: розміщення з різним m не рівні.
        [TestMethod]
        public void Equals_DifferentM_ReturnsFalse()
        {
            // Arrange
            var a = new Arrangement(5, 2);
            var b = new Arrangement(5, 3);
            // Act
            bool result = a.Equals(b);
            // Assert
            Assert.IsFalse(result);
        }

        // Тест 15: порівняння з null повертає false.
        [TestMethod]
        public void Equals_Null_ReturnsFalse()
        {
            // Arrange
            var a = new Arrangement(5, 2);
            // Act
            bool result = a.Equals(null);
            // Assert
            Assert.IsFalse(result);
        }

        // Тест 16: A(5, 2) = 20 менше за A(4, 3) = 24, результат від'ємний.
        [TestMethod]
        public void CompareTo_SmallerCount_ReturnsNegative()
        {
            // Arrange
            var a = new Arrangement(5, 2);
            var b = new Arrangement(4, 3);
            // Act
            int result = a.CompareTo(b);
            // Assert
            Assert.IsTrue(result < 0);
        }

        // Тест 17: A(4, 3) = 24 більше за A(5, 2) = 20, результат додатний.
        [TestMethod]
        public void CompareTo_GreaterCount_ReturnsPositive()
        {
            // Arrange
            var a = new Arrangement(4, 3);
            var b = new Arrangement(5, 2);
            // Act
            int result = a.CompareTo(b);
            // Assert
            Assert.IsTrue(result > 0);
        }

        // Тест 18: A(6, 2) = 30 і A(30, 1) = 30 мають однакову кількість, результат 0.
        [TestMethod]
        public void CompareTo_EqualCountDifferentNM_ReturnsZero()
        {
            // Arrange
            var a = new Arrangement(6, 2);
            var b = new Arrangement(30, 1);
            // Act
            int result = a.CompareTo(b);
            // Assert
            Assert.AreEqual(0, result);
        }

        // Тест 19: порівняння з null генерує ArgumentNullException.
        [TestMethod]
        public void CompareTo_Null_ThrowsArgumentNullException()
        {
            // Arrange
            var a = new Arrangement(5, 2);
            // Act + Assert
            Assert.ThrowsException<ArgumentNullException>(() => a.CompareTo(null!));
        }

        // Тест 20: ToString повертає запис виду "A(5, 2)".
        [TestMethod]
        public void ToString_Arrangement_ReturnsFormattedString()
        {
            // Arrange
            var a = new Arrangement(5, 2);
            // Act
            string result = a.ToString();
            // Assert
            Assert.AreEqual("A(5, 2)", result);
        }
    }
}
