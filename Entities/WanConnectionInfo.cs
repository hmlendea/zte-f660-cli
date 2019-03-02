using System;
using System.Collections.Generic;

namespace ZTEF660CLI.Entities
{
    public sealed class Stats
    {
        public string Type { get; set; }

        public string ConnectionName { get; set; }

        public string InternetProtocolVersion { get; set; }

        public bool HasNetworkAddressTranslation { get; set; }

        public string IpAddress { get; set; }

        public IEnumerable<string> DomainNameSystems { get; set; }

        public bool IsIpV4Connected { get; set; }

        public bool IsIpV6Connected { get; set; }

        public TimeSpan IpV4OnlineDuration { get; set; }

        public TimeSpan IpV6OnlineDuration { get; set; }

        public string DisconnectReason { get; set; }

        public string LLA { get; set; }

        public string GUA { get; set; }

        public string DNS { get; set; }

        public bool HasPrefixDelegation { get; set; }

        public string DelegatingPrefixAddress { get; set; }

        public string WanMacAddress { get; set; }
    }
}
