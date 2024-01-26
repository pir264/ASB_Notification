using System.Text.Json.Serialization;

namespace ASB_Notification
{
    internal class NotificationMessage
    {
        [JsonPropertyName("title")]
        public string Subject { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
        public DateTime EnqueueDateTime { get; set; }
    }
}
