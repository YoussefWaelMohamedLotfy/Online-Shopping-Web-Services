using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Online_Shopping_Service.DTOs;
using Online_Shopping_Service.Models.Store;

namespace Online_Shopping_Service.Persistence.MappingProfiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
        }
    }
}