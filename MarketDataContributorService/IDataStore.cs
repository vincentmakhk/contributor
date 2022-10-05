namespace MarketDataContributorService
{
    public interface IDataStore
    {
        void Insert(IData data);

        IData Get(string key);
    }
}
