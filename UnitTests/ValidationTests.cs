using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestAssignment.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestCase(null, "description", "USD", 100, "Account is null or empty")]
        [TestCase("", "description", "USD", 100, "Account is null or empty")]
        [TestCase("account", null, "USD", 100, "Description is null or empty")]
        [TestCase("account", "", "USD", 100, "Description is null or empty")]
        [TestCase("account", "description", "FOO", 100, "Unknown currency code")]
        [TestCase("account", "description", "USD", null, "Value must be a valid number")]
        public void Validate_WhenDataIsNotValid_Error(string account, string description, string currencyCode, int? value, string expectedError)
        {
            // Arrange
            var v = RecordValidator.CreateInstance();

            // Act
            var result = v.Validate(account, description, currencyCode, value);

            // Assert
            Assert.AreEqual(expectedError, result[0]);
        }

        [TestCase("abc", true)]
        [TestCase("Data Source=localhost;Initial Catalog=testDB;Integrated Security=True", false)]
        public void NeedNewConnectionString_WhenConnectionStringIsNotValid_Error(string connectionString, bool expected)
        {
            // Arrange
            var m = new ConnectionStringManager();

            // Act
            var result = m.NeedNewConnectionString(connectionString);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
