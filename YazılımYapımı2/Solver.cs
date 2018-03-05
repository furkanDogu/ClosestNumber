using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazılımYapımı2
{
    public class Solver
    {
        char[] operations = { '+', '-', '*', '/' };
        public List<Number> results = new List<Number>();
        Number target;
        bool checkIfFound = false;
        
        public void solve(List<Number> array, Number target)
        {
            
            if (array.Count > 1)
            {

                for (int i = 0; i < array.Count; i++)
                {
                    for (int j = 0; j < array.Count; j++)
                    {
                        if (i != j)
                        {
                            for (int k = 0; k < operations.Length; k++)
                            {
                                makeOperation(array[i], array[j], operations[k], array, target);
                            }
                        }

                    }

                }
            }
            else return;
        }
        private List<Number> changeList(List<Number> temp, Number newValue, Number old1, Number old2, char Ooperator)
        {
            List<Number> newList = new List<Number>(temp);
            newList.Remove(old1);
            newList.Remove(old2);
            newList.Add(newValue);
            return newList;
        }
        private void makeOperation(Number x, Number y, char o, List<Number> temp, Number target)
        {
            if(!checkIfFound)
            {
                switch (o)
                {
                    case '+':
                        if (x.value + y.value > 0 && x.value + y.value > x.value && x.value + y.value > y.value)
                        {
                            string structure = "(" + x.value + "+" + y.value + ")" + "= " + (x.value + y.value);
                            Number tempNumber = new Number(x, y, structure);
                            tempNumber.value = x.value + y.value;
                            if (Math.Abs(target.value - (x.value + y.value)) < 10)
                            {                              
                                this.addToResultList(tempNumber);
                                break;
                            }
                            solve(changeList(temp, (tempNumber), x, y, o), target);
                        }
                        break;
                    case '-':
                        if (x.value > y.value)
                        {
                            string structure = "(" + x.value + "-" + y.value + ")" + "= " + (x.value - y.value);
                            Number tempNumber = new Number(x, y, structure);
                            tempNumber.value = x.value - y.value;
                            if (Math.Abs(target.value - (x.value - y.value)) < 10)
                            {                               
                                this.addToResultList(tempNumber);
                                break;
                            }
                            solve(changeList(temp, (tempNumber), x, y, o), target);
                        }
                        break;

                    case '*':
                        if (x.value * y.value > 0 && x.value * y.value > x.value && x.value * y.value > y.value)
                        {
                            string structure = "(" + x.value + "*" + y.value + ")" + "= " + x.value * y.value;
                            Number tempNumber = new Number(x, y, structure);
                            tempNumber.value = x.value * y.value;
                            if (Math.Abs(target.value - (x.value * y.value)) < 10)
                            {                              
                                this.addToResultList(tempNumber);
                                break;
                            }
                            solve(changeList(temp, (tempNumber), x, y, o), target);
                        }
                        break;
                    case '/':
                        if (y.value != 0 && x.value % y.value == 0)
                        {
                            string structure = "(" + x.value + "/" + y.value + ")" + "= " + x.value / y.value;
                            Number tempNumber = new Number(x, y, structure);
                            tempNumber.value = x.value / y.value;
                            if (Math.Abs(target.value - (x.value / y.value)) < 10)
                            {                               
                                this.addToResultList(tempNumber);
                                break;
                            }
                            solve(changeList(temp, (tempNumber), x, y, o), target);
                            break;
                        }
                        break;
                }
            }                   
        }
        public string letsPlay(List<Number>array, Number target)
        {
            this.target = target;
            Evaluation ev = new Evaluation();
            String final = "";
            Number wanted = null;

            solve(array, target);
            if (results.Count != 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i].value == target.value)
                    {
                        wanted = results[i];
                        break;
                    }
                    
                }

                if (wanted == null)
                    wanted = results[0];

                ev.evaluate(wanted);
                final = ev.elemanlar;


            }
            else
                final = " Hedef değere +9 / -9 fark ile ulaşılamadı";
            
            return final;
        }
        public void addToResultList(Number number)
        {
            if (number.value == target.value)
                checkIfFound = true;
            results.Add(number);
        }

    }
}
