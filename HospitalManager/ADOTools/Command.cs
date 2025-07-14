using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace ADOTools
{
    public sealed class Command
    {
        public string Request { get; set; }
        public Dictionary<string, object?> Parameters { get; set; } = new Dictionary<string, object?>();

        public Command(string request)
        {
            Request = request;
        }

        public void AddParameter(string name, object? value)
        {
            Parameters[name] = value;
        }
    }
}
