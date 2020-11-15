using System;

namespace BsButtonApi.Service.ViewModels
{
    public class BsCreateViewModel
    {

        public string ReporterUserName { get; set; }

        public string ReportedNameOfPoster { get; set; }

        public string ReportedFrom { get; set; }

        public DateTime ReportedDateTime { get; set; }

        public string ReportReasonCode { get; set; }

        public string ReportReason { get; set; }

        public string ReportedFromUrl { get; set; }

        public string ReportText { get; set; }
    }
}