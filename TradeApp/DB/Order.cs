//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TradeApp.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public int OrderProductID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> OrderPickupDate { get; set; }
        public int OrderPickupPointID { get; set; }
        public int UserID { get; set; }
        public int OrderPickupCode { get; set; }
        public int StatusID { get; set; }
    
        public virtual OrderProduct OrderProduct { get; set; }
        public virtual PickupPoint PickupPoint { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
    }
}
