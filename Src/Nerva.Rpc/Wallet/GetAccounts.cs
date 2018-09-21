using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Nerva.Rpc.Wallet
{
    public class GetAccounts : RpcRequest<object, GetAccountsResponseData>
    {
        public GetAccounts (Action<GetAccountsResponseData> completeAction, Action failedAction, uint port = 17566)
            : base (null, completeAction, failedAction, port) { }
            
        protected override bool DoRequest(out GetAccountsResponseData result)
        {
            string rpc = null;
            bool r = BasicRequest("get_accounts", null, out rpc);
            result = r ? JsonConvert.DeserializeObject<JsonResponse<GetAccountsResponseData>>(rpc).Result : null;

            return r;
        }
    }

    [JsonObject]
    public class GetAccountsResponseData
    {
        [JsonProperty("subaddress_accounts")]
        public List<SubAddressAccount> Accounts { get; set; }

        [JsonProperty("total_balance")]
        public ulong TotalBalance { get; set; }

        [JsonProperty("total_unlocked_balance")]
        public ulong TotalUnlockedBalance { get; set; }
    }

    [JsonObject]
    public class SubAddressAccount
    {
        [JsonProperty("account_index")]
        public uint Index { get; set; }

        [JsonProperty("balance")]
        public ulong Balance { get; set; }

        [JsonProperty("base_address")]
        public string BaseAddress { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("unlocked_balance")]
        public ulong UnlockedBalance { get; set; }
    }
}