using System.ServiceModel;
using System;

namespace MarketDataContributorService
{
    public class MarketDataContributor : IMarketDataContributor
    {
        private readonly ILogger logger = new Logger();

        public ReturnStatus AddFxQuote(string name, double bid, double ask)
        {
            logger.LogInfo($"Add FxQuote {name} {bid} {ask}");

            var dataStore = DataStoreFactory.GetDataStore("FxQuote");
            if (dataStore == null)
            {
                logger.LogError($"Cannot get data store for FxQuote");
                return new ReturnStatus()
                {
                    Result = false,
                    Message = "Unknown data type"
                };
            }

            var validator = ValidatorFactory.GetValidator("FxQuote");
            if (validator == null)
            {
                logger.LogError($"Cannot get validator for FxQuote");
                return new ReturnStatus() {
                    Result = false,
                    Message = "Cannot validate"
                };
            }

            var data = new FxQuote {
                DataType = "FxQuote",
                Name = name,
                Ask = ask,
                Bid = bid
            };

            if (!validator.Validate(data))
            {
                logger.LogError($"Cannot get validator for FxQuote");
                return new ReturnStatus()
                {
                    Result = false,
                    Message = "Invalid data"
                };
            }

            dataStore.Insert(data);

            return new ReturnStatus
            {
                Result = true
            };
        }

        public FxQuote GetFxQuote(string name)
        {
            logger.LogInfo($"Get FxQuote {name}");

            var dataStore = DataStoreFactory.GetDataStore("FxQuote");
            if (dataStore == null)
            {
                logger.LogError($"Cannot get data store for FxQuote");
                return new FxQuote();
            }

            var returnValue = (FxQuote) dataStore.Get(name);
            if (returnValue == null)
            {
                logger.LogError($"Cannot find data for {name}");
                return new FxQuote();
            }

            return returnValue;
        }
    }
}
