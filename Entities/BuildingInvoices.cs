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
    
    public partial class BuildingInvoices
    {
        public int Id { get; set; }
        public int MainMeterId { get; set; }
        public double Amount { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
    
        public virtual MainMeters MainMeters { get; set; }
    }
}
