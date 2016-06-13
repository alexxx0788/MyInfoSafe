using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALayer.API.Model
{
    public class Result
    {
        public Result()
        {
            Code = 1;
            Message = "success";
        }
        public Result(int pCode, string pMessage)
        {
            Code = pCode;
            Message = pMessage;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
