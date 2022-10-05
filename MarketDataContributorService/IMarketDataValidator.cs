namespace MarketDataContributorService
{
    public interface IMarketDataValidator
    {
        bool Validate(IData data);
    }
}
