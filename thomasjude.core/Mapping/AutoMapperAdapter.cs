
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using AutoMapper;

namespace thomasjude.core.Mapping
{
    public class AutoMapperAdapter : IMapper
    {
        private Mapper _mapper;

        public AutoMapperAdapter()
        {
            // var config = new MapperConfiguration(cfg => {
            //     cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            // });
            // _mapper = new Mapper(config);
        }
        public TOut Map<TIn, TOut>(TIn src) => _mapper.Map<TIn,TOut>(src);
        public TOut Map<TOut>(object src) => _mapper.Map<TOut>(src);
        public void RegisterFromAssemblies(IEnumerable<Assembly> assemblies)
        {
            var _assemblies = assemblies.ToList();
            var types = _assemblies.Select(assembly => assembly.GetTypes()
                                                               .Where(x => x.IsAssignableFrom(typeof(AutoMapperAdapterProfile)) && !x.IsAbstract && !x.IsInterface))
                                   .SelectMany(x => x)
                                   .Cast<AutoMapperAdapterProfile>();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfiles(types);
            });
            _mapper = new Mapper(config);
        }
    }

    public abstract class AutoMapperAdapterProfile : Profile
    {

    }
}