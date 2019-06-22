using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPChat.Models
{
    public class PPChatSessionSettings : IPPChatSessionSettings
    {
        public string HttpOnly { get; set; }
        public string IdleTimeout { get; set; }
        public string IsEssential { get; set; }
        public string Name { get; set; }
        public string SessionKeyUser { get; set; }

        public TimeSpan IdleTimeoutInTimeSpan { get => TimeSpan.FromSeconds( Double.Parse(IdleTimeout));}
        public bool HttpOnlyBoolean { get => Convert.ToBoolean(HttpOnly); }
        public bool IsEssentialBoolean { get => Convert.ToBoolean(HttpOnly); }
    }

    public interface IPPChatSessionSettings
    {
        string HttpOnly { get; set; }
        string IdleTimeout { get; set; }
        string IsEssential { get; set; }
        string Name { get; set; }
        string SessionKeyUser { get; set; }

        TimeSpan IdleTimeoutInTimeSpan { get;}
        bool HttpOnlyBoolean { get; }
        bool IsEssentialBoolean { get; }
    }
}
