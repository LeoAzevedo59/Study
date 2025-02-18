using Application.AutoMapper;
using AutoMapper;

namespace CommonTestUtilities.Mapper
{
    public static class MapperBuilder
    {
        public static IMapper Build()
        {
            MapperConfiguration mapper = new(config =>
            {
                config.AddProfile(new AutoMapping());
            });


            return mapper.CreateMapper();
        }
    }
}
