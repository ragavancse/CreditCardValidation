using System;
using AutoMapper;
using CreditCardValidation.Models;

namespace CreditCardValidation.AutoMapper
{
    public class ApiAutoMapperProfile : Profile
    {
        public ApiAutoMapperProfile()
        {
            CreateMap<CardModel, CardDto>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
