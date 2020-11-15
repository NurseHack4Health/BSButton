using System;

namespace BsButtonApi.Data.EntityModels
{
    public class BsSocialMediaSource
    {
        public int SourceCodeId { get; set; }

        public Guid SourceCodeGuid { get; set; }

        public string SourceCodeName { get; set; }

        public string SourceCodeBaseUrl { get; set; }
        //Other,
        //Facebook, 
        //Twitter, 
        //Parler,
        //Tiktok
    }
}