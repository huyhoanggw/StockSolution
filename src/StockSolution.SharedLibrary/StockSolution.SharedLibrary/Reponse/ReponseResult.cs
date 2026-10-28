using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.Reponse
{
    public class ReponseResult<T>
    {
        public bool Flag { get; set; }
        public string Message { get; set; }
        public T Object { get; set; }
        public ReponseResult()
        {

        }
        public ReponseResult(bool Flag, T Object, string Message = null)
        {
            this.Flag = Flag;
            this.Message = Message;
            this.Object = Object;
        }
        public ReponseResult(bool Flag, string Message = null)
        {
            this.Flag = Flag;
            this.Message = Message;
        }
    }
}
