using System.Media;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        //declaracion global
        int sec = 0;
        int min = 0;
        string op;
        double op1, op2, res;
        bool start = true;
        SoundPlayer reproductor ;

        /*
        1 diseño calculadora
        2 tu foto 5seg y luego se oculta
        3 visor de tiempo de uso:min
        4 logo
        5 voces en ingles
         */
        public Form1()
        {
            InitializeComponent();
            reproductor = new SoundPlayer();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer de cuando llega a 60 segundos aumenta 1 en los minutos
            sec++;
            if (sec == 60) {
                min++;
                sec = 0;
            }
            labelT.Text = sec.ToString();
            labelS.Text = min.ToString();

            if (sec == 5){
                this.pictureBox1.Visible = false;
            }

        }

        private void btclick(object sender, EventArgs e)
        {
            if (start)
            {
                TextBoxScreen.Text = "0";
                start = false;
            }

            Button bt = (Button)sender;
            if (TextBoxScreen.Text == "0") TextBoxScreen.Text = "";

            if(bt.Text == "." && TextBoxScreen.Text.Contains("."))
            {
                TextBoxScreen.Text += "";
            }
            else
            {
                TextBoxScreen.Text += bt.Text;
            }

            sound(bt.Text);
        
        }


            //MessageBox.Show(bt.Text);
           

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            op2 = Convert.ToDouble(TextBoxScreen.Text);
            switch (op)
            {
                case "+": res = op1 + op2;
                   
                    break;
                case "-":
                    res = op1 - op2;
                    
                    break;
                case "X":
                    res = op1 * op2;

                    break;
                case "/":
                    res = op1 / op2;
                    
                    break;
                case "%":
                    res = op1 * op2 / 100;

                    break;
                case "C":
                    res = 0;
                    break;
            }
            sound(ButtonEqual.Text);
            TextBoxScreen.Text = res.ToString();
            start = true;
        }

        private void ButtonCE_Click(object sender, EventArgs e)
        {
            TextBoxScreen.Clear();
            sound(ButtonCE.Text);
        }


        private void ButtonDEL_Click(object sender, EventArgs e)
        {
            if (TextBoxScreen.Text.Length == 1)
                TextBoxScreen.Text = "";
            else
                TextBoxScreen.Text = TextBoxScreen.Text.Substring(0, TextBoxScreen.Text.Length - 1);
            sound(ButtonDEL.Text);
        }

        private void ButtonLOG_Click(object sender, EventArgs e)
        {
            //double ilog =Double.Parse(TextBoxScreen.Text);
            //ilog = Math.Log(ilog);
            //TextBoxScreen.Text = System.Convert.ToString(ilog);
            //Double.Parse(TextBoxScreen.Text);

            //Math.Log(Convert.ToDouble(TextBoxScreen.Text));

            op1 = double.Parse(TextBoxScreen.Text);
            res = op1;
            TextBoxScreen.Text = Math.Log(op1).ToString();
            sound(ButtonLOG.Text);
        }

        private void ButtonPI_Click(object sender, EventArgs e)
        {
            TextBoxScreen.Text = Convert.ToString(Math.PI);
            sound(ButtonPI.Text);

        }

        private void ButtonRaiz_Click(object sender, EventArgs e)
        {
            
            op1=double.Parse(TextBoxScreen.Text);
            res = op1;
            TextBoxScreen.Text=Math.Sqrt(op1).ToString();
            sound(ButtonRaiz.Text);
        }

        private void ButtonPotencia_Click(object sender, EventArgs e)
        {
            op1 = double.Parse(TextBoxScreen.Text);
            res = op1;
            TextBoxScreen.Text = Math.Pow(op1,2).ToString();
            sound(ButtonPotencia.Text);
        }

        private void ButtonPotenciaCubo_Click(object sender, EventArgs e)
        {
            op1 = double.Parse(TextBoxScreen.Text);
            res = op1;
            TextBoxScreen.Text = Math.Pow(op1, 3).ToString();
            sound(ButtonPotenciaCubo.Text);
        }

        private void OperationsClick(object sender, EventArgs e)
        {
                Button button = (Button)sender;
                op = button.Text;
                op1 = Convert.ToDouble(TextBoxScreen.Text);
                TextBoxScreen.Text = "0";
                sound(button.Text);
        }
        private void sound (string s)
        {
            try
            {//try 
                if (s == "/") s = "div";
                if (s == "DEL") s = "DEL";
                if (s == "^2") s = "^2";
                if (s == "^3") s = "^3";
                if (s == "PI") s = "PI";
                if (s == "√") s = "ROOT";
                if(s == "LOG") s = "LOG";
                if (s == ".") s = "P";
                reproductor.SoundLocation = "Sonidos\\" + s + ".wav";
                reproductor.Play();

            }catch(Exception ex) //else
            {
                
            }

        }
        
    }
}