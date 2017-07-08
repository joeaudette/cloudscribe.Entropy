using System;
using System.Collections.Generic;
using System.Text;

namespace cloudscribe.Kvp.Models
{
    public class KvpItem : IKvpItem
    {
        public string Id { get; set; }
        public string SetId { get; set; }
        public string SubSetId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public DateTime CreatedUtc { get; set; }


    }
}
