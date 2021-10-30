using Newtonsoft.Json;
using System.Collections.Generic;

namespace Suwahasa.Common.Models
{
    public class ErrorResponse
    {
        public IList<ErrorDto> Errors { get; set; } = new List<ErrorDto>();
    }

    public class ErrorDto
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FieldName { get; set; }

        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }
}
