﻿using System;
using System.Collections.Generic;

namespace Sample.Repository.Models
{
    public partial class ORRoomType
    {
        public decimal ORRoomTypeRecordNo { get; set; }
        public string ORRoomTypeCode { get; set; }
        public string ORRoomTypeNm { get; set; }
        public string OasisXrefCode { get; set; }
        public string ReferenceDataTypeInd { get; set; }
        public string ActiveInd { get; set; }
        public string DefaultInd { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal OrgUnitRecordNo { get; set; }
        public decimal? ReportsToRecordNo { get; set; }
        public decimal? ReplacesRecordNo { get; set; }
        public decimal SequenceNo { get; set; }
        public decimal TransactionNo { get; set; }
    }
}
