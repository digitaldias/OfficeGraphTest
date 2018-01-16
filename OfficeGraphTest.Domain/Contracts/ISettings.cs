namespace OfficeGraphTest.Domain.Contracts
{
    public interface ISettings
    {
        string this[string key] { get; }
    }
}