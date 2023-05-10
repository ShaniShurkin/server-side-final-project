namespace BL.Profiles
{
    internal class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Food, FoodDTO>().ReverseMap();//.ForMember(dest => dest.Id, src => src.Ignore()).ReverseMap();
        }
    }
}
