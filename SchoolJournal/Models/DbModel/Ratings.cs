//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolJournal.Models.DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ratings
    {
        public long id { get; set; }
        public long studentId { get; set; }
        public long columnId { get; set; }
        public byte[] value { get; set; }
    }
}
