using System;

namespace Models
{
    ///本类用于记录系统操作
    public partial class SystemLog
    {
        public SystemLog() { }
        public SystemLog(string action, string executor)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Action = action;
            this.Executor = executor;

        }

        public string Id { get; set; }

        public string Action { get; set; }

        public string Executor { get; set; }

        public DateTime SystemTime { get; set; }
    }
}