using Microsoft.Extensions.DependencyInjection;

namespace WArcherButchers.ServerApp.Infrastructure.DependencyInjection
{
    public class AssemblyBuilder<T>
    {
        public IServiceCollection ServiceCollection { get; }

        public AssemblyBuilder(IServiceCollection serviceCollection) => ServiceCollection = serviceCollection;
    }
}