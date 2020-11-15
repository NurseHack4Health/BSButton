using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace BsButtonAsp.Models
{
    /// <summary>
    /// </summary>
    [DataContract]
    public class BsCreateViewModel
    {
        /// <summary>
        ///     Gets or Sets ReporterUserName
        /// </summary>
        [DataMember(Name = "reporterUserName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reporterUserName")]
        public string ReporterUserName { get; set; }

        /// <summary>
        ///     Gets or Sets ReportedNameOfPoster
        /// </summary>
        [DataMember(Name = "reportedNameOfPoster", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reportedNameOfPoster")]
        public string ReportedNameOfPoster { get; set; }

        /// <summary>
        ///     Gets or Sets ReportedFrom
        /// </summary>
        [DataMember(Name = "reportedFrom", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reportedFrom")]
        public string ReportedFrom { get; set; }

        /// <summary>
        ///     Gets or Sets ReportedDateTime
        /// </summary>
        [DataMember(Name = "reportedDateTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reportedDateTime")]
        public DateTime? ReportedDateTime { get; set; }

        /// <summary>
        ///     Gets or Sets ReportReasonCode
        /// </summary>
        [DataMember(Name = "reportReasonCode", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reportReasonCode")]
        public string ReportReasonCode { get; set; }

        /// <summary>
        ///     Gets or Sets ReportReason
        /// </summary>
        [DataMember(Name = "reportReason", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reportReason")]
        public string ReportReason { get; set; }

        /// <summary>
        ///     Gets or Sets ReportedFromUrl
        /// </summary>
        [DataMember(Name = "reportedFromUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reportedFromUrl")]
        public string ReportedFromUrl { get; set; }

        /// <summary>
        ///     Gets or Sets ReportText
        /// </summary>
        [DataMember(Name = "reportText", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reportText")]
        public string ReportText { get; set; }


        /// <summary>
        ///     Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BsCreateViewModel {\n");
            sb.Append("  ReporterUserName: ").Append(ReporterUserName).Append("\n");
            sb.Append("  ReportedNameOfPoster: ").Append(ReportedNameOfPoster).Append("\n");
            sb.Append("  ReportedFrom: ").Append(ReportedFrom).Append("\n");
            sb.Append("  ReportedDateTime: ").Append(ReportedDateTime).Append("\n");
            sb.Append("  ReportReasonCode: ").Append(ReportReasonCode).Append("\n");
            sb.Append("  ReportReason: ").Append(ReportReason).Append("\n");
            sb.Append("  ReportedFromUrl: ").Append(ReportedFromUrl).Append("\n");
            sb.Append("  ReportText: ").Append(ReportText).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}