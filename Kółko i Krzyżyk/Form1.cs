using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kółko_i_Krzyżyk
{
    
    public partial class Kółko_I_Krzyżyk : Form
    {
        bool tura = true;
        int IlośćTur = 0;
        public Kółko_I_Krzyżyk()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (tura)
            {
                btn.Text = "X";
            }
            else
            {
                btn.Text = "O";
            }

            tura = !tura;
            btn.Enabled = false; //blokowanie przycisku już klikniętego
            IlośćTur++;
            Wygrana();
        }

        private void Wygrana()
        {
            bool zwycięsca = false;
            
            //Sprawdzanie w poziomie
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                zwycięsca = true;
            }
            else if ((B1.Text == B2.Text)&& (B2.Text == B3.Text) && (!B1.Enabled))
            {
                zwycięsca = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                zwycięsca = true;
            }
           
            //Sprawdzanie w pionie
            if (A1.Text == B1.Text && B1.Text == C1.Text && (!A1.Enabled))
            {
                zwycięsca = true;
            }
            else if (A2.Text == B2.Text && B2.Text == C2.Text && !A2.Enabled)
            {
                zwycięsca = true;
            }
            else if (A3.Text == B3.Text && B3.Text == C3.Text && !A3.Enabled)
            {
                zwycięsca = true;
            }

            //Sprawdzanie po ukośie 

            if (A1.Text == B2.Text && B2.Text == C3.Text && (!A1.Enabled))
            {
                zwycięsca = true;
            }
            else if (A3.Text == B2.Text && B2.Text == C1.Text && !A3.Enabled)
            {
                zwycięsca = true;
            }
          
            String wygrał = "";
            if (zwycięsca == true)
            {
                WyłączButton();

                if (tura == true)
                {
                    wygrał = "O";
                }
                else
                {
                    wygrał = "X";
                }

                MessageBox.Show("Wygrał gracz :" + wygrał, "Zwycięstwo!!");
            }
            else
            {
                if(IlośćTur == 9)
                {
                    MessageBox.Show("Nikt nie wygrał.Remis!!", "Remis!!");
                }

            }
        }
        private void WyłączButton()
        {
            A1.Enabled = false;
            
            try
            {
                foreach(Control c in Controls)
                {
                    Button btn = (Button)c;
                    btn.Enabled = false;

                }
            }
            catch  { }

        }

        private void nowaGraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tura = true;
            IlośćTur = 0;

            A1.Enabled = true;
            A1.Text = "";

            try
            {
                foreach (Control c in Controls)
                {
                    Button btn = (Button)c;
                    btn.Enabled = true;
                    btn.Text = "";

                }
            }
            catch { }
            
        }

        private void zamknijToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void zasadyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rozpoczyna gracz X", "Zasady");
        }

        private void oAutorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kółko i Krzyżyk v1.0 by Mateusz","O Autorze");
        }
    }


}
