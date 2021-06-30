
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

        public AutoMapperAdapter(IEnumerable<Assembly> profileAssemblies)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddMaps(profileAssemblies);
            });
            _mapper = new Mapper(config);
        }
        public TOut Map<TIn, TOut>(TIn src) => _mapper.Map<TIn,TOut>(src);
        public TOut Map<TOut>(object src) => _mapper.Map<TOut>(src);
    }

    public abstract class AutoMapperAdapterProfile : Profile
    {

    }
}