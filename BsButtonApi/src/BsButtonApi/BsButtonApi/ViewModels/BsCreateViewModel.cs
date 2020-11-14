using System;

namespace BsButtonApi.ViewModels
{
    public class BsCreateViewModel
    {
        public int ReportId { get; set; }

        public Guid ReportGuid { get; set; }

        public string ReporterUserName { get; set; }

        public string ReportedName { get; set; }

        public string ReportedFrom { get; set; }

        public DateTime ReportedDateTime { get; set; }

        public string ReportReason { get; set; }

        public string ReportText { get; set; }
    }
}