using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nerva.Rpc.Daemon
{
    public class SetBans : Request<SetBansRequestData, string>
    {
        public SetBans(SetBansRequestData rpcData, Action<string> completeAction, Action<RequestError> failedAction, uint port = 13895)
            : base (rpcData, completeAction, failedAction, port) { }
            
        protected override bool DoRequest(out string result)
        {
            bool r = JsonRpcRequest("set_bans", rpcData, out result);
            return r;
        }
    }

    [JsonObject]
    public class SetBansRequestData
    {
        [JsonProperty("bans")]
        public List<Ban> Bans { get; set; }
    }

    [JsonObject]
    public class Ban
    {
        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("ban")]
        public bool Banned { get; set; } = true;

        [JsonProperty("seconds")]
        public int Seconds => 6000;

    }
}