using System;

namespace BsButtonApi.Data.EntityModels
{
    public class BsSource
    {
        public int SourceId { get; set; }

        public Guid SourceGuid { get; set; }

        public string SourceUrl { get; set; }

        public BsSocialMediaSource SocialMediaSource { get; set; }

        public  int SocialMediaSourceId { get;set; }

    }
}