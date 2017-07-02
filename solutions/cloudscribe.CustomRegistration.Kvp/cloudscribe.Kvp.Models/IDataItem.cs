using System;

namespace cloudscribe.Kvp.Models
{
    public interface IDataItem
    {
        string Id { get; set; }
        string SetId { get; set; }
        string SubSetId { get; set; }
        string Key { get; set; }
        string Value { get; set; }
        string Custom1 { get; set; }
        string Custom2 { get; set; }
        DateTime CreatedUtc { get; set; }
    }
}