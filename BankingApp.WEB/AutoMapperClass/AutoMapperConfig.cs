using AutoMapper;
using BankingApp.BLL.ViewModels;
using BankingApp.DAL.Entities;

namespace BankingApp.WEB.AutoMapperClass
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<UserDTO, User>().ReverseMap();
                config.CreateMap<User, RegisterViewModel>().ReverseMap();
                config.CreateMap<TransactionDTO, Transaction>().ReverseMap();
            });
        }
    }
}