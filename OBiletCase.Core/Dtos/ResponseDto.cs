using System.Text.Json.Serialization;

namespace OBiletCase.Core.Dtos
{
    public class ResponseDto<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }


        [JsonPropertyName("errors")]
        public string Errors { get; set; }
    }
}
