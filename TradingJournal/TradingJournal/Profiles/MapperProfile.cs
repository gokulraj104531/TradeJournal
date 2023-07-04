using AutoMapper;
using TradingJournal.Models;
using TradingJournal.DTO;


namespace TradingJournal.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile() {

            CreateMap<UserRegistration,UserRegistrationDTO>();
            CreateMap<UserRegistrationDTO, UserRegistration>();

            CreateMap<Journal, JournalDTO>();
            CreateMap<JournalDTO, Journal>();

            CreateMap<UserRegistration,LoginModel>();
            CreateMap<LoginModel, UserRegistration>();
        }
    }
}
