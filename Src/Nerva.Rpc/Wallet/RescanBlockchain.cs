using System;

namespace Nerva.Rpc.Wallet
{
    public class RescanBlockchain : Request<object, string>
    {
        public RescanBlockchain(Action<string> completeAction, Action<RequestError> failedAction, uint port = 13895)
            : base (null, completeAction, failedAction, port) { }

        protected override bool DoRequest(out string result) => JsonRpcRequest("rescan_blockchain", null, out result);

    }
}