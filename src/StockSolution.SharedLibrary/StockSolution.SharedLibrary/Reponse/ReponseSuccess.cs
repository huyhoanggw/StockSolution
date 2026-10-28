using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.Reponse
{
    public class ReponseSuccess<T> : ReponseResult<T>
    {
        public ReponseSuccess(T Object, string Message = null) : base(true, Object, Message)
        {
        }
        public ReponseSuccess(string message = null) : base(true, message)
        {

        }
    }
}
