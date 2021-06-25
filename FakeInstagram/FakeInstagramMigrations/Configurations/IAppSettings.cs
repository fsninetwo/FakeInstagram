namespace FakeInstagramMigrations.Configurations
{
    public interface IAppSettings
    {
        string ConnectionString { get; set; }

        string Secret { get; set; }
    }
}