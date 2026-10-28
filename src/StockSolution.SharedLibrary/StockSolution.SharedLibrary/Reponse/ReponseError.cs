using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.Reponse
{
    public class ReponseError<T> : ReponseResult<T>
    {
        public ReponseError(string Message = null) : base(false, Message)
        {
        }
    }
}
