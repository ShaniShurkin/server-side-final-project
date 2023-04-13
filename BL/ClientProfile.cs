namespace BL
{
    internal class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
        }
        
    }
}
