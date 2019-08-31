using AutoMapper;
using Eds.Web.Dtos;
using Eds.Web.Models;
using Eds.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eds.Web.Configs
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize(
                x => x.CreateMap<Book, BookViewModel>()
            .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.Author.Name)).ReverseMap()


            //y => y.CreateMap<PersonDTO, Person>()
            //.ForMember(dest => dest.Address, opts => opts.MapFrom(src => new Address
            //{
            //    Street = src.Street,
            //    City = src.City,
            //    State = src.State,
            //    ZipCode = src.ZipCode
            //}
            //))
            );  
        }
    }
}