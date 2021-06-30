
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ThomasJude.Core.Mapping
{
    public interface IMapper
    {
        TOut Map<TIn, TOut>(TIn src);
        TOut Map<TOut>(object src);
    }
}