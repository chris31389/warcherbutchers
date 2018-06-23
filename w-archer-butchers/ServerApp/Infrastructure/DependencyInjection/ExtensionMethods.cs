using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WArcherButchers.ServerApp.Infrastructure.DependencyInjection
{
    public static class ExtensionMethods
    {
        public static AssemblyBuilder<T> AddTypesFromAssembly<T>(
            this IServiceCollection serviceCollection,
            string endsWith,
            ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            AddClasses<T>(serviceCollection, endsWith, serviceLifetime);
            return new AssemblyBuilder<T>(serviceCollection);
        }

        public static AssemblyBuilder<T> And<T>(
            this AssemblyBuilder<T> assemblyBuilder,
            string endsWith,
            ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            AddClasses<T>(assemblyBuilder.ServiceCollection, endsWith, serviceLifetime);
            return assemblyBuilder;
        }

        private static void AddClasses<T>(IServiceCollection serviceCollection, string endsWith,
            ServiceLifetime serviceLifetime)
        {
            IEnumerable<ServiceDescriptor> serviceDescriptors = Assembly
                .GetAssembly(typeof(T))
                .GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith(endsWith))
                .SelectMany(type =>
                    {
                        Type[] allInterfaces = type.GetInterfaces();
                        return allInterfaces.Except
                                (allInterfaces.SelectMany(t => t.GetInterfaces()))
                            .ToList()
                            .Select(interfaceType => new ServiceDescriptor(interfaceType, type, serviceLifetime));
                    }
                );

            serviceCollection.Add(serviceDescriptors);
        }
    }
}