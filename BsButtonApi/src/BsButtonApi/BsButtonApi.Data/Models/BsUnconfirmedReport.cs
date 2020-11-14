using System;
using System.Collections.Generic;
using System.Text;

namespace BsButtonApi.Data.Models
{
    public class BsUnconfirmedReport
    {
        public int ReportId { get; set; }

        public Guid ReportGuid { get; set; }

        //public string ReporterUserName { get; set; }

        public string ReportedName { get; set; }

        public BsSource Source { get; set; }

        public DateTime ReportedDateTime { get; set; }

        public string ReportReason { get; set; }

        public string ReportText { get; set; }
    }
}
