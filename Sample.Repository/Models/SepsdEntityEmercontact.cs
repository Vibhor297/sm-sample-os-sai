﻿using System;
using System.Collections.Generic;

namespace Sample.Repository.Models
{
    public partial class SepsdEntityEmercontact
    {
        public decimal AutoId { get; set; }
        public decimal EmercontactRecNo { get; set; }
        public string Guid { get; set; }
        public string Author { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime? ExtractStartTime { get; set; }
        public DateTime? ExtractEndTime { get; set; }
        public string LastOperation { get; set; }
        public decimal Deleted { get; set; }
        public decimal Resynced { get; set; }
        public decimal ErrorCount { get; set; }
        public string ErrorType { get; set; }
        public DateTime? LastErrorDatetime { get; set; }
        public string ErrorMessage { get; set; }
    }
}
