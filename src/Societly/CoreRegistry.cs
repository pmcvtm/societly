using MediatR;
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
