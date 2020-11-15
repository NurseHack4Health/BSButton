using System;

namespace BsButtonApi.Data.EntityModels
{
    public class BsUnconfirmedReport
    {
        public int UnconfirmedReportId { get; set; }

        public Guid ReportGuid { get; set; }

        public string ReporterUserName { get; set; }

        public string ReportedName { get; set; }

        public BsSource Source { get; set; }

        public int SourceId { get; set; }

        public DateTime ReportedDateTime { get; set; }

        public BsReason Reason { get; set; }

        public  int ReasonId { get; set; }

        public string ReportReason { get; set; }

        public string ReportText { get; set; }

        public string ReportedNameOfPoster { get; set; }
    }
}