namespace BL.Profiles
{
    internal class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Client, Client>()
           .ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
        }
        
    }
}
