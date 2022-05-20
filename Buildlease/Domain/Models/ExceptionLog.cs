using System;

namespace Domain.Models
{
    public class ExceptionLog
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string SerializedException { get; set; }
    }
}
