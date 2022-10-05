
using System.Collections.Generic;

namespace MarketDataContributorService
{
    public class FxQuoteDataStore : IDataStore
    {
        private Dictionary<string, FxQuote> table = new Dictionary<string, FxQuote>();
        private readonly ILogger logger = new Logger();

        public IData Get(string key)
        {
            if (table.ContainsKey(key))
            {
                return table[key];
            }

            return null;
        }

        public void Insert(IData insertData)
        {
            if (insertData == null || !(insertData is FxQuote))
            {
                logger.LogError($"Invalid data type");
                return;
            }

            var data = (FxQuote)insertData;

            if (table.ContainsKey(data.Name))
            {
                logger.LogInfo($"Update {data.Name}");
                table[data.Name] = data;
            }
            else
            {
                logger.LogInfo($"Insert {data.Name}");
                table.Add(data.Name, data);
            }
        }
    }
}
