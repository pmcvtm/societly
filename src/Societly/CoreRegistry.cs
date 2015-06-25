using MediatR;
using Societly.Domain;
using StructureMap.Configuration.DSL;

namespace Societly
{
    public class CoreRegistry : Registry 
    {
        public CoreRegistry()
        {
            Scan(
                scan =>
                {
                    scan.AssemblyContainingType<IMediator>();
                    scan.AssemblyContainingType<Socialite>();
                    scan.WithDefaultConventions();
                    scan.ConnectImplementationsToTypesClosing(typeof (IRequestHandler<,>));
                    scan.ConnectImplementationsToTypesClosing(typeof (IAsyncRequestHandler<,>));
                    scan.ConnectImplementationsToTypesClosing(typeof (INotificationHandler<>));
                    scan.ConnectImplementationsToTypesClosing(typeof (IAsyncNotificationHandler<>));
                }
            );

            For<IMediator>().Use<Mediator>();
        }
    }
}
