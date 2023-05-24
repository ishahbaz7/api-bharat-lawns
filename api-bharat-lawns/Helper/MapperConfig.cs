using System;
using AutoMapper;

namespace api_bharat_lawns.Helper
{
    public class MapperConfig
    {
        public static TDestination Map<TSourse, TDestination>(TSourse sourse)
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<TSourse, TDestination>());
            var mapper = new Mapper(config);
            return mapper.Map<TSourse, TDestination>(sourse);

        }
    }
}

