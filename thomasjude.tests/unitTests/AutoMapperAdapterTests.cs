
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThomasJude.Core.Mapping;

namespace ThomasJude.Tests
{
    [TestClass]
    public class AutoMapperAdapterTests
    {
        [TestMethod]
        public void Map_NoErrors()
        {
            // arrange
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            IMapper mapper = new AutoMapperAdapter(assemblies);
            var person = new Person{
                FirstName = "John",
                LastName = "Doe"
            };

            // act
            var result = mapper.Map<PersonDto>(person);

            // assert
            Assert.AreEqual("John Doe", result.FullName);
        }

        public class Person
        {
            public String FirstName { get; set; }
            public String LastName { get; set; }
        }
        public class PersonDto
        {
            public String FullName { get; set; }
        }
        public class PersonMappingProfile : AutoMapperAdapterProfile
        {
            public PersonMappingProfile()
            {
                CreateMap<Person, PersonDto>().ForMember(dest => dest.FullName, (opt) => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            }
        }
    }
}
