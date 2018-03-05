using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazılımYapımı2
{
    public class Evaluation
    {
        public string elemanlar;
        private void writeValue(Number number)
        {
            if(number.structure!=null)
            {
                elemanlar += number.structure + Environment.NewLine;
            }
            
        }
        public void evaluate(Number number)
        {
            elemanlar = " ";
            postOrderInt(number);
        }
        private void postOrderInt(Number number)
        {
            if (number == null)
                return;
            postOrderInt(number.creator1);
            postOrderInt(number.creator2);
            writeValue(number);
        }
        
    }
}
