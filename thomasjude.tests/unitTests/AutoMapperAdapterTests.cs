
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using thomasjude.core.Mapping;

namespace thomasjude.tests
{
    [TestClass]
    public class AutoMapperAdapterTests
    {
        [TestMethod]
        public void Map_NoErrors()
        {
            // arrange
            IMapper mapper = new AutoMapperAdapter();
            // var assemblies = new List<Assembly>{
            //     Assembly.GetExecutingAssembly()
            // };
            mapper.RegisterFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            var person = new Person{
                FirstName = "John",
                LastName = "Doe"
            };

            // act
            var result = mapper.Map<PersonDto>(person);

            // assert
            Assert.AreEqual("JohnDoe", result.FullName);
            Assert.IsTrue(true);
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
