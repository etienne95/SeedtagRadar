using Autofac.Extras.Moq;
using AutoMapper;
using SeedtagRadar.Application;

namespace SeedtagRadar.Tests
{
    public class TestBase
    {
        protected AutoMock _mockProvider;
        protected IMapper _mapper;

        public TestBase()
        {
            Initialize();
        }

        void Initialize()
        {
            var config = new MapperConfiguration(opts => {
                opts.AddProfile(new Mapping());
            });
            _mapper = config.CreateMapper();

            _mockProvider = AutoMock.GetLoose();
            _mockProvider.Provide(_mapper);
        }
    }
}