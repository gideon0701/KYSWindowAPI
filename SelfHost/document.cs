//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SelfHost
{
    using System;
    using System.Collections.Generic;
    
    public partial class document
    {
        public int id { get; set; }
        public Nullable<int> doctype_id { get; set; }
        public Nullable<int> linked_company_id { get; set; }
        public string doc_path { get; set; }
    
        public virtual company company { get; set; }
        public virtual doctype doctype { get; set; }
    }
}
