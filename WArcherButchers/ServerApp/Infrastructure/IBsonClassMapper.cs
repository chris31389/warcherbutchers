namespace WArcherButchers.ServerApp.Infrastructure
{
    public interface IBsonClassMapper<T>
    {
        void RegisterMap();
    }
}