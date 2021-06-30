
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThomasJude.Core.Mapping;

namespace ThomasJude.Tests
{
    [TestClass]
    public class AutoMapperAdapterTests
    {
        [TestMethod]
        public void Map_ExistingProfile_NoErrors()
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
        [TestMethod]
        public void Map_NoExistingProfile_Error()
        {
            // arrange
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            IMapper mapper = new AutoMapperAdapter(assemblies);
            var p = new PersonDto{
                FullName = "John Doe"
            };
            bool didThrowException = false;

            // act
            try{
                var result = mapper.Map<Person>(p);
            }catch(Exception ex)
            {
                didThrowException = true;
            }

            // assert
            Assert.IsTrue(didThrowException);
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
