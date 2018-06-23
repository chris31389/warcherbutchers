using System;

namespace WArcherButchers.ServerApp.Infrastructure.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}