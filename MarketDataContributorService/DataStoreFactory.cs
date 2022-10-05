
namespace MarketDataContributorService
{
    public class DataStoreFactory
    {
        public static FxQuoteDataStore fxQuoteDataStore = new FxQuoteDataStore();

        public static IDataStore GetDataStore(string type)
        {
            if (type == "FxQuote")
            {
                return fxQuoteDataStore;
            }

            return null;
        }
    }
}
