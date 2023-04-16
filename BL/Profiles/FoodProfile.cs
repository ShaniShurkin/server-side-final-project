namespace BL
{
    internal class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<FoodDTO, Food>();//.ForMember(dest => dest.Id, src => src.Ignore()).ReverseMap();
        }
    }
}
