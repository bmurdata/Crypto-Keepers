//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel;
namespace cryptokeepers2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class alert
    {
        public int id { get; set; }
        public Nullable<byte> type { get; set; }
        [DisplayName("Wallet ID")]
        public string concern { get; set; }
        public Nullable<byte> flag { get; set; }
        public Nullable<byte> priority { get; set; }
        public Nullable<short> entity { get; set; }
        [DisplayName("Notes")]
        public string notes { get; set; }
        [DisplayName("Report Date")]
        public System.DateTime reported { get; set; }
        public Nullable<byte> coin { get; set; }
    
        public virtual coin coin1 { get; set; }
        public virtual entity entity1 { get; set; }
        public virtual flag flag1 { get; set; }
        public virtual priority priority1 { get; set; }
        public virtual type type1 { get; set; }
    }
}
