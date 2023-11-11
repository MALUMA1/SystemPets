using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace SysPet.Extensions
{
    public static class ToastrExtensions
    {
        public static void AddToastrMessage(this ITempDataDictionary tempData, string message, string title = "Notificación", ToastrMessageType type = ToastrMessageType.Success)
        {
            var messages = tempData.ContainsKey("ToastrMessages")
                ? JsonConvert.DeserializeObject<ToastrMessages>(tempData["ToastrMessages"].ToString())
                : new ToastrMessages();

            messages.ToastrList.Add(new ToastrItem
            {
                Message = message,
                Title = title,
                Type = type.ToString().ToLower()
            });

            tempData["ToastrMessages"] = JsonConvert.SerializeObject(messages);
        }
    }

    public class ToastrMessages
    {
        public List<ToastrItem> ToastrList { get; set; } = new List<ToastrItem>();
    }

    public class ToastrItem
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }

    public enum ToastrMessageType
    {
        Success,
        Error,
        Warning,
        Info
    }
}
