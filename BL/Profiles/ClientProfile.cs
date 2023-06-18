namespace BL.Profiles
{
    internal class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Meal, MealDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap()
                .ForMember(src => src.Code, opt => opt.MapFrom(_ => ClientService.CurrentCode));
            
            CreateMap<Client, Client>()
           .ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
        }
        
    }
}
