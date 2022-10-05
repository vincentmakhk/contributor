namespace MarketDataContributorService
{
    public class FxQuoteMarketDataValidator : IMarketDataValidator
    {
        public bool Validate(IData validateData)
        {
            if (validateData == null || !(validateData is FxQuote))
                return false;

            var data = (FxQuote)validateData;
            return data.Ask > 0 && data.Bid > 0 && data.Ask > data.Bid;
        }
    }
}
