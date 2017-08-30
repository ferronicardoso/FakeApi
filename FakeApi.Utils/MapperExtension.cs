namespace AutoMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public static class MapperExtension
    {
        public static TDestination To<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }

        public static TDestination To<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
