using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Online_Shopping_Service.Persistence.MappingProfiles;

namespace Online_Shopping_Service.Persistence
{
    public class StoreMapper
    {
        private static MapperConfiguration config = new MapperConfiguration(cfg => 
                                                            cfg.AddProfile<StoreProfile>());

        public static Mapper mapper = new Mapper(config);

        public StoreMapper()
        {
        }
    }
}