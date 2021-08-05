using Autofac;
using SeedtagRadar.Application.Filters;
using SeedtagRadar.Application.Selectors;
using SeedtagRadar.Domain;
using SeedtagRadar.Domain.Interfaces;

namespace SeedtagRadar.Api.Modules
{
    public class CustomModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AssistAlliesFilter>().Named<IProtocol>(Constants.ASSIST_ENEMIES);
            builder.RegisterType<AvoidCrossfireFilter>().Named<IProtocol>(Constants.AVOID_CROSSFIRE);
            builder.RegisterType<PrioritizeMechFilter>().Named<IProtocol>(Constants.PRIORITIZE_MECH);
            builder.RegisterType<AvoidMechFilter>().Named<IProtocol>(Constants.AVOID_MECH);

            builder.RegisterType<ClosestEnemiesSelector>().Named<IProtocol>(Constants.CLOSEST_ENEMIES);
            builder.RegisterType<FurthestEnemiesSelector>().Named<IProtocol>(Constants.FURTHEST_ENEMIES);
        }
    }
}