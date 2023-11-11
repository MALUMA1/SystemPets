namespace SysPet.Services
{
    // Services/ToastrService.cs

    using System.Collections.Generic;

    public class ToastrService
    {
        public List<ToastrMessage> ToastrList { get; private set; } = new List<ToastrMessage>();

        public void AddToQueue(string type, string message, string title = null)
        {
            ToastrList.Add(new ToastrMessage
            {
                Type = type,
                Message = message,
                Title = title
            });
        }
    }

    public class ToastrMessage
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
    }
}
