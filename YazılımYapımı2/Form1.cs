using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazılımYapımı2
{
    public partial class Form1 : Form
    {
       
        Random myRandom = new Random();

        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
                                
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Number> randomNumbers = new List<Number>();
            
            Solver s = new Solver();
            for (int i = 0; i < 5; i++)
            {
                randomNumbers.Add(new Number(null, null, null));
                randomNumbers[i].value = myRandom.Next(1, 9);
            }
            Number twoDigit = new Number(null,null,null);
            twoDigit.value = myRandom.Next(1, 9) * 10;
            randomNumbers.Add(twoDigit);

            Number target = new Number(null, null, null);
            target.value = myRandom.Next(100, 999);

            string message = "Random tek basamaklı sayılar = " + randomNumbers[0].value + ", "
                + randomNumbers[1].value + ", "
                + randomNumbers[2].value + ", "
                + randomNumbers[3].value + ", "
                + randomNumbers[4].value + ", "
                + randomNumbers[5].value + Environment.NewLine + Environment.NewLine
                +"Random hedef = "+ target.value+Environment.NewLine + Environment.NewLine
                + "Bulunan ; "+ Environment.NewLine + Environment.NewLine +s.letsPlay(randomNumbers, target);

            MessageBox.Show(message);

        }
    }
}
