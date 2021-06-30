using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThomasJude.Core.JsonSerializer;

namespace ThomasJude.Tests
{
    [TestClass]
    public class JsonSerializerAdapterTests
    {
        [TestMethod]
        public void Serialize_ValidObject_ReturnsProperString()
        {
            // arrange
            var p = new Person{
                FirstName = "John",
                LastName = "Doe"
            };
            IJsonSerializer serializer = new JsonSerializerAdapter();

            // act
            var result = serializer.Serialize(p);

            // assert
            Assert.AreEqual("{\"FirstName\":\"John\",\"LastName\":\"Doe\"}", result);
        }

        [TestMethod]
        public void Deserialize_ValidObject_ReturnsProperString()
        {
            // arrange
            var p = "{\"FirstName\":\"John\",\"LastName\":\"Doe\"}";
            IJsonSerializer serializer = new JsonSerializerAdapter();

            // act
            var result = serializer.Deserialize<Person>(p);

            // assert
            Assert.AreEqual("John", result.FirstName);
            Assert.AreEqual("Doe", result.LastName);
        }

        private class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
