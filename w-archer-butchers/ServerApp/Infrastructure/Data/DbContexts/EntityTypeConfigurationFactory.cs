using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WArcherButchers.ServerApp.Infrastructure.Data.DbContexts
{
    public class EntityTypeConfigurationFactory : IEntityTypeConfigurationFactory
    {
        private List<Type> TypesToRegister { get; }

        public EntityTypeConfigurationFactory()
        {
            TypesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => !type.IsAbstract)
                .Where(type => type.BaseType != null)
                .Where(type => type.IsClass)
                .Where(ImplementsEntityTypeConfigurationInterface)
                .ToList();
        }

        public void Initialize(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            TypesToRegister.ForEach(type =>
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            });
        }

        private static bool ImplementsEntityTypeConfigurationInterface(Type type) =>
            type
                .GetTypeInfo()
                .FindInterfaces(
                    MyInterfaceFilter,
                    typeof(
                        IEntityTypeConfiguration
                        <>).FullName)
                .Length > 0;

        private static bool MyInterfaceFilter(Type type, object filterCriteria)
        {
            return type.ToString().Contains(filterCriteria.ToString());
        }
    }
}