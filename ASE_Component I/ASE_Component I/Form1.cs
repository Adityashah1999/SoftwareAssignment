﻿using System;
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
    /// Form1 contains all the components like buttons
    /// panel text field and all
    /// </summary>
    public partial class Form1 : Form
    {

        public int positionXaxis = 0;
        public int positionYaxis = 0;
        string[] shapes = {"drawto", "moveto", "rectangle", "circle","triangle"};
        public bool draw = false;
        public bool load = false;
        bool method = false;
        public bool save = false;
        public bool execute = false;
        public bool clear_bool = false;

        List<String[]> n = new List<String[]>();
        List<String> body = new List<string>();
        List<String> b = new List<String>();
        List<int> p = new List<int>();
        List<String> pi = new List<String>();


        public bool reset_bool = false;
        public int lineCount = 1;
        public int lineNumberCount = 0;
        public int IfCounter = 0;
        public Dictionary<string, string> variableDict = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this methods takes two parameters x and y which when given values
        /// acts as another origin which is taken refrence for any drawing of
        /// shapes formerly the values of x and y are (0,0) 
        /// </summary>
        /// <param name="x">x co ordinate of origin</param>
        /// <param name="y">y co ordinate of origin</param>
        public void pentomove(int x, int y)
        {
            Pen pen_move = new Pen(Color.Black, 2);
            positionXaxis = x;
            positionYaxis = y;




        }

        public void suj(String[] m_syntax)
        {
            if (string.Compare(m_syntax[0].ToLower(), "moveto") == 0)
            {
                String[] parameter1 = m_syntax[1].Split(',');
                if (parameter1.Length != 2)
                    throw new Exception("MoveTo Takes Only 2 Parameters");
                else if (!parameter1[parameter1.Length - 1].Contains(')'))
                    throw new Exception(" " + "Missing Paranthesis!!");
                else
                {
                    String[] parameter2 = parameter1[1].Split(')');
                    String one = parameter1[0];
                    String two = parameter2[0];
                    pentomove(int.Parse(one), int.Parse(two));
                    if (parameter1.Length > 1 && parameter1.Length < 3)
                        pentomove(int.Parse(one), int.Parse(two));
                    else
                        throw new ArgumentException("MoveTo takes Only 2 Parameters");

                }
            }
            else if (m_syntax[0].Equals("\n"))
            {

            }
            //executes if "drawto" command is triggered
            else if (string.Compare(m_syntax[0].ToLower(), "drawto") == 0)
            {

                String[] parameter1 = m_syntax[1].Split(',');
                if (parameter1.Length != 2)
                    throw new Exception("DrawTo Takes Only 2 Parameters");
                else if (!parameter1[parameter1.Length - 1].Contains(')'))
                    throw new Exception(" " + "Missing Paranthesis!!");
                else
                {
                    String[] parameter2 = parameter1[1].Split(')');
                    String one = parameter1[0];
                    String two = parameter2[0];
                    pentodraw(int.Parse(one), int.Parse(two));
                    if (parameter1.Length == 2)
                        pentodraw(int.Parse(one), int.Parse(two));

                    else
                    {
                        throw new ArgumentException("DrawTo Takes Only 2 Parameters");
                    }
                }

            }
            //executes if "clear()" command is triggered
            else if (string.Compare(m_syntax[0].ToLower(), "clear") == 0)
            {
                clear();
            }
            //executes if "reset()" command is triggered
            else if (string.Compare(m_syntax[0].ToLower(), "reset") == 0)
            {
                reset();
            }
            //executes if "rectangle" command is triggered
            else if (string.Compare(m_syntax[0].ToLower(), "rectangle") == 0)
            {
                String[] parameter1 = m_syntax[1].Split(',');
                if (parameter1.Length != 2)
                    throw new Exception("Rectangle Takes Only 2 Parameters");
                else if (!parameter1[parameter1.Length - 1].Contains(')'))
                    throw new Exception(" " + "Missing Paranthesis!!");
                else
                {
                    String[] parameter2 = parameter1[1].Split(')');
                    String one = parameter1[0];
                    String two = parameter2[0];
                    if (parameter1.Length > 1 && parameter1.Length < 3)
                        rectangle_draw(positionXaxis, positionYaxis, int.Parse(one), int.Parse(two));
                    else
                        throw new ArgumentException("Rectangle Takes Only 2 Parameters");
                }
            }
            //executes if "circle" command is triggered
            else if (string.Compare(m_syntax[0].ToLower(), "circle") == 0)
            {
                String test = m_syntax[1];
                String[] parameter2 = m_syntax[1].Split(')');
                if (!test.Contains(')'))
                    throw new Exception(" " + "Missing Paranthesis!!");
                else
                {
                    String two = parameter2[0];
                    if (two != null || two != "" || two != " ")
                        circle_draw(positionXaxis, positionYaxis, int.Parse(two));
                    else
                        throw new ArgumentException("Circle Takes Only 1 Parameter");

                }
            }
            //executes if "triangle" command is triggered
            else if (string.Compare(m_syntax[0].ToLower(), "triangle") == 0)
            {
                String[] parameter1 = m_syntax[1].Split(',');
                if (parameter1.Length != 2)
                    throw new Exception("Triangle Takes Only 2 Parameters");
                else if (!parameter1[parameter1.Length - 1].Contains(')'))
                    throw new Exception(" " + "Missing Paranthesis!!");
                else
                {
                    String[] parameter2 = parameter1[1].Split(')');
                    String one = parameter1[0];
                    String two = parameter2[0];
                    if (parameter1.Length > 1 && parameter1.Length < 3)
                        triangle_draw(positionXaxis, positionYaxis, int.Parse(one), int.Parse(two));
                    else
                        throw new ArgumentException("Triangle Takes Only 2 Parameters");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// method to draw a line from (positionXaxis,positionYaxis) to 
        /// given points (a,b)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void pentodraw(int a, int b)
        {
            Pen mew = new Pen(Color.Black, 2);
            Graphics g = panel1.CreateGraphics();
            g.DrawLine(mew, positionXaxis, positionYaxis, a, b);
            positionXaxis = a;
            positionYaxis = b;
        }
        /// <summary>
        /// takes every line of the command and checks for the shape names 
        /// if it is in array shapes.
        /// </summary>
        /// <param name="line">line of command stored after each loop </param>
        /// <returns></returns>
        public bool checkCommand(string line)
        {
            for (int a = 0; a < shapes.Length; a++)
            {
                if (line.Contains(shapes[a]))
                {
                   

                    return true;
                }
            }
            String[] temp = line.Split('(');
            if (b.Contains(temp[0])) {
                return true;
            }
            return false;
        }

        /// <summary>
        ///methods which becomes active as soon as Execute button is pressed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button2_Click(object sender, EventArgs e)
        {
            variableDict.Clear();
            method = false;

            lineCount = 1;
            panel1.Refresh();
            textBox1.Clear();
            execute = false;
            var multi_command = textBox2.Text;
            string[] multi_syntax = multi_command.Split(new char[] { '\n'}, StringSplitOptions.RemoveEmptyEntries);

            foreach(string l in multi_syntax) 
            {


                    bool result = caseRun(l);
                if (!result)
                {
                    panel1.Invalidate();
                    break;
                }


                lineCount++;

            }

               

        }

            public bool caseRun(string line)
            {
                line = line.ToLower().Trim();



            if (IfCounter != 0)
            {
                IfCounter--;
                return true;

            }

            if (lineNumberCount != 0)
            {
                
                lineNumberCount--;

                return true;
            }

            else if (checkCommand(line))
            {

                string[] m_syntax = line.Split(new char[] { '(' }, StringSplitOptions.RemoveEmptyEntries);
                if (!runShape(m_syntax, line))
                    return false;


            }
            else if(checkVariableDec(line)){
                try
                {
                    string[] variableDeclration = line.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    string key = variableDeclration[0];
                    string value = variableDeclration[1];
                   

                    variableDict.Add(key,value);

                 

                }
                catch (Exception e)
                {
                    textBox1.Text = "Line: " + lineCount + " Invalid Declaration of variable";
                    return false;
                }


            }else if (checkIfElse(line))
            {
                bool endIfCheck = false;
                bool conditionStatus = false;
                string conditionOperator = "";
                try
                {

                    string[] IfCondtionParameter = getIfParameter(line);

                    foreach(string c in IfCondtionParameter){
                        Console.WriteLine(c);
                    }


                    if (!variableDict.ContainsKey(IfCondtionParameter[0].Trim().ToLower()))
                    {
                        textBox1.Text = "Line: " + lineCount + " Variable doesn't exist";
                        return false;
                    }


                    string condValueString = IfCondtionParameter[1];
                    int condValue = Int32.Parse(condValueString);




                   string v = IfCondtionParameter[0].Trim().ToLower();
                    string varValuestring = variableDict[v];
                    int varvalue = Int32.Parse(varValuestring);

                    if (line.Contains("="))
                    {
                        conditionOperator = "=";

                    }else if (line.Contains("<"))
                    {
                        conditionOperator = "<";
                    }
                    else if (line.Contains(">"))
                    {
                        conditionOperator = ">";
                    }


                   


                    var multi_command = textBox2.Text;
                    string[] multi_syntax = multi_command.Split(new char[] { '\n' },StringSplitOptions.RemoveEmptyEntries);

                    foreach (string l in multi_syntax)
                    {

                        if(l.ToLower().Trim() == "endif")
                        {
                            endIfCheck = true;
                            break;
                        }
                       
                    }
                    if (!endIfCheck)
                    {
                        textBox1.Text = "Line: " + lineCount + " If EndIf statement not closed.";
                        return false;
                    }


                    if(conditionOperator == "=")
                    {
                        if(varvalue == condValue)
                        {
                            conditionStatus = true;
                        }
                    }else if( conditionOperator == "<"){


                        if(varvalue < condValue)
                        {
                            conditionStatus = true;
                        }
                    }else if (conditionOperator == ">")
                    {
                        if (varvalue > condValue)
                        {
                            conditionStatus = true;
                        }
                    }
                    for (int i = lineCount; i < multi_syntax.Length; i++)
                    {
                        if(multi_syntax[i] == "endif")
                        {
                            break;
                        }
                        else
                        {
                            IfCounter++;
                        }
                    }

                        if (conditionStatus)
                    {
                        IfCounter = 0;
                    }

                    }
                catch (Exception e)
                {
                    textBox1.Text = "Line: " + lineCount + " Invalid if else statement" +"\n" + e.Message;
                    return false;
                }






            }else if(line=="endif"){
                return true;
            }
            else if(checkVariableOperation(line)){



                //check variable operation
                string[] variable = line.Split(new char[] { '+','-' }, 2, StringSplitOptions.RemoveEmptyEntries);
                string variableOperator = "";

                if (line.Contains("+"))
                {
                    variableOperator = "+";

                }else
                {
                    variableOperator = "-";
                }
                string realKey = variable[0];
                int realValue=Int32.Parse(variable[1]);
                int dictValue = Int32.Parse(variableDict[realKey]);
                if (!variableDict.ContainsKey(realKey))
                {
                    textBox1.Text = "Line: " + lineCount + " Variable doesn't Exist";
                    return false;
                }


                if(variableOperator == "+")
                {
                    variableDict[realKey] = (dictValue + realValue).ToString();
                }
                else
                {
                    variableDict[realKey] = (dictValue - realValue).ToString();
                }
         
            }
            else if (checkLoop(line))
            {

                bool endloopCheck = false;
                try
                {
                    string[] loop = line.Split(new string[] { "for" }, 2, StringSplitOptions.RemoveEmptyEntries);

                    string loopCondition = loop[1].Trim();

                    string[] loopVariable = loopCondition.Split(new string[] { "<=",">=" }, 2, StringSplitOptions.RemoveEmptyEntries);

                    foreach(string l in loopVariable)
                    {
                        Console.WriteLine(l);
                    }

                    foreach(KeyValuePair<string,string> k in variableDict)
                    {
                        Console.WriteLine(k.Key +"=" +k.Value);
                    }
                    int loopValue = Int32.Parse(loopVariable[1].Trim()) ;
                    string loopKey = loopVariable[0].Trim();
                    Console.WriteLine(loopKey);
                    if (!variableDict.ContainsKey(loopKey))
                    {
                        textBox1.Text = "Line: " + lineCount + " Variable doesn't exist 2";
                        return false;
                    }


                    var multi_command = textBox2.Text;
                    string[] multi_syntax = multi_command.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string l in multi_syntax)
                    {

                        if (l.ToLower().Trim() == "endloop")
                        {
                            endloopCheck = true;
                            break;
                        }

                    }
                    if (!endloopCheck)
                    {
                        textBox1.Text = "Line: " + lineCount + " loop not closed.";
                        return false;
                    }


                    //endloop check

                   
                    
                    int counterLine = 0;
                    int lineNumberCount1 = 0;

                    List<string> loopList = new List<string>();
                    for (int i = lineCount; i < multi_syntax.Length; i++)
                    {
                       
                        if (multi_syntax[i] == "endloop")
                        {

                            break;
                        }
                        else
                        {
                            lineNumberCount1++;
                            loopList.Add(multi_syntax[i]);
                        }
                    }



                    int dictValue = 0;
                    string loopOperator = "";
                    counterLine = lineCount;

                    if (line.Contains("<="))
                    {
                        loopOperator = "<=";
                    }
                    else
                    {
                        loopOperator = ">=";
                    }


                    if (loopOperator == "<=")
                    {
                        while (dictValue <= loopValue)
                        {
                            lineCount = counterLine;
                            foreach (string list in loopList)
                            {
                                lineCount++;
                                if (!caseRun(list))
                                    return false;
                            }
                            dictValue = Int32.Parse(variableDict[loopKey]);
                        }
                    }
                    else
                    {

                        while (dictValue >= loopValue)
                        {
                            lineCount = counterLine;
                            foreach (string list in loopList)
                            {
                                lineCount++;
                                if (!caseRun(list))
                                    return false;
                            }
                            dictValue = Int32.Parse(variableDict[loopKey]);
                        }
                    }

                    lineCount = counterLine;
                    lineNumberCount = lineNumberCount1;
                }
                catch (Exception e)
                {
                    textBox1.Text = "Line: " + lineCount + " Invaild Loop Statement + \n " + e.Message;
                    return false;
                }

            }
            else if(line=="endloop"){
                return true;
            }else if (checkMethod(line))
            {
                bool endMethodCheck = false;
                var multi_command = textBox2.Text;
                string[] multi_syntax = multi_command.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = lineCount; i < multi_syntax.Length; i++)
                {

                    if (multi_syntax[i] == "endmethod")
                    {
                        endMethodCheck = true;
                        break;
                    }
                   
                }

                if (!endMethodCheck)
                {
                    textBox1.Text = "Line: " + lineCount + "Method not closed" ;
                    return false;
                }



                    String[] area = multi_command.Split('\n');
                    String snj1 = "";
                    String snj2 = "";

                
                    for (int i = 0; i < area.Length; i++)
                    {
                        if (area[i].ToLower().Contains("method"))
                        {
                            
                            String[] t = area[i].Split(' ');
                            String[] nn = t[t.Length - 1].Split('(');
                            if (nn[nn.Length - 1].Contains(','))
                            {
                                String[] g = nn[nn.Length - 1].Split(',');
                                p.Add(g.Length);
                                for (int x = 0; x < g.Length; x++)
                                {
                                    if (x == g.Length - 1)
                                    {
                                        String[] tt = g[x].Split(')');
                                        snj2 = snj2 + tt[0] + "\n";
                                    }
                                    else
                                    {
                                        snj2 = snj2 + g[x] + "\n";
                                    }
                                }
                                pi.Add(snj2);
                            }
                            else
                            {
                                String[] g = nn[nn.Length - 1].Split(')');
                                if (g[0] == " " || g[0] == null || g[0] == "")
                                {
                                    p.Add(0);
                                    pi.Add(" ");
                                }
                                else
                                {
                                    p.Add(1);
                                    snj2 = snj2 + g[0] + "\n";
                                    pi.Add(snj2);
                                }
                            }
                            b.Add(nn[0].ToLower());
                            
                        }
                        else
                        {
                            snj1 = snj1 + area[i] + "\n";
                        }
                    }
                   
                body.Add(snj1);
                    n.Add(snj1.Split('\n'));
                    method = true;


            }else if (line == "endmethod")
            {

            }
            else
            {
                textBox1.Text = "Line: " +lineCount+" Command doesn't Exist";
                return false;
            }


                return true;
            }

        public bool checkLoop(string line)
        {
            if (line.StartsWith("loop"))
                return true;

            return false;

        }
        public string[] getIfParameter(string line)
        {

            int start = line.IndexOf("(") + 1;
            int end = line.IndexOf(")", start);

            string result = line.Substring(start, end - start);
            string[] parameterList = result.Split(new Char[] { '>','<','=' },2,StringSplitOptions.RemoveEmptyEntries);

            return parameterList;


        }
        public bool checkVariableOperation(string line)
        {
            if (line.Contains("+") || line.Contains("-"))
            {
                return true;
            }
            return false;
        }

        public string[] getParameter(string line)
        {

            int start = line.IndexOf("(") + 1;
            int end = line.IndexOf(")", start);

            string result = line.Substring(start, end - start);
            string[] parameterList = result.Split(new Char[] { ','}, 2, StringSplitOptions.RemoveEmptyEntries);

            return parameterList;


        }

        public bool checkIfElse(string line)
        {
            if (line.StartsWith("if"))
            {
                return true;
            }
            return false;
        }
        public bool checkMethod(string line)
        {
            if (line.StartsWith("method"))
            {
                return true;
            }
            return false;
        }
        public bool checkVariableDec(string line)
        {
            if (line.Contains("=") && !line.StartsWith("if") && !line.StartsWith("method") && !line.StartsWith("loop"))
            {
                return true;
            }
            return false;
        }

        public bool withVariable(string[] lines)
        {
            string line = "(" + lines[1];
            string[] parameters = getParameter(line);

            foreach (string param in parameters)
            {
                Console.WriteLine(param);
            }
                bool variableCheck = false;

            foreach(string param in parameters)
            {
                bool isNumeric = int.TryParse(param, out _);

                if (!isNumeric)
                {
                    variableCheck = true;
                    if (!variableDict.ContainsKey(param))
                    {
                        return false;
                    }
                    else
                    {
                       line= line.Replace(param, variableDict[param]);
                    }
                }
            }



            if (!variableCheck)
                return false;

            line = lines[0] + line;
            Console.WriteLine(line);
            caseRun(line);
          

            return true;
        }
        public bool runShape(string[] m_syntax, String line)
        {
           
            if (!method)
            {
                if (withVariable(m_syntax))
                {
                    return true;

                }
            }


            try
            {
                
                if (!method)
                {
                    if (b.Contains(m_syntax[0].ToLower()))
                    {
                        String mina = line;
                       
                        String mino = mina.Split('(')[0].Trim();
                        if (b.Contains(mino.Trim()))
                        {
                            int count = 0;
                            String[] l = mina.Split('(');
                            List<int> van = new List<int>();
                            if (l[l.Length - 1].Contains(','))
                            {
                                String[] alex = l[l.Length - 1].Split(',');
                                count = alex.Length;
                                for (int q = 0; q < alex.Length; q++)
                                {
                                    if (q != alex.Length - 1)
                                    {
                                        van.Add(int.Parse(alex[q]));
                                    }
                                    else
                                    {
                                        String[] fabin = alex[q].Split(')');
                                       
                                        if (fabin[0] != "" && fabin[0] != " " && fabin[0] == null)
                                            van.Add(int.Parse(fabin[0]));
                                        else
                                            van.Add(int.Parse(fabin[0]));
                                    }
                                }
                               
                                for (int k = 0; k < van.Count(); k++) {
                                   
                                }
                            }
                            else
                            {
                                String[] g = l[l.Length - 1].Split(')');
                                if (g[0] == " " || g[0] == null || g[0] == "")
                                {
                                    count = 0;
                                }
                                else
                                {
                                    van.Add(int.Parse(g[0]));
                                    count = 1;
                                }
                            }
                            if (count == p[b.IndexOf(mino.Trim())])
                            {
                                String[] rob = body[b.IndexOf(mino.Trim())].Split('\n');
                                String son = pi[b.IndexOf(mino.Trim())];

                                for (int salah = 0; salah < rob.Length; salah++)
                                {
                                    if (!string.IsNullOrEmpty(rob[salah]))
                                    {
                                        if (son == " ")
                                        {
                                           
                                            caseRun(rob[salah]); 
                                        }
                                        else
                                        {
                                            String[] io = son.Split('\n');
                                            for (int ui = 0; ui < io.Length; ui++)
                                            {
                                                if (!string.IsNullOrEmpty(io[ui]))
                                                {
                                                    if (rob[salah].Contains(io[ui].Trim()))
                                                    {
                                                        
                                                        rob[salah] = rob[salah].Replace(io[ui].Trim(), van[ui].ToString());
                                                       
                                                    }
                                                }
                                                else {
                                                    caseRun(rob[salah]);
                                                }
                                            }
                                           
                                            caseRun(rob[salah]);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Parameter Doesn't Match");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Not Found");
                        }
                    }
                    //executes if "moveto" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "moveto") == 0)
                    {
                        String[] parameter1 = m_syntax[1].Split(',');
                        if (parameter1.Length != 2)
                            throw new Exception("MoveTo Takes Only 2 Parameters");
                        else if (!parameter1[parameter1.Length - 1].Contains(')'))
                            throw new Exception(" " + "Missing Paranthesis!!");
                        else
                        {
                            String[] parameter2 = parameter1[1].Split(')');
                            String one = parameter1[0];
                            String two = parameter2[0];
                            pentomove(int.Parse(one), int.Parse(two));
                            if (parameter1.Length > 1 && parameter1.Length < 3)
                                pentomove(int.Parse(one), int.Parse(two));
                            else
                                throw new ArgumentException("MoveTo takes Only 2 Parameters");

                        }
                    }
                    else if (m_syntax[0].Equals("\n"))
                    {

                    }
                    //executes if "drawto" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "drawto") == 0)
                    {

                        String[] parameter1 = m_syntax[1].Split(',');
                        if (parameter1.Length != 2)
                            throw new Exception("DrawTo Takes Only 2 Parameters");
                        else if (!parameter1[parameter1.Length - 1].Contains(')'))
                            throw new Exception(" " + "Missing Paranthesis!!");
                        else
                        {
                            String[] parameter2 = parameter1[1].Split(')');
                            String one = parameter1[0];
                            String two = parameter2[0];
                            pentodraw(int.Parse(one), int.Parse(two));
                            if (parameter1.Length == 2)
                                pentodraw(int.Parse(one), int.Parse(two));

                            else
                            {
                                throw new ArgumentException("DrawTo Takes Only 2 Parameters");
                            }
                        }

                    }
                    //executes if "clear()" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "clear") == 0)
                    {
                        clear();
                    }
                    //executes if "reset()" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "reset") == 0)
                    {
                        reset();
                    }
                    //executes if "rectangle" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "rectangle") == 0)
                    {
                        String[] parameter1 = m_syntax[1].Split(',');
                        if (parameter1.Length != 2)
                            throw new Exception("Rectangle Takes Only 2 Parameters");
                        else if (!parameter1[parameter1.Length - 1].Contains(')'))
                            throw new Exception(" " + "Missing Paranthesis!!");
                        else
                        {
                            String[] parameter2 = parameter1[1].Split(')');
                            String one = parameter1[0];
                            String two = parameter2[0];
                            if (parameter1.Length > 1 && parameter1.Length < 3)
                                rectangle_draw(positionXaxis, positionYaxis, int.Parse(one), int.Parse(two));
                            else
                                throw new ArgumentException("Rectangle Takes Only 2 Parameters");
                        }
                    }
                    //executes if "circle" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "circle") == 0)
                    {
                        String test = m_syntax[1];
                        String[] parameter2 = m_syntax[1].Split(')');
                        if (!test.Contains(')'))
                            throw new Exception(" " + "Missing Paranthesis!!");
                        else
                        {
                            String two = parameter2[0];
                            if (two != null || two != "" || two != " ")
                                circle_draw(positionXaxis, positionYaxis, int.Parse(two));
                            else
                                throw new ArgumentException("Circle Takes Only 1 Parameter");

                        }
                    }
                    //executes if "triangle" command is triggered
                    else if (string.Compare(m_syntax[0].ToLower(), "triangle") == 0)
                    {
                        String[] parameter1 = m_syntax[1].Split(',');
                        if (parameter1.Length != 2)
                            throw new Exception("Triangle Takes Only 2 Parameters");
                        else if (!parameter1[parameter1.Length - 1].Contains(')'))
                            throw new Exception(" " + "Missing Paranthesis!!");
                        else
                        {
                            String[] parameter2 = parameter1[1].Split(')');
                            String one = parameter1[0];
                            String two = parameter2[0];
                            if (parameter1.Length > 1 && parameter1.Length < 3)
                                triangle_draw(positionXaxis, positionYaxis, int.Parse(one), int.Parse(two));
                            else
                                throw new ArgumentException("Triangle Takes Only 2 Parameters");
                        }
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (ArgumentException ecp)
            {
                textBox1.Text = "Error in Line:" + (lineCount ) + " " + ecp.Message;
                panel1.Refresh();
                return false;
            }

            catch (Exception ee)
            {
                textBox1.Text = "Error in Line:" + (lineCount) + " " + "parameter Error!!" + ee.Message;
                panel1.Refresh();
                return false;
            }
           
        }
        /// <summary>
        /// this method is trigerred when clear button is clicked.
        /// this clears text box as well as panel where drawing is 
        /// drawn
        /// </summary>
        public void clear()
        {
            clear_bool = false;
            panel1.Refresh();
            textBox2.Clear();
            clear_bool = true;
        }
        /// <summary>
        /// this button reset the point of reference or origin to (0,0)
        /// </summary>
        public void reset()
        {
            reset_bool = false;
            positionXaxis = 0;
            positionYaxis = 0;
            reset_bool = true;
        }
        /// <summary>
        /// the a and b is assigned as point of origin which is given (0,0)
        /// at first which can replaced using moveto command. the c and d is 
        /// given for the width and height of the rectangle. this method is to draw 
        /// rectangle.
        /// </summary>
        /// <param name="a">x co ordinate of origin</param>
        /// <param name="b">y co ordinate of origin</param>
        /// <param name="c">width of the rectangle</param>
        /// <param name="d">height of the rectangle</param>
        public void rectangle_draw(int a, int b,int c, int d )
        {
            draw = false;
            Rectangle mane = new Rectangle();
            mane.saved_values(a, b, c, d);
            Graphics g = panel1.CreateGraphics();
            mane.Draw_shape(g);
            draw = true;
        }
        /// <summary>
        /// the a and b is assigned as point of origin which is given (0,0)
        /// at first which can replaced using moveto command. the c is given to
        /// radius of circle.this is to draw circle
        /// </summary>
        /// <param name="a">x co ordinate of origin</param>
        /// <param name="b">y co ordinate of origin</param>
        /// <param name="c">radius of circle</param>
        public void circle_draw(int a, int b, int c)
        {
            draw = false;
            Circle mane2 = new Circle();
            mane2.saved_values(a, b, c);
            Graphics g = panel1.CreateGraphics();
            mane2.Draw_shape(g);
            draw = true;
        }
        
        public void triangle_draw(int a, int b, int c, int d)
        {
            draw = false;
            Triangle mane4 = new Triangle();
            mane4.saved_values(a, b, c, d);
            Graphics g = panel1.CreateGraphics();
            mane4.Draw_shape(g);
            draw = true;
        }

        /// <summary>
        /// triggered when reset button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button1_Click(object sender, EventArgs e)
        {
            reset();
        }
        /// <summary>
        /// triggered when clear button is clicked
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
        /// method to load a file which is created and saved before.
        /// </summary>
        /// <param name="sender">where event came from</param>
        /// <param name="e">what is in the event</param>
        public void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load= false;
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.Filter = "Text File (.txt)|*.txt";       
            loadFileDialog.Title = "Open File...";

            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader streamReader = new System.IO.StreamReader(loadFileDialog.FileName);
                textBox2.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
            load = true;
        }
        /// <summary>
        /// to save the file written in coding text box to the given drive with
        /// the given name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save = true;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (.txt)| *.txt";
            saveFileDialog.Title = "Save File...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fWriter = new StreamWriter(saveFileDialog.FileName);
                fWriter.Write(textBox2.Text);
                fWriter.Close();
                

            }
            save = true;

        }
        /// <summary>
        /// trigerrred when exit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// trigerrred when about button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
    