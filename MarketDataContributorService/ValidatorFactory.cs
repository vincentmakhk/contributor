
namespace MarketDataContributorService
{
    public class ValidatorFactory
    {
        public static FxQuoteMarketDataValidator fxQuoteMarketDataValidator = new FxQuoteMarketDataValidator();

        public static IMarketDataValidator GetValidator(string type)
        {
            if (type == "FxQuote")
            {
                return fxQuoteMarketDataValidator;
            }

            return null;
        }
    }
}
