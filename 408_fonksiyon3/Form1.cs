using System.Collections.Generic;

namespace _408_fonksiyon3
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> soru_cevap= new Dictionary<string, int>();

            string textFile = "questions.txt";
            string[] lines = File.ReadAllLines(textFile);
            int size_of_lines = 0;
            foreach (var s in lines)
                size_of_lines++;


            for (int index = 0;index<size_of_lines; index++)
            {
                if (index % 2 == 0)
                {
                    soru_cevap.Add(lines[index], 0);
                }

                if (index % 2 == 1)
                {
                    soru_cevap[lines[index - 1]] = Int32.Parse(lines[index]);
                }

            }

           
            richTextBox1.AppendText("\tPlayer1\tPlayer2\n");

            double puan1 = 0;
            double puan2 = 0;

            void cevap_takip(double cevap1, double cevap2, double gercek_cevap, string question, int answer)
            {
                richTextBox1.AppendText("Question is..." + question + "\nPlayer 1's Answer is:" + cevap1 + "\nPlayer 2's Answer is:" +cevap2 + "\nCorrect Answer is: " + answer + "\n");

                double fark_cevap1_gercek = Math.Abs(gercek_cevap - cevap1);
                double fark_cevap2_gercek = Math.Abs(gercek_cevap - cevap2);

                if (fark_cevap1_gercek > fark_cevap2_gercek)
                {
                    puan2++;
                    richTextBox1.AppendText("Winner of the round is Player2\n");
                }

                else if (fark_cevap1_gercek < fark_cevap2_gercek)
                {
                    puan1++;
                    richTextBox1.AppendText("Winner of the round is Player1\n");
                }

                else
                {
                    puan1 += 0.5;
                    puan2 += 0.5;
                    richTextBox1.AppendText("Tie\n");

                }

                richTextBox1.AppendText("Points:    " + puan1.ToString() + "\t" + puan2.ToString() + "\n");
            }

            int question_number = 11;
            int over = 0;
            // sizee_of_lines 22
            for(int i = 0; i < question_number*2; i+=2)
            {
                cevap_takip(3, 2, 15, lines[i], soru_cevap[lines[i]]);
                over++;
            }

            /*
            cevap_takip(3, 2, 15, lines[0], soru_cevap[lines[0]]);
            cevap_takip(6, 5, 15, lines[2], soru_cevap[lines[2]]);
            cevap_takip(4, 5, 15, lines[4], soru_cevap[lines[4]]);
            cevap_takip(6, 8, 15, lines[6], soru_cevap[lines[6]]);
            cevap_takip(6, 6, 15, lines[8], soru_cevap[lines[8]]);
            */


        }



        //   Dictionary f= new Dictionary { "x":5};
    }
    }
