using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Common
{
    //枚举：
    public enum ResultStatus
    {
        Error = -1,
        Success = 1
    }

    public class OperateResult
    {
        public ResultStatus ResultStatus { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public OperateResult(ResultStatus resultStatus, string msg)
        {
            this.ResultStatus = resultStatus;
            this.Message = msg;
        }

        public OperateResult(ResultStatus resultStatus,string msg,object data)
        {
            this.ResultStatus = resultStatus;
            this.Message = msg;
            this.Data = data;
        }

    }
}
