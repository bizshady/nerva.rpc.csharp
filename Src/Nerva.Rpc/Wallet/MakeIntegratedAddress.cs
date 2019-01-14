using System;
using Newtonsoft.Json;

namespace Nerva.Rpc.Wallet
{
    public class MakeIntegratedAddress : Request<MakeIntegratedAddressRequestData, MakeIntegratedAddressResponseData>
    {
        public MakeIntegratedAddress(MakeIntegratedAddressRequestData rpcData, Action<MakeIntegratedAddressResponseData> completeAction, Action<RequestError> failedAction, uint port = 13895)
            : base (rpcData, completeAction, failedAction, port) { }
            
        protected override bool DoRequest(out MakeIntegratedAddressResponseData result)
        {
            string json = null;
            bool r = JsonRpcRequest("make_integrated_address", rpcData, out json);
            result = r ? JsonConvert.DeserializeObject<ResponseData<MakeIntegratedAddressResponseData>>(json).Result : null;
            return r;
        }
    }

    [JsonObject]
    public class MakeIntegratedAddressRequestData
    {
        [JsonProperty("payment_id")]
        public string PaymentId { get; set; } = string.Empty;
    }

    [JsonObject]
    public class MakeIntegratedAddressResponseData
    {
        [JsonProperty("integrated_address")]
        public string IntegratedAddress { get; set; } = null;
    }
}