using System;

namespace WArcherButchers.ServerApp.Infrastructure.Entities
{
    public interface ISubEntity : IEntity
    {
        Guid EntityId { get; }
    }
}