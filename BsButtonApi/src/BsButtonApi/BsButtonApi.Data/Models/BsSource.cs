using System;

namespace BsButtonApi.Data.Models
{
    public class BsSource
    {

        public string Url { get; set; }
        public SocialMediaSourceEnum SocialMediaSource { get; set; }
        public int Id { get; set; }
        public Guid SourceGuid { get; set; }
    }
}