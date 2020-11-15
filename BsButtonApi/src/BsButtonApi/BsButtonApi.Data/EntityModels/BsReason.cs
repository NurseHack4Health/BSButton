using System;

namespace BsButtonApi.Data.EntityModels
{
    public class BsReason
    {
        public int ReasonId { get; set; }

        public Guid ReasonGuid { get; set; }

        public BsReasonCode ReasonCode { get; set; }

        public int ReasonCodeId{ get; set; }

        public string ReasonText { get; set; }
    }
}
