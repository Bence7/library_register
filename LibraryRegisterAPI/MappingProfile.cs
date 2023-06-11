using AutoMapper;
using LibraryRegisterAPI.Models.Entities;
using LibraryRegisterAPI.Models.Requests;

namespace LibraryRegisterAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookRequest, Book>();
            CreateMap<MemberRequest, Member>();
            CreateMap<RentalRequest, Rental>();
        }
    }
}
