//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoices
    {
        public int Id { get; set; }
        public int ReadingId { get; set; }
        public double Amount { get; set; }
        public System.DateTime Deadline { get; set; }
        public bool Paid { get; set; }
        public string Description { get; set; }
    
        public virtual Readings Readings { get; set; }
    }
}
