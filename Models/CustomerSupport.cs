//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EasyFly.com.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerSupport
    {
        public string S_UserID { get; set; }
        public string C_UserID { get; set; }
        public string UserAdminConvo { get; set; }
    
        public virtual CompanyLog CompanyLog { get; set; }
        public virtual SingleUserLog SingleUserLog { get; set; }
    }
}
