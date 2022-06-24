using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Lead;
using WebApi.Models.Users;

namespace WebApi.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, AuthenticateResponse>();

        CreateMap<RegisterRequest, User>();

        CreateMap<Models.Users.UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    if ((prop is null) ||
                        (prop.GetType().Equals(typeof(string)) && string.IsNullOrEmpty((string)prop)))
                        return false;
                    return true;
                }
            ));

        CreateMap<LeadRequest, Lead>();

        CreateMap<Models.Lead.UpdateRequest, Lead>()
           .ForAllMembers(x => x.Condition(
               (src, dest, prop) =>
               {
                   if ((prop is null) ||
                       (prop.GetType().Equals(typeof(string)) && string.IsNullOrEmpty((string)prop)))
                       return false;
                   return true;
               }
           ));
    }
}