using System;

namespace BsButtonApi.Data.EntityModels
{
    public class BsReasonCode
    {
        public int ReasonCodeId { get; set; }

        public Guid ReasonCodeGuid { get; set; }

        public string ReasonCode { get; set; }

        public string ReasonCodeText { get; set; }
        //Other, 
        //Fake, 
        //Unconfirmed, 
        //Suspicious


    }
}
