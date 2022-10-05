using System.Runtime.Serialization;
using System.ServiceModel;

namespace MarketDataContributorService
{
    [DataContract]
    public class IData
    {
        [DataMember]
        public string DataType { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "MarketDataContributorService.ContractType".
    [DataContract]
    public class FxQuote : IData
    {
        [DataMember]
        public double Bid { get; set; }

        [DataMember]
        public double Ask { get; set; }
    }

    [DataContract]
    public class ReturnStatus
    {
        [DataMember]
        public bool Result { get; set; }

        [DataMember]
        public string Message { get; set; }
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMarketDataContributor
    {
        [OperationContract]
        ReturnStatus AddFxQuote(string name, double bid, double ask);

        [OperationContract]
        FxQuote GetFxQuote(string name);

        // TODO: Add your service operations here
    }
}