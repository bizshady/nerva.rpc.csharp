using System;
using Newtonsoft.Json;

namespace Nerva.Rpc.Wallet
{
    public class LabelAccount : RpcRequest<LabelAccountRequestData, string>
    {
        public LabelAccount (LabelAccountRequestData rpcData, Action<string> completeAction, Action<RequestError> failedAction, uint port = 17566)
            : base (rpcData, completeAction, failedAction, port) { }
            
        protected override bool DoRequest(out string result)
        {
            string json = null;
            bool r = BasicRequest("create_account", rpcData, out json);
            result = r ? JsonConvert.DeserializeObject<JsonResponse<string>>(json).Result : null;
            return r;
        }
    }

    [JsonObject]
    public class LabelAccountRequestData : CreateAccountRequestData
    {
        [JsonProperty("account_index")]
        public uint Index { get; set; } = 0;
    }
}