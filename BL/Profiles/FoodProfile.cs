namespace BL.Profiles
{
    internal class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Food, FoodDTO>().ReverseMap()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(_ => FoodService.CurrentCode));
        }
    }
}
