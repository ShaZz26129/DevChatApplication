using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class PostScheduleResponse
    {
        public int? Result { get; set; }
        public int? Status { get; set; }
        public object Message { get; set; }
    }
}
