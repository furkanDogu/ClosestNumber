using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazılımYapımı2
{
    public class Number
    {             
        public Number creator1;
        public Number creator2;      
        public string structure;
        public int value;
        

        public Number(Number creator1, Number creator2, String structure)
        {
            this.creator1 = creator1;
            this.creator2 = creator2;
            this.structure = structure;
        }    
        
            
            
        


    }
}
