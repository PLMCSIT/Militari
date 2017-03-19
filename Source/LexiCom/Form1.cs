using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Lexical_Analyzer;
using Syntax_Analyzer;
using Semantics_Analyzer;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;
using System.Configuration;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Militari
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        string fname = "";
        string consolewrt = "";
        string function = "";
        string globdeclare = "";
        string main = "";

        public Form1()
        {
            InitializeComponent();
            this.buttonX12.Click += new System.EventHandler(this.buttonX12_Click);
            //this.button2.Click += new System.EventHandler(this.button1_Click);
        }

        int lines = 0;
        List<int> linetokens = new List<int>();
        LexicalAnalyzer lex = new LexicalAnalyzer();

        /*Literal List*/
        List<string> intlist = new List<string>();
        List<string> doublelist = new List<string>();
        List<string> stringlist = new List<string>();
        List<string> charlist = new List<string>();
        List<string> boolist = new List<string>();
        List<string> funclist = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Militari Solution";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "mltr";
            openFileDialog1.Filter = "Militari Solutions (*.mltr)|*.mltr|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fname = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(fname);
                Code.Text = sr.ReadToEnd();
                sr.Close();
            }

        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            if (Code != null)
            {
                DialogResult result = MessageBox.Show("Clear Code Workspace?",
                "Clearing Option",
                MessageBoxButtons.YesNo);
                if ((result == DialogResult.Yes) && (Code != null))
                {
                    Code.Clear();
                    MessageBox.Show("Cleared!");
                }
                else if (result == DialogResult.No) {
                    MessageBox.Show("No Changes");
                }
                else {
                    MessageBox.Show("Code Workspace is Empty!");
                }

            }
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (fname == "")
            {
                openFileDialog1.Filter = "Militari Files|*.mltr";
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.Cancel)
                {
                    return;
                }
                fname = openFileDialog1.FileName;
                MessageBox.Show(fname);
                StreamWriter sw = new StreamWriter(fname);
                sw.WriteLine(Code.Text);
                sw.Flush();
                sw.Close();
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.ShowDialog();
            fname = openFileDialog1.FileName;
            if (fname == "")
            {
                openFileDialog1.Filter = "Militari Files|*.mltr";
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.Cancel)
                {
                    return;
                }
                fname = openFileDialog1.FileName;
                MessageBox.Show(fname);
                StreamWriter sw = new StreamWriter(fname);
                sw.WriteLine(Code.Text);
                sw.Flush();
                sw.Close();
            }
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            Code.Cut();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            richTextBoxEx1.Text = null;
            consolewrt = "";
            globdeclare = "";
            main = "";
            lex = new LexicalAnalyzer();
            buttonX3.Enabled = false;
            if (Code.Text != "")
            {
                dataGridViewX1.Rows.Clear();
                dataGridViewX2.Rows.Clear();
                dataGridViewX3.Rows.Clear();
                lex = new LexicalAnalyzer();
                Initializer Lexical = new Initializer();
                string txt = Code.Text;
                lex = Lexical.InitializeAnalyzer(txt, lex);

                DisplayTokens(lex);
            }
            if (lex.invalid == 0 && lex.token.Count != 0)
            {
                buttonX3.Enabled = true;
            }
            else {
                buttonX3.Enabled = false;
                buttonX4.Enabled = false;
                dataGridViewX1.Show();
            }

        }

        private SemanticsInitializer SemanticsStart(List<SemanticsInitializer.Tokens> tokens)
        {
            SemanticsInitializer sem = null;
            try
            {
                sem = new SemanticsInitializer(tokens);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return sem;
        }

        public List<SemanticsInitializer.Tokens> tokenDumps(List<Tokens> tokens)
        {
            List<SemanticsInitializer.Tokens> token = new List<SemanticsInitializer.Tokens>();
            SemanticsInitializer.Tokens t = new SemanticsInitializer.Tokens();
            foreach (var item in tokens)
            {
                t = new SemanticsInitializer.Tokens();
                t.setAttributes(item.getAttributes());
                t.setLexemes(item.getLexemes());
                t.setLines(item.getLines());
                t.setTokens(item.getTokens());
                token.Add(t);
            }
            return token;
        }

        private void DisplayTokens(LexicalAnalyzer lex)
        {
            string result = "Successfully Executed.";
            int ctr = 0, id = 1;
            LexGrid.Rows.Clear();

            if (lex.invalid != 0)
                result = "Encountered " + lex.invalid.ToString() + " error/s.\nPlease try again.\n";
            dataGridViewX1.Rows.Add(id, "Lexical Analyzer " + result);

            foreach (var token in lex.token)
            {
                if (token.getTokens() == "INVALID")
                {
                    dataGridViewX1.Rows.Add(id, "Invalid input: "
                                + token.getLexemes()
                                , " on line "
                                + token.getLines() + "\n");
                }
                else if (token.getTokens() == "NODELIM")
                {
                    dataGridViewX1.Rows.Add(id, "Proper delimiter expected: "
                                + token.getLexemes()
                                , " on line "
                                + token.getLines() + "\n");
                }
                else
                {
                    id++;
                    LexGrid.Rows.Add(id, token.getLexemes(), token.getTokens(), token.getAttributes());
                }
                ctr++;
            }
        }

        private int GetErrorLine(int ctr)
        {
            int line = 0;
            int cls = 0;
            for (int i = 0; i < linetokens.Count; i++)
            {
                cls = linetokens[i];
                if (ctr + 1 <= linetokens[i])
                    return (i + 1);
            }
            return line;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            SyntaxInitializer S_initialize = new SyntaxInitializer();
            dataGridViewX2.Rows.Clear();
            dataGridViewX4.Rows.Clear();
            int i = 1;
            string s;
            s = S_initialize.Start(tokenDump(lex.token));

            if (s != "Syntax Analyzer Succeeded...")
            {
                int errornum = 1;
                dataGridViewX2.Rows.Clear();
                if (S_initialize.errors.getColumn() == 1)
                {
                    S_initialize.errors.setLines(S_initialize.errors.getLines() - 1);
                }
                dataGridViewX2.Rows.Add(errornum, S_initialize.errors.getErrorMessage(), S_initialize.errors.getLines());
                errornum++;
            }
            else
            {
                dataGridViewX2.Rows.Add(i, s);
                buttonX4.Enabled = true;
                dataGridViewX2.Show();
            }
        }

        public List<TokenLibrary.TokensClass> tokenDump(List<Lexical_Analyzer.Tokens> tokens)
        {
            List<TokenLibrary.TokensClass> token = new List<TokenLibrary.TokensClass>();
            Tokens t = new Tokens();
            foreach (var item in tokens)
            {
                t = new Tokens();
                t.setAttributes(item.getAttributes());
                t.setLexemes(item.getLexemes());
                t.setLines(item.getLines());
                t.setTokens(item.getTokens());
                token.Add(t);
            }
            return token;
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            List<string> ConstantvarList = new List<string>();
            List<string> GlobalvarList = new List<string>();
            List<string> LocalvarList = new List<string>();
            List<string> ReservedW = new List<string> { "company", "unit", "digit", "response", "joe", "hold", "miss", "operation", "struct",
                                                        "PrimaryMission", "post", "capture", "backup", "campaign", "abort", "deploy", "inquire",
                                                        "inorder", "otherorder","phase", "go", "order","action" };
            List<string> Operators = new List<string> { "+", "-", "*", "/", "=" };
            List<string> disp = new List<string>();

            bool constexists;
            bool globexists;
            bool locexists;
            int idn = 0;
            int Line = 1;
            int x = 0;

            ConstantvarList.Clear();
            GlobalvarList.Clear();
            LocalvarList.Clear();
            dataGridViewX3.Rows.Clear();
            for (x = 0; x < LexGrid.Rows.Count; x++)
            {

                /*Constant Semantics*/
                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "hold")
                {
                    x++;
                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit")
                    {
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            {
                                if (constexists = ConstantvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                {
                                    dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                                }
                                else {
                                    ConstantvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                    intlist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                }
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Numlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                            {
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit")
                            {
                            }
                            else {
                                dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                            }
                            x++;
                            if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";"))
                            {
                                Line++;
                            }
                        } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";"));
                    }
                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "digit")
                    {
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            {
                                if (constexists = ConstantvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                {
                                    dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                                }
                                else {
                                    ConstantvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                    doublelist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                }
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Declit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                            {
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "digit")
                            {
                            }
                            else {
                                dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                            }
                            x++;
                            if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";"))
                            {
                                Line++;
                            }
                        } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";"));
                    }
                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "company")
                    {
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            {
                                if (constexists = ConstantvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                {
                                    dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                                }
                                else {
                                    ConstantvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                    stringlist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                }
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Stringlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                            {
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "company")
                            {
                            }
                            else {
                                dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                            }
                            x++;
                            if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";"))
                            {
                                Line++;
                            }
                        } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";"));
                    }
                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "joe")
                    {
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            {
                                if (constexists = ConstantvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                {
                                    dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                                }
                                else {
                                    ConstantvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                    charlist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                }
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Charlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                            {
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "joe")
                            {
                            }
                            else {
                                dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                            }
                            x++;
                            if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";"))
                            {
                                Line++;
                            }
                        } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";"));
                    }
                }

                /*Global Semantics*/
                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit")
                {
                    do
                    {
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                        {
                            if (globexists = GlobalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                            {
                                dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                            }
                            else {
                                GlobalvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                intlist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            }
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Numlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                        {
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                        {
                            //x++;
                            //do
                            //{
                            //    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            //    {
                            //        funclist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            //        x++;
                            //    }
                            //} while (LexGrid.Rows[x].Cells[2].Value.ToString() != "(");
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                        {
                        }
                        else {
                            dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                        }
                        x++;
                        if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";") || (LexGrid.Rows[x].Cells[2].Value.ToString() == "{"))
                        {
                            Line++;
                        }
                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                }
                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "miss")
                {
                    x++;
                    do
                    {
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                        {
                            funclist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            x++;
                        }
                    } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "(");
                }

                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "digit")
                {
                    do
                    {
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                        {
                            if (globexists = GlobalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                            {
                                dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                            }
                            else {
                                GlobalvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                doublelist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            }
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Declit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                        {
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "digit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                        {
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                        {
                        }
                        else {
                            dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                        }
                        x++;
                        if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";") || (LexGrid.Rows[x].Cells[2].Value.ToString() == "{"))
                        {
                            Line++;
                        }
                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                }
                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "company")
                {
                    do
                    {
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                        {
                            if (globexists = GlobalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                            {
                                dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                            }
                            else {
                                GlobalvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                stringlist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            }
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Stringlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                        {
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "company" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                        {
                        }
                        else {
                            dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                        }
                        x++;
                        if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";") || (LexGrid.Rows[x].Cells[2].Value.ToString() == "{"))
                        {
                            Line++;
                        }
                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                }
                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "joe")
                {
                    do
                    {
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                        {
                            if (globexists = GlobalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                            {
                                dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                            }
                            else {
                                GlobalvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                charlist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            }
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Charlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                        {
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "joe" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                        {
                        }
                        else {
                            dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                        }
                        x++;
                        if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";") || (LexGrid.Rows[x].Cells[2].Value.ToString() == "{"))
                        {
                            Line++;
                        }
                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                }
                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "response")
                {
                    do
                    {
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                        {
                            if (globexists = GlobalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                            {
                                dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                            }
                            else {
                                GlobalvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                boolist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            }
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "AFFIRMATIVE" || LexGrid.Rows[x].Cells[2].Value.ToString() == "NEGATIVE" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                        {
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "response" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                        {
                        }
                        else {
                            dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                        }
                        x++;
                        if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";") || (LexGrid.Rows[x].Cells[2].Value.ToString() == "{"))
                        {
                            Line++;
                        }
                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                }

                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                {
                    bool exist;
                    if (exist = GlobalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == false) {
                        dataGridViewX3.Rows.Add(idn++, "Accessing undeclared Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString());
                    }
                    else if (exist = funclist.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == false)
                    {
                        dataGridViewX3.Rows.Add(idn++, "Accessing undeclared Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString());
                    }
                }
                else
                {

                }
                /*Local Declaration*/
                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "PrimaryMission")
                {
                    do
                    {
                        x++;
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "(") { }
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == ")") { }
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "{") { }
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit")
                        {
                            do
                            {
                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                                {
                                    if (locexists = LocalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                    {
                                        dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                                    }
                                    else {
                                        LocalvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                        intlist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                    }
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Numlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                                {
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                                {
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                                {
                                }
                                else {
                                    dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                                }
                                x++;
                                if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";") || (LexGrid.Rows[x].Cells[2].Value.ToString() == "{"))
                                {
                                    Line++;
                                }
                            } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                        }
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "digit")
                        {
                            do
                            {
                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                                {
                                    if (locexists = LocalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                    {
                                        dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                                    }
                                    else {
                                        LocalvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                        doublelist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                    }
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Declit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                                {
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "digit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                                {
                                }
                                else {
                                    dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                                }
                                x++;
                                if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";") || (LexGrid.Rows[x].Cells[2].Value.ToString() == "{"))
                                {
                                    Line++;
                                }
                            } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                        }
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "company")
                        {
                            do
                            {
                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                                {
                                    if (locexists = LocalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                    {
                                        dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                                    }
                                    else {
                                        LocalvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                        stringlist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                    }
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Stringlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                                {
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "company" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                                {
                                }
                                else {
                                    dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                                }
                                x++;
                                if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";") || (LexGrid.Rows[x].Cells[2].Value.ToString() == "{"))
                                {
                                    Line++;
                                }
                            } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                        }
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "joe")
                        {
                            do
                            {
                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                                {
                                    if (locexists = LocalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                    {
                                        dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                                    }
                                    else {
                                        LocalvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                        charlist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                    }
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Charlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                                {
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "joe" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                                {
                                }
                                else {
                                    dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                                }
                                x++;
                                if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";") || (LexGrid.Rows[x].Cells[2].Value.ToString() == "{"))
                                {
                                    Line++;
                                }
                            } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                        }
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "response")
                        {
                            do
                            {
                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                                {
                                    if (locexists = LocalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                    {
                                        dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                                    }
                                    else {
                                        LocalvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                        boolist.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                    }
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "AFFIRMATIVE" || LexGrid.Rows[x].Cells[2].Value.ToString() == "NEGATIVE" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";")
                                {
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "response" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                                {
                                }
                                else {
                                    dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                                }
                                x++;
                                if ((LexGrid.Rows[x].Cells[2].Value.ToString() == ";") || (LexGrid.Rows[x].Cells[2].Value.ToString() == "{"))
                                {
                                    Line++;
                                }
                            } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                        }
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "miss")
                        {
                            do
                            {
                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                                {
                                    if (locexists = LocalvarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                    {
                                        dataGridViewX3.Rows.Add(idn++, "Multiple declaration of variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), " Line: " + Line);
                                    }
                                    else {
                                        LocalvarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                    }
                                }
                                else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Stringlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Declit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Numlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Charlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "joe" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                                {
                                }
                                else {
                                    dataGridViewX3.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), " Line: " + Line);
                                }
                                x++;
                                if ((LexGrid.Rows[x].Cells[2].Value.ToString() == "{"))
                                {
                                    Line++;
                                }
                            } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                        }
                        else {
                            dataGridViewX3.Rows.Add(idn++, "Semantics Analyzer Succeeded...");
                        }

                        x++;

                    } while (LexGrid.Rows[x].Cells[2].Value.ToString() == "deploy");
                    // MessageBox.Show(x.ToString());
                }
                else
                {
                    continue;
                }
            }
            /*Check if Constant var Exist to Global var*/
            foreach (string constlist in ConstantvarList)
            {

                if (GlobalvarList.Contains(constlist) == true)
                {
                    dataGridViewX3.Rows.Add(idn++, "Multiple declaration of Global variable: " + constlist, " Line: " + Line);
                }
                if (LocalvarList.Contains(constlist) == true) {
                    dataGridViewX3.Rows.Add(idn++, "Multiple declaration of Local variable: " + constlist, " Line: " + Line);
                }
                if (ReservedW.Contains(constlist) == true)
                {
                    dataGridViewX3.Rows.Add(idn++, "Reserved Identifier Misused: " + constlist, " Line: " + Line);
                }
                else
                {
                    continue;
                }
            }
            foreach (string globallist in GlobalvarList)
            {

                if (LocalvarList.Contains(globallist) == true)
                {
                    dataGridViewX3.Rows.Add(idn++, "Multiple declaration of Local variable: " + globallist, " Line: " + Line);
                }
                if (ReservedW.Contains(globallist) == true)
                {
                    dataGridViewX3.Rows.Add(idn++, "Reserved Identifier Misused: " + globallist, " Line: " + Line);
                }
                else
                {
                    continue;
                }
            }
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            richTextBoxEx1.Text = "";
            int checktemp = 0;
            int checkfunc = 0;
            List<string> disp = new List<string>();
            List<string> outp = new List<string>();
            richTextBoxEx1.Text = "using System; \n namespace test \n { \n class test \n { \n ";
            //globdeclare = "public static class GlobalVar { \n";
            //main = "class funct \n { \n";
            //function = "class func \n { \n";
            for (int x = 0; x < LexGrid.Rows.Count; x++)
            {
                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "}")
                {
                    x++;
                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "deploy")
                    {
                        x += 2;
                        main += "Console.ReadLine(); \n } \n";
                    }
                    else
                    {
                        main += LexGrid.Rows[x - 1].Cells[1].Value.ToString() + " \n";
                        // x--;
                    }
                }
                switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                {
                    case "PrimaryMission":
                        x += 3;
                        main += "public static void Main() \n { \n";
                        checktemp = 1;
                        break;
                    case "unit":
                        //Check if Global unit
                        if (checktemp == 0 || checkfunc == 0)
                        {
                            if (LexGrid.Rows[x + 2].Cells[2].Value.ToString() == "(")
                            {
                                checkfunc = 1;
                                x++;
                                main += "public static int ";
                                do
                                {
                                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "digit")
                                    {
                                        main += "double ";
                                        x++;
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit")
                                    {
                                        main += "int ";
                                        x++;
                                        if ((LexGrid.Rows[x + 2].Cells[1].Value.ToString() == "[") && (LexGrid.Rows[x + 5].Cells[1].Value.ToString() == "["))
                                        {
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                            x++;
                                        }
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "joe")
                                    {
                                        main += "char ";
                                        x++;
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "company")
                                    {
                                        main += "string ";
                                        x++;
                                    }
                                    else
                                    {
                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                        x++;
                                    }
                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "{");
                                main += "{\n";
                                break;
                            }
                            if (checkfunc == 0 && checktemp == 0)
                            {
                                x++;
                                do
                                {
                                    switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                    {
                                        case "id":
                                            x++;
                                            if ((LexGrid.Rows[x].Cells[1].Value.ToString() == "[") && (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "["))
                                            {
                                                main += "public static int ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                                x += 6;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                                {
                                                    do
                                                    {
                                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                        x++;
                                                    } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                                                    main += "; \n";
                                                    // x += 2;
                                                }
                                                else
                                                {
                                                    main += "= new int[" + LexGrid.Rows[x - 5].Cells[1].Value.ToString() + "," + LexGrid.Rows[x - 2].Cells[1].Value.ToString();
                                                    main += "]; \n";
                                                }
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                            {
                                                main += "public static int ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString() + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                                x += 3;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                                {
                                                    do
                                                    {
                                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                        x++;
                                                    } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "}");
                                                    main += "}; \n";
                                                    x++;
                                                }
                                                else
                                                {
                                                    main += "= new int[" + LexGrid.Rows[x - 2].Cells[1].Value.ToString() + "]; \n";
                                                }
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "(")
                                            {
                                                main += "public static int ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{");
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                main += "public static int " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=" + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "; \n";
                                                x = x + 2;
                                            }
                                            else
                                            {
                                                main += "public static int " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "; \n";
                                            }
                                            break;
                                        case ",":
                                            x++;
                                            break;
                                    }
                                } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");
                            }
                            else
                            {
                                main += "int ";
                            }
                            break;
                        }
                        else
                        {
                            //Check if Local unit
                            x++;
                            do
                            {
                                switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                {
                                    case "id":
                                        x++;
                                        if ((LexGrid.Rows[x].Cells[1].Value.ToString() == "[") && (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "["))
                                        {
                                            main += "int ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                            x += 6;
                                            if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                                                main += "; \n";
                                                // x += 2;
                                            }
                                            else
                                            {
                                                main += "= new int[" + LexGrid.Rows[x - 5].Cells[1].Value.ToString() + "," + LexGrid.Rows[x - 2].Cells[1].Value.ToString();
                                                main += "]; \n";
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                        {
                                            main += "int ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString() + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                            x += 3;
                                            if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "}");
                                                main += "}; \n";
                                                x++;
                                            }
                                            else
                                            {
                                                main += "= new int[" + LexGrid.Rows[x - 2].Cells[1].Value.ToString() + "]; \n";
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "(")
                                        {
                                            main += "int ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                            do
                                            {
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                x++;
                                            } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{");
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                        {
                                            main += "int " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=" + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "; \n";
                                            x = x + 2;
                                        }
                                        else
                                        {
                                            main += "int " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "; \n";
                                        }
                                        break;
                                    case ",":
                                        x++;
                                        break;
                                }
                            } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");
                        }
                        break;


                    case "digit":
                        //Check if Global unit
                        if (checktemp == 0 || checkfunc == 0)
                        {
                            if (LexGrid.Rows[x + 2].Cells[2].Value.ToString() == "(")
                            {
                                checkfunc = 1;
                                x++;
                                main += "public static double ";
                                do
                                {
                                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "digit")
                                    {
                                        main += "double ";
                                        x++;
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit")
                                    {
                                        main += "int ";
                                        x++;
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "joe")
                                    {
                                        main += "char ";
                                        x++;
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "company")
                                    {
                                        main += "string ";
                                        x++;
                                    }
                                    else
                                    {
                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                        x++;
                                    }
                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "{");
                                main += "{\n";
                                break;
                            }
                            if (checkfunc == 0 && checktemp == 0)
                            {
                                x++;
                                do
                                {
                                    switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                    {
                                        case "id":
                                            x++;
                                            if ((LexGrid.Rows[x].Cells[1].Value.ToString() == "[") && (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "["))
                                            {
                                                main += "public static double ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                                x += 6;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                                {
                                                    do
                                                    {
                                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                        x++;
                                                    } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                                                    main += "; \n";
                                                    // x += 2;
                                                }
                                                else
                                                {
                                                    main += "= new double[" + LexGrid.Rows[x - 5].Cells[1].Value.ToString() + "," + LexGrid.Rows[x - 2].Cells[1].Value.ToString();
                                                    main += "]; \n";
                                                }
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                            {
                                                main += "public static double ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString() + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                                x += 3;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                                {
                                                    do
                                                    {
                                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                        x++;
                                                    } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "}");
                                                    main += "}; \n";
                                                    x++;
                                                }
                                                else
                                                {
                                                    main += "= new double[" + LexGrid.Rows[x - 2].Cells[1].Value.ToString() + "]; \n";
                                                }
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "(")
                                            {
                                                main += "public static double ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{");
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                main += "public static double " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=" + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "; \n";
                                                x = x + 2;
                                            }
                                            else
                                            {
                                                main += "public static double " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "; \n";
                                            }
                                            break;
                                        case ",":
                                            x++;
                                            break;
                                    }
                                } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");
                            }
                            else
                            {
                                main += "double ";
                            }
                            break;
                        }
                        else
                        {
                            //Check if Local unit
                            x++;
                            do
                            {
                                switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                {
                                    case "id":
                                        x++;
                                        if ((LexGrid.Rows[x].Cells[1].Value.ToString() == "[") && (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "["))
                                        {
                                            main += "double ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                            x += 6;
                                            if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                                                main += "; \n";
                                                // x += 2;
                                            }
                                            else
                                            {
                                                main += "= new double[" + LexGrid.Rows[x - 5].Cells[1].Value.ToString() + "," + LexGrid.Rows[x - 2].Cells[1].Value.ToString();
                                                main += "]; \n";
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                        {
                                            main += "int ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString() + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                            x += 3;
                                            if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "}");
                                                main += "}; \n";
                                                x++;
                                            }
                                            else
                                            {
                                                main += "= new double[" + LexGrid.Rows[x - 2].Cells[1].Value.ToString() + "]; \n";
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "(")
                                        {
                                            main += "double ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                            do
                                            {
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                x++;
                                            } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{");
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                        {
                                            main += "double " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=" + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "; \n";
                                            x = x + 2;
                                        }
                                        else
                                        {
                                            main += "double " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "; \n";
                                        }
                                        break;
                                    case ",":
                                        x++;
                                        break;
                                }
                            } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");
                        }
                        break;
                    //Check if Global Company  
                    case "company":
                        //Check if Global unit
                        if (checktemp == 0 || checkfunc == 0)
                        {
                            if (LexGrid.Rows[x + 2].Cells[2].Value.ToString() == "(")
                            {
                                checkfunc = 1;
                                x++;
                                main += "public static string ";
                                do
                                {
                                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "digit")
                                    {
                                        main += "double ";
                                        x++;
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit")
                                    {
                                        main += "int ";
                                        x++;
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "joe")
                                    {
                                        main += "char ";
                                        x++;
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "company")
                                    {
                                        main += "string ";
                                        x++;
                                    }
                                    else
                                    {
                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                        x++;
                                    }
                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "{");
                                main += "{\n";
                                break;
                            }
                            if (checkfunc == 0 && checktemp == 0)
                            {
                                x++;
                                do
                                {
                                    switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                    {
                                        case "id":
                                            x++;
                                            if ((LexGrid.Rows[x].Cells[1].Value.ToString() == "[") && (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "["))
                                            {
                                                main += "public static string ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                                x += 6;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                                {
                                                    do
                                                    {
                                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                        x++;
                                                    } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                                                    main += "; \n";
                                                    // x += 2;
                                                }
                                                else
                                                {
                                                    main += "= new string[" + LexGrid.Rows[x - 5].Cells[1].Value.ToString() + "," + LexGrid.Rows[x - 2].Cells[1].Value.ToString();
                                                    main += "]; \n";
                                                }
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                            {
                                                main += "public static string ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString() + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                                x += 3;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                                {
                                                    do
                                                    {
                                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                        x++;
                                                    } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "}");
                                                    main += "}; \n";
                                                    x++;
                                                }
                                                else
                                                {
                                                    main += "= new string[" + LexGrid.Rows[x - 2].Cells[1].Value.ToString() + "]; \n";
                                                }
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "(")
                                            {
                                                main += "public static string ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{");
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                main += "public static string " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=" + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "; \n";
                                                x = x + 2;
                                            }
                                            else
                                            {
                                                main += "public static string " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "; \n";
                                            }
                                            break;
                                        case ",":
                                            x++;
                                            break;
                                    }
                                } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");
                            }
                            else
                            {
                                main += "string ";
                            }
                            break;
                        }
                        else
                        {
                            //Check if Local unit
                            x++;
                            do
                            {
                                switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                {
                                    case "id":
                                        x++;
                                        if ((LexGrid.Rows[x].Cells[1].Value.ToString() == "[") && (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "["))
                                        {
                                            main += "string ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                            x += 6;
                                            if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                                                main += "; \n";
                                                // x += 2;
                                            }
                                            else
                                            {
                                                main += "= new string[" + LexGrid.Rows[x - 5].Cells[1].Value.ToString() + "," + LexGrid.Rows[x - 2].Cells[1].Value.ToString();
                                                main += "]; \n";
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                        {
                                            main += "int ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString() + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                            x += 3;
                                            if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "}");
                                                main += "}; \n";
                                                x++;
                                            }
                                            else
                                            {
                                                main += "= new string[" + LexGrid.Rows[x - 2].Cells[1].Value.ToString() + "]; \n";
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "(")
                                        {
                                            main += "string ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                            do
                                            {
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                x++;
                                            } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{");
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                        {
                                            main += "string " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=" + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "; \n";
                                            x = x + 2;
                                        }
                                        else
                                        {
                                            main += "string " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "; \n";
                                        }
                                        break;
                                    case ",":
                                        x++;
                                        break;
                                }
                            } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");
                        }
                        break;
                    case "joe":
                        //Check if global joe

                        if (checktemp == 0 || checkfunc == 0)
                        {
                            if (LexGrid.Rows[x + 2].Cells[2].Value.ToString() == "(")
                            {
                                checkfunc = 1;
                                x++;
                                main += "public static char ";
                                do
                                {
                                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "digit")
                                    {
                                        main += "double ";
                                        x++;
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit")
                                    {
                                        main += "int ";
                                        x++;
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "joe")
                                    {
                                        main += "char ";
                                        x++;
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "company")
                                    {
                                        main += "string ";
                                        x++;
                                    }
                                    else
                                    {
                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                        x++;
                                    }
                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "{");
                                main += "{\n";
                                break;
                            }
                            if (checkfunc == 0)
                            {
                                x++;
                                do
                                {
                                    switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                    {
                                        case "id":
                                            x++;
                                            if ((LexGrid.Rows[x].Cells[1].Value.ToString() == "[") && (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "["))
                                            {
                                                main += "public static char ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                                x += 6;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                                {
                                                    do
                                                    {
                                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                        x++;
                                                    } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                                                    main += "; \n";
                                                    // x += 2;
                                                }
                                                else
                                                {
                                                    main += "= new char[" + LexGrid.Rows[x - 5].Cells[1].Value.ToString() + "," + LexGrid.Rows[x - 2].Cells[1].Value.ToString();
                                                    main += "]; \n";
                                                }
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                            {
                                                main += "public static char ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString() + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                                x += 3;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                                {
                                                    do
                                                    {
                                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                        x++;
                                                    } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "}");
                                                    main += "}; \n";
                                                    x++;
                                                }
                                                else
                                                {
                                                    main += "= new char[" + LexGrid.Rows[x - 2].Cells[1].Value.ToString() + "]; \n";
                                                }
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "(")
                                            {
                                                main += "public static char ";
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{");
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                            }
                                            else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                main += "public static char " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=" + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "; \n";
                                                x = x + 2;
                                            }
                                            else
                                            {
                                                main += "public static char " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "; \n";
                                            }
                                            break;
                                        case ",":
                                            x++;
                                            break;
                                    }
                                } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");
                            }
                            else
                            {
                                main += "char ";
                            }
                            break;
                        }
                        else
                        {
                            //Check if Local unit
                            x++;
                            do
                            {
                                switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                {
                                    case "id":
                                        x++;
                                        if ((LexGrid.Rows[x].Cells[1].Value.ToString() == "[") && (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "["))
                                        {
                                            main += "char ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                            x += 6;
                                            if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                                                main += "; \n";
                                                // x += 2;
                                            }
                                            else
                                            {
                                                main += "= new char[" + LexGrid.Rows[x - 5].Cells[1].Value.ToString() + "," + LexGrid.Rows[x - 2].Cells[1].Value.ToString();
                                                main += "]; \n";
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                        {
                                            main += "char ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString() + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                            x += 3;
                                            if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                            {
                                                do
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                    x++;
                                                } while (LexGrid.Rows[x].Cells[1].Value.ToString() != "}");
                                                main += "}; \n";
                                                x++;
                                            }
                                            else
                                            {
                                                main += "= new char[" + LexGrid.Rows[x - 2].Cells[1].Value.ToString() + "]; \n";
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "(")
                                        {
                                            main += "char ";
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                            do
                                            {
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                x++;
                                            } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{");
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                        }
                                        else if (LexGrid.Rows[x].Cells[1].Value.ToString() == "=")
                                        {
                                            main += "char " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=" + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "; \n";
                                            x = x + 2;
                                        }
                                        else
                                        {
                                            main += "char " + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "; \n";
                                        }
                                        break;
                                    case ",":
                                        x++;
                                        break;
                                }
                            } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");
                        }
                        break;

                    case "response":
                        //Check if Global response
                        if (checktemp == 0)
                        {
                            x++;
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            {
                                main += "boolean ";
                                main += LexGrid.Rows[x].Cells[1].Value.ToString() + "=false; \n";
                            }
                            break;
                        }
                        //Check if local response
                        else
                        {
                            x++;
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            {
                                main += "boolean ";
                                main += LexGrid.Rows[x].Cells[1].Value.ToString() + "=false; \n";
                            }
                            break;
                        }
                    case "miss":
                        checkfunc = 1;
                        x++;
                        main += "public static void ";
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "digit")
                            {
                                main += "double ";
                                x++;
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit")
                            {
                                main += "int ";
                                x++;

                                if ((LexGrid.Rows[x].Cells[1].Value.ToString() == "[") && (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "["))
                                {
                                    main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + "]" + " " + LexGrid.Rows[x - 1].Cells[1].Value.ToString();
                                    x++;
                                }
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "joe")
                            {
                                main += "char ";
                                x++;
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "company")
                            {
                                main += "string ";
                                x++;
                            }
                            else
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                        } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{");
                        main += "\n" + LexGrid.Rows[x].Cells[1].Value.ToString() + "\n";
                        break;
                    case "struct":
                        int temp = 0;
                        main += "public struct ";
                        x++;
                        main += LexGrid.Rows[x].Cells[1].Value.ToString() + "{ \n";
                        x += 2;
                        do
                        {
                            if ((LexGrid.Rows[x].Cells[2].Value.ToString() == "}") && (LexGrid.Rows[x + 1].Cells[2].Value.ToString() == ";"))
                            {
                                temp = 1;
                                main += "};\n";
                                x++;

                            }
                            else
                            {
                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "unit")
                                {
                                    temp = 0;
                                    main += "public int ";

                                }
                                else
                                {
                                    temp = 0;
                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();

                                }
                            }
                        } while (temp != 0);
                        break;
                    case "capture":
                        x++;
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "(")
                        {
                            x++;
                            do
                            {
                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "#")
                                {
                                    x++;
                                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                                    {
                                        foreach (string a in intlist)
                                        {
                                            if (a == LexGrid.Rows[x].Cells[1].Value.ToString())
                                            {
                                                x++;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                                {
                                                    if (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "[")
                                                    {
                                                        x--;
                                                        do
                                                        {
                                                            switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                                            {
                                                                case "id":
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                                default:
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "," + LexGrid.Rows[x + 4].Cells[1].Value.ToString() + LexGrid.Rows[x + 5].Cells[1].Value.ToString();
                                                                    x = x + 5;
                                                                    break;
                                                            }
                                                            x++;
                                                        } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ")");

                                                        //main += "GlobalVar." + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + LexGrid.Rows[x + 2].Cells[1].Value.ToString();
                                                        main += " = Convert.ToInt32(Console.ReadLine()); \n";
                                                    }
                                                    else
                                                    {
                                                        x--;
                                                        do
                                                        {
                                                            switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                                            {
                                                                case "id":
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                                default:
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                            }
                                                            x++;
                                                        } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ")");

                                                        //main += "GlobalVar." + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + LexGrid.Rows[x + 2].Cells[1].Value.ToString();
                                                        main += " = Convert.ToInt32(Console.ReadLine()); \n";
                                                    }
                                                }
                                                else
                                                {
                                                    outp.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                                    main += LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=";
                                                    main += "Convert.ToInt32(Console.ReadLine()); \n";
                                                }
                                            }
                                        }
                                        foreach (string b in doublelist)
                                        {
                                            if (b == LexGrid.Rows[x].Cells[1].Value.ToString())
                                            {
                                                x++;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                                {
                                                    if (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "[")
                                                    {
                                                        x--;
                                                        do
                                                        {
                                                            switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                                            {
                                                                case "id":
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                                default:
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "," + LexGrid.Rows[x + 4].Cells[1].Value.ToString() + LexGrid.Rows[x + 5].Cells[1].Value.ToString();
                                                                    x = x + 5;
                                                                    break;
                                                            }
                                                            x++;
                                                        } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ")");

                                                        //main += "GlobalVar." + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + LexGrid.Rows[x + 2].Cells[1].Value.ToString();
                                                        main += " = Convert.ToDouble(Console.ReadLine()); \n";
                                                    }
                                                    else
                                                    {
                                                        x--;
                                                        do
                                                        {
                                                            switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                                            {
                                                                case "id":
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                                default:
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                            }
                                                            x++;
                                                        } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ")");

                                                        //main += "GlobalVar." + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + LexGrid.Rows[x + 2].Cells[1].Value.ToString();
                                                        main += " = Convert.ToDouble(Console.ReadLine()); \n";
                                                    }
                                                }
                                                else
                                                {
                                                    //outp.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                                    main += LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=";
                                                    main += "Convert.ToDouble(Console.ReadLine()); \n";
                                                }
                                                //outp.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                                //consolewrt += LexGrid.Rows[x].Cells[1].Value.ToString() + "=";
                                                //consolewrt += "Convert.ToDouble(Console.ReadLine()); \n";
                                            }
                                        }
                                        foreach (string c in stringlist)
                                        {
                                            if (c == LexGrid.Rows[x].Cells[1].Value.ToString())
                                            {
                                                x++;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                                {
                                                    if (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "[")
                                                    {
                                                        x--;
                                                        do
                                                        {
                                                            switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                                            {
                                                                case "id":
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                                default:
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "," + LexGrid.Rows[x + 4].Cells[1].Value.ToString() + LexGrid.Rows[x + 5].Cells[1].Value.ToString();
                                                                    x = x + 5;
                                                                    break;
                                                            }
                                                            x++;
                                                        } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ")");

                                                        //main += "GlobalVar." + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + LexGrid.Rows[x + 2].Cells[1].Value.ToString();
                                                        main += " = Console.ReadLine(); \n";
                                                    }
                                                    else
                                                    {
                                                        x--;
                                                        do
                                                        {
                                                            switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                                            {
                                                                case "id":
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                                default:
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                            }
                                                            x++;
                                                        } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ")");

                                                        //main += "GlobalVar." + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + LexGrid.Rows[x + 2].Cells[1].Value.ToString();
                                                        main += " = Console.ReadLine(); \n";
                                                    }
                                                }
                                                else
                                                {
                                                    //outp.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                                    main += LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=";
                                                    main += "Console.ReadLine(); \n";
                                                }

                                                //outp.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                                //consolewrt += LexGrid.Rows[x].Cells[1].Value.ToString() + "=";
                                                //consolewrt += "Console.ReadLine(); \n";
                                            }
                                        }
                                        foreach (string c in charlist)
                                        {
                                            if (c == LexGrid.Rows[x].Cells[1].Value.ToString())
                                            {
                                                x++;
                                                if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                                {
                                                    if (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "[")
                                                    {
                                                        x--;
                                                        do
                                                        {
                                                            switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                                            {
                                                                case "id":
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                                default:
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "," + LexGrid.Rows[x + 4].Cells[1].Value.ToString() + LexGrid.Rows[x + 5].Cells[1].Value.ToString();
                                                                    x = x + 5;
                                                                    break;
                                                            }
                                                            x++;
                                                        } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ")");

                                                        //main += "GlobalVar." + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + LexGrid.Rows[x + 2].Cells[1].Value.ToString();
                                                        main += " = Console.ReadLine(); \n";
                                                    }
                                                    else
                                                    {
                                                        x--;
                                                        do
                                                        {
                                                            switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                                            {
                                                                case "id":
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                                default:
                                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                                    break;
                                                            }
                                                            x++;
                                                        } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ")");

                                                        //main += "GlobalVar." + LexGrid.Rows[x - 1].Cells[1].Value.ToString() + LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + LexGrid.Rows[x + 2].Cells[1].Value.ToString();
                                                        main += " = Console.ReadLine(); \n";
                                                    }
                                                }
                                                else
                                                {
                                                    //outp.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                                    main += LexGrid.Rows[x - 1].Cells[1].Value.ToString() + "=";
                                                    main += "Console.ReadLine(); \n";
                                                }
                                                //outp.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                                //consolewrt += LexGrid.Rows[x].Cells[1].Value.ToString() + "=";
                                                //consolewrt += "Console.ReadLine(); \n";
                                            }
                                        }
                                    }
                                }
                                x++;
                            } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");

                        }
                        break;

                    case "post":
                        x++;
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "(")
                        {
                            main += "Console.Write(";
                            do
                            {
                                x++;
                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Stringlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Numlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Charlit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Declit" || LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                                {
                                    do
                                    {
                                        switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                                        {
                                            case "Stringlit":
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                x++;
                                                break;
                                            case "Numlit":
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                x++;
                                                break;
                                            case "Declit":
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                x++;
                                                break;
                                            case "Charlit":
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                x++;
                                                break;
                                            case "AFFIRMATIVE":
                                                main += "true";
                                                x++;
                                                break;
                                            case "NEGATIVE":
                                                main += "false";
                                                x++;
                                                break;
                                            case "id":
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                x++;
                                                break;
                                            case ",":
                                                main += " , ";
                                                x++;
                                                break;
                                            case "+":
                                                main += " + ";
                                                x++;
                                                break;
                                            case "[":
                                                main += " [ ";
                                                x++;
                                                if (LexGrid.Rows[x + 2].Cells[1].Value.ToString() == "[")
                                                {
                                                    main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + LexGrid.Rows[x + 3].Cells[1].Value.ToString() + "]";
                                                    x += 5;
                                                }
                                                break;
                                            case "]":
                                                main += " ] ";
                                                x++;
                                                break;
                                            case "(":
                                                main += "(";
                                                x++;
                                                break;
                                            case ")":
                                                main += ")";
                                                x++;
                                                break;
                                            default:
                                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                                x++;
                                                break;
                                        }
                                    } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");

                                }
                            } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");
                            main += "; \n";
                        }
                        break;
                    case "id":
                        do
                        {
                            switch (LexGrid.Rows[x].Cells[2].Value.ToString())
                            {
                                case "id":
                                    main += " " + LexGrid.Rows[x].Cells[1].Value.ToString();
                                    x++;
                                    if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                    {
                                        if (LexGrid.Rows[x + 3].Cells[1].Value.ToString() == "[")
                                        {
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + "," + LexGrid.Rows[x + 4].Cells[1].Value.ToString() + "]";
                                            x += 6;
                                            break;
                                        }
                                        else
                                        {
                                            main += LexGrid.Rows[x].Cells[1].Value.ToString() + LexGrid.Rows[x + 1].Cells[1].Value.ToString() + LexGrid.Rows[x + 2].Cells[1].Value.ToString();
                                            x += 3;
                                            break;
                                        }
                                    }
                                    break;
                                case "=":
                                    main += "=";
                                    x++;
                                    break;
                                case "+":
                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                    x++;
                                    break;
                                case "-":
                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                    x++;
                                    break;
                                case "*":
                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                    x++;
                                    break;
                                case "/":
                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                    x++;
                                    break;
                                case "%":
                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                    x++;
                                    break;
                                case "^":
                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                    x++;
                                    break;
                                case "(":
                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                    x++;
                                    break;
                                case ")":
                                    main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                    x++;
                                    break;
                                case "~":
                                    main += " -";
                                    x++;
                                    break;
                                case "Extent":
                                    main += "Length";
                                    x++;
                                    break;
                                case "ToJoeRange":
                                    main += "ToCharArray()";
                                    x++;
                                    break;
                                case "Carry":
                                    main += "Contains";
                                    x++;
                                    do
                                    {
                                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                        x++;
                                    } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                                    break;
                                case "sqrt":
                                    x++;
                                    main += "Math.Sqrt";
                                    break;
                                default:
                                    //if (LexGrid.Rows[x].Cells[1].Value.ToString() == "[")
                                    //{
                                    //    main += "[";
                                    //    x++;
                                    //    do
                                    //    {
                                    //        if (LexGrid.Rows[x + 3].Cells[2].Value.ToString() == "=")
                                    //        {
                                    //            do
                                    //            {
                                    //                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                    //                x++;
                                    //            } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                                    //        }
                                    //        else
                                    //        {
                                    //            main += LexGrid.Rows[x].Cells[1].Value.ToString() + "," + LexGrid.Rows[x + 2].Cells[1].Value.ToString() + "]";
                                    //            x += 5;
                                    //        }
                                    //    } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                                    //} else { 
                                    main += LexGrid.Rows[x].Cells[1].Value.ToString(); x++;
                                    //}
                                    break;
                            }
                        } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");
                        main += "; \n";
                        break;
                    case "Swap":
                        main += "Array.Reverse";
                        x++;
                        do
                        {
                            main += LexGrid.Rows[x].Cells[1].Value.ToString();
                            x++;
                        } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ";");
                        main += ";";
                        break;
                    case "inorder":
                        x++;
                        main += "if";
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Carry")
                            {
                                main += "Contains";
                                x++;
                            }
                            else
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                        } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{");
                        main += LexGrid.Rows[x].Cells[1].Value.ToString() + "\n";
                        //x++;
                        break;
                    case "otherorder":
                        x++;
                        main += "else if";
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Carry")
                            {
                                main += "Contains";
                                x++;
                            }
                            else
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                        } while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{");
                        main += LexGrid.Rows[x].Cells[1].Value.ToString() + "\n";
                        break;
                    case "order":
                        x++;
                        main += "else {\n";
                        break;
                    case "campaign":
                        x++;
                        main += "switch";
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                            else
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                        } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ")");
                        main += LexGrid.Rows[x].Cells[1].Value.ToString() + "\n" + "{ \n";
                        break;
                    case "operation":
                        main += "case "; x++;
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                            else
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                        } while (LexGrid.Rows[x].Cells[1].Value.ToString() != ":");
                        main += LexGrid.Rows[x].Cells[1].Value.ToString() + " ";
                        break;
                    case "abort":
                        x += 3;
                        main += "break; \n";
                        break;
                    case "sqrt":
                        x++;
                        main += "Math.Sqrt";
                        break;
                    case "inquire":
                        x++;
                        main += "for";
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                            else
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                        } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ")");
                        main += LexGrid.Rows[x].Cells[1].Value.ToString() + "\n";
                        x++;
                        main += "{ \n";
                        break;
                    case "action":
                        x++;
                        main += "default: \n";
                        break;
                    case "go":
                        x++;
                        main += "do {";
                        break;
                    case "phase":
                        x++;
                        main += "while";
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                            else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "&")
                            {
                                main += " && ";
                                x++;
                            }
                            else
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                        } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ")");
                        main += LexGrid.Rows[x].Cells[1].Value.ToString();
                        x++;
                        if (LexGrid.Rows[x].Cells[1].Value.ToString() == ";")
                        {
                            main += "; \n";
                        }
                        else
                        {
                            main += " { \n";
                        }
                        break;
                    case "backup":
                        x++;
                        main += "return ";
                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
                            {
                                main += LexGrid.Rows[x].Cells[1].Value.ToString();
                                x++;
                            }
                            else
                            {
                                x++;
                                continue;
                            }

                        } while (LexGrid.Rows[x].Cells[2].Value.ToString() != ";");
                        main += LexGrid.Rows[x].Cells[1].Value.ToString() + "\n";
                        break;
                    case "commence":
                        main += "Console.Clear(); \n";
                        x++;
                        break;
                }

                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "}")
                {
                    x++;
                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "deploy")
                    {
                        x += 2;
                        main += "Console.ReadLine(); \n } \n";
                    }
                    else
                    {
                        main += LexGrid.Rows[x - 1].Cells[1].Value.ToString() + " \n";
                        x--;
                    }
                }
            }

            globdeclare += "\n";
            //function += "} \n";
            consolewrt += globdeclare + main + function;
            richTextBoxEx1.Text += consolewrt;
            richTextBoxEx1.Text += "} \n } \n ";
            //MessageBox.Show(richTextBoxEx1.Text);
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            string Output = "Out.exe";
            // Button ButtonObject = (Button)sender;

            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Output;
            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, richTextBoxEx1.Text);

            if (results.Errors.Count > 0)
            {
                textBox2.ForeColor = Color.Red;
                int x = 0;
                foreach (CompilerError CompErr in results.Errors)
                {
                    //textBox2.Text = textBox2.Text +
                    //            "Line number " + CompErr.Line +
                    //            ", Error Number: " + CompErr.ErrorNumber +
                    //            ", '" + CompErr.ErrorText + ";" +
                    //            Environment.NewLine + Environment.NewLine;
                    if (CompErr.ErrorText.Contains("test.test"))
                    {

                    }
                    else
                    {
                        dataGridViewX4.Rows.Add(x++, CompErr.ErrorText);
                    }
                }
            }
            else
            {
                //Successful Compile
                textBox2.ForeColor = Color.Blue;
                textBox2.Text = "Success!";
                dataGridViewX4.Rows.Add(Color.Blue, "Success!");
                //If we clicked run then launch our EXE
                Process.Start(Output);
                buttonX12.Enabled = false;
                buttonX13.Enabled = true;
            }
           
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            File.Delete("Out.exe");
            consolewrt = "";
            richTextBoxEx1.Text = "";
            buttonX12.Enabled = true;
            buttonX13.Enabled = false;
            dataGridViewX4.Rows.Clear();

        }

        private void Code_TextChanged(object sender, EventArgs e)
        {
            //string tokens = "(PrimaryMission|deploy|inquire|go|phase|inorder|otherorder|order|post|capture|campaign|operation|unit|digit|company|joe|response|abort)";
            //Regex rex = new Regex(tokens);
            //MatchCollection mc = rex.Matches(Code.Text);
            //int StartCursorPosition = Code.SelectionStart;
            //foreach (Match m in mc)
            //{
            //    int startIndex = m.Index;
            //    int StopIndex = m.Length;
            //    Code.Select(startIndex, StopIndex);
            //    Code.SelectionColor = Color.Green;
            //    Code.SelectionStart = StartCursorPosition;
            //    Code.SelectionColor = Color.Black;
            //}
        }
    }
}