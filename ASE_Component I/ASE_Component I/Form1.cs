using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace ASE_Component_I
{
    /// <summary>
    /// class form 1
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// position of axis
        /// </summary>
        public int positionXaxis = 0;
        /// <summary>
        /// position of axis
        /// </summary>
        public int positionYaxis = 0;
        /// <summary>
        /// initializing component
        /// </summary>

        public bool fill = false;
        Color colour = Color.Black;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  this is method to move pen
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void pentomove(int x, int y)
        {
            Pen pen_move = new Pen(Color.Black, 3);
            positionXaxis = x;
            positionYaxis = y;




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// this is method for drawing in pen
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void pentodraw(int a, int b)
        {
            Pen snj = new Pen(Color.Black, 3);
            Graphics g = panel1.CreateGraphics();
            g.DrawLine(snj, positionXaxis, positionYaxis, a, b);
            positionXaxis = a;
            positionYaxis = b;
        }
        /// <summary>
        /// action listener in button to pass the parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {


            var command = textBox1.Text;
            string[] multiLine = command.Split('\n');

            for (int i = 0; i < multiLine.Length - 1; i++)
            {
                String abc = multiLine[i].Trim();
                string[] syntax = abc.Split('(');
                try
                {

                    if (string.Compare(syntax[0].ToLower(), "moveto") == 0)
                    {
                        String[] parameter1 = syntax[1].Split(',');
                        String[] parameter2 = parameter1[1].Split(')');
                        String p1 = parameter1[0];
                        String p2 = parameter2[0];
                        pentomove(int.Parse(p1), int.Parse(p2));

                    }
                    else if (syntax[0].Equals("\n"))
                    {

                    }
                    else if (string.Compare(syntax[0].ToLower(), "drawto") == 0)
                    {
                        String[] parameter1 = syntax[1].Split(',');
                        String[] parameter2 = parameter1[1].Split(')');
                        String p1 = parameter1[0];
                        String p2 = parameter2[0];
                        pentodraw(int.Parse(p1), int.Parse(p2));
                    }

                    else if (string.Compare(syntax[0].ToLower(), "clear") == 0)
                    {
                        clear();
                    }

                    else if (string.Compare(syntax[0].ToLower(), "clear") == 0)
                    {
                        reset();
                    }

                    else if (string.Compare(syntax[0].ToLower(), "rectangle") == 0)
                    {
                        String[] parameter1 = syntax[1].Split(',');
                        String[] parameter2 = parameter1[1].Split(')');
                        String p1 = parameter1[0];
                        String p2 = parameter2[0];
                        rectangle_draw(positionXaxis, positionYaxis, int.Parse(p1), int.Parse(p2));
                    }
                    else if (string.Compare(syntax[0].ToLower(), "pen") == 0)
                    {
                        String[] parameter2 = syntax[1].Split(')');
                        String p2 = parameter2[0];

                        if (p2.ToLower().Equals("red"))
                            SetPenColor("red");
                        else if (p2.ToLower().Equals("black"))
                            SetPenColor("black");
                        else if (p2.ToLower().Equals("blue"))
                            SetPenColor("blue");
                        else if (p2.ToLower().Equals("lime"))
                            SetPenColor("lime");
                    }
                    else if (string.Compare(syntax[0].ToLower(), "fill") == 0)
                    {
                        String[] parameter2 = syntax[1].Split(')');
                        String p2 = parameter2[0];

                        if (p2.ToLower().Equals("on"))
                            this.fill = true;
                        else if (p2.ToLower().Equals("off"))
                            this.fill = false;

                    }
                    else if (string.Compare(syntax[0].ToLower(), "circle") == 0)
                    {
                        String[] parameter2 = syntax[1].Split(')');
                        String p2 = parameter2[0];
                        circle_draw(positionXaxis, positionYaxis, int.Parse(p2));
                    }

                    else if (string.Compare(syntax[0].ToLower(), "triangle") == 0)
                    {
                        String[] parameter1 = syntax[1].Split(',');
                        String[] parameter2 = parameter1[1].Split(',');
                        String p1 = parameter1[0];
                        String p2 = parameter2[0];
                        triangle_draw(positionXaxis, positionYaxis, int.Parse(p1), int.Parse(p2));
                    }
                    else if (string.Compare(syntax[0].ToLower(), "square") == 0)
                    {
                        String[] parameter2 = syntax[1].Split(')');

                        String p2 = parameter2[0];
                        square_draw(positionXaxis, positionYaxis, int.Parse(p2));
                    }

                    else
                    {
                        MessageBox.Show("The Syntax is invalid.on line" + (i + 1));
                        panel1.Refresh();
                        break;

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong parameter passed.");


                }
            }



        }
        /// <summary>
        /// clear button
        /// </summary>
        private void clear()
        {
            panel1.Refresh();
        }
        /// <summary>
        /// reset the coordinate to origin
        /// </summary>
        private void reset()
        {
            positionXaxis = 0;
            positionYaxis = 0;
        }
        /// <summary>
        /// defining length of rectangle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public void rectangle_draw(int a, int b, int c, int d)
        {
            Rectangle snj1 = new Rectangle();
            snj1.saved_values(a, b, c, d);
            Graphics g = panel1.CreateGraphics();
            snj1.Draw_shape(g, this.colour, this.fill);
        }

        public void square_draw(int a, int b, int d)
        {
            Square snj1 = new Square();
            snj1.saved_values(a, b, d);
            Graphics g = panel1.CreateGraphics();
            snj1.Draw_shape(g, this.colour, this.fill);
        }
        /// <summary>
        /// defining point of circle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void circle_draw(int a, int b, int c)
        {
            Circle snj2 = new Circle();
            snj2.saved_values(a, b, c);
            Graphics g = panel1.CreateGraphics();
            snj2.Draw_shape(g, colour, this.fill);
        }

        public void SetPenColor(String s)
        {
            this.colour = Color.FromName(s);
        }
        /// <summary>
        /// trianle_draw class to create object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public void triangle_draw(int x, int y, int z, int w)
        {
            Triangle tri = new Triangle();
            tri.saved_values(x, y, z, w);
            Graphics g = panel1.CreateGraphics();
            tri.Draw_shape(g, this.colour, this.fill);
        }
        /// <summary>
        /// reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }
        /// <summary>
        /// clear button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// save button while saving the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (.txt)| *.txt";
            saveFileDialog.Title = "Save File...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fWriter = new StreamWriter(saveFileDialog.FileName);
                fWriter.Write(textBox1.Text);
                fWriter.Close();
            }
            textBox1.Text += "Command Save";

        }
        /// <summary>
        /// load button to load the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.Filter = "Text File (.txt)|*.txt";
            loadFileDialog.Title = "Open File...";

            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader streamReader = new System.IO.StreamReader(loadFileDialog.FileName);
                textBox1.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdTextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String abc = cmdText.Text.Trim();
                string[] multiLine = abc.Split('\n');
                string[] syntax = abc.Split('(');
                try
                {

                    if (string.Compare(syntax[0].ToLower(), "moveto") == 0)
                    {
                        String[] parameter1 = syntax[1].Split(',');
                        String[] parameter2 = parameter1[1].Split(')');
                        String p1 = parameter1[0];
                        String p2 = parameter2[0];
                        pentomove(int.Parse(p1), int.Parse(p2));

                    }
                    else if (syntax[0].Equals("\n"))
                    {

                    }
                    else if (string.Compare(syntax[0].ToLower(), "drawto") == 0)
                    {
                        String[] parameter1 = syntax[1].Split(',');
                        String[] parameter2 = parameter1[1].Split(')');
                        String p1 = parameter1[0];
                        String p2 = parameter2[0];
                        pentodraw(int.Parse(p1), int.Parse(p2));
                    }

                    else if (string.Compare(syntax[0].ToLower(), "clear") == 0)
                    {
                        clear();
                    }

                    else if (string.Compare(syntax[0].ToLower(), "clear") == 0)
                    {
                        reset();
                    }

                    else if (string.Compare(syntax[0].ToLower(), "rectangle") == 0)
                    {
                        String[] parameter1 = syntax[1].Split(',');
                        String[] parameter2 = parameter1[1].Split(')');
                        String p1 = parameter1[0];
                        String p2 = parameter2[0];
                        rectangle_draw(positionXaxis, positionYaxis, int.Parse(p1), int.Parse(p2));
                    }
                    else if (string.Compare(syntax[0].ToLower(), "pen") == 0)
                    {
                        String[] parameter2 = syntax[1].Split(')');
                        String p2 = parameter2[0];

                        if (p2.ToLower().Equals("red"))
                            SetPenColor("red");
                        else if (p2.ToLower().Equals("black"))
                            SetPenColor("black");
                        else if (p2.ToLower().Equals("blue"))
                            SetPenColor("blue");
                        else if (p2.ToLower().Equals("lime"))
                            SetPenColor("lime");
                    }
                    else if (string.Compare(syntax[0].ToLower(), "fill") == 0)
                    {
                        String[] parameter2 = syntax[1].Split(')');
                        String p2 = parameter2[0];

                        if (p2.ToLower().Equals("on"))
                            this.fill = true;
                        else if (p2.ToLower().Equals("off"))
                            this.fill = false;

                    }
                    else if (string.Compare(syntax[0].ToLower(), "circle") == 0)
                    {
                        String[] parameter2 = syntax[1].Split(')');
                        String p2 = parameter2[0];
                        circle_draw(positionXaxis, positionYaxis, int.Parse(p2));
                    }

                    else if (string.Compare(syntax[0].ToLower(), "triangle") == 0)
                    {
                        String[] parameter1 = syntax[1].Split(',');
                        String[] parameter2 = parameter1[1].Split(',');
                        String p1 = parameter1[0];
                        String p2 = parameter2[0];
                        triangle_draw(positionXaxis, positionYaxis, int.Parse(p1), int.Parse(p2));
                    }
                    else if (string.Compare(syntax[0].ToLower(), "square") == 0)
                    {
                        String[] parameter2 = syntax[1].Split(')');

                        String p2 = parameter2[0];
                        square_draw(positionXaxis, positionYaxis, int.Parse(p2));
                    }

                    else
                    {
                        MessageBox.Show("The Syntax is invalid.on line");
                        panel1.Refresh();
                        

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong parameter passed.");


                }

            }
        }
    }
}
    