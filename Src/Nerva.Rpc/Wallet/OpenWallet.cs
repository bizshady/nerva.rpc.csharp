using System;
using Newtonsoft.Json;

namespace Nerva.Rpc.Wallet
{
    public class OpenWallet : Request<OpenWalletRequestData, string>
    {
        public OpenWallet(OpenWalletRequestData rpcData, Action<string> completeAction, Action<RequestError> failedAction, uint port = 13895)
            : base (rpcData, completeAction, failedAction, port) { }
            
        protected override bool DoRequest(out string result) => JsonRpcRequest("open_wallet", rpcData, out result);
    }

    public class OpenWalletRequestData
    {
        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}