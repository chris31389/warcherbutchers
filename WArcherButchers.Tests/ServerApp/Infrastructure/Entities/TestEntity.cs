using WArcherButchers.ServerApp.Infrastructure.Entities;

namespace WArcherButchers.Tests.ServerApp.Infrastructure.Entities
{
    public class TestEntity : Entity
    {
        public int Value { get; protected set; }

        public TestEntity(int value)
        {
            Value = value;
        }

        protected TestEntity()
        {
        }

        public void UpdateValue(int i)
        {
            Value = i;
            OnModified();
        }
    }
}