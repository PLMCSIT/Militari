using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Lexical_Analyzer;
using Syntax_Analyzer;
using Semantics_Analyzer;
//Unused Libraries
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.ComponentModel;
//using System.Threading.Tasks;
//using System.Collections.Generic;

namespace LexiCom
{
    public partial class Militari : Form
    {
        /* string txt;
        Analyzer lex = new Analyzer();
        List<string> stored = new List<string>(); */
        public Militari()
        {
            InitializeComponent();
        }

        int lines = 0;
        List<int> linetokens = new List<int>();
        LexicalAnalyzer lex = new LexicalAnalyzer();

        private void LexButton_Click(object sender, EventArgs e)
        {
            //lines = 0;
            //linetokens = new List<int>();
            lex = new LexicalAnalyzer();
            SynButton.Enabled = false;
            if (Code.Text != "")
            {
                Output.Text = "";
                lex = new LexicalAnalyzer();
                Output.Text += "< ========== > Lexical Report < ========== > \n";
                Initializer Lexical = new Initializer();
                string txt = Code.Text;
                lex = Lexical.InitializeAnalyzer(txt, lex);

                DisplayTokens(lex);
                Output.Text += "\n< ========== > End of Report < ========== > \n";
            }

            if (lex.invalid == 0 && lex.token.Count != 0)
            {
                SynButton.Enabled = true;
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
            int ctr = 0, id = 0;
            LexGrid.Rows.Clear();

            if (lex.invalid != 0)
                result = "Encountered " + lex.invalid.ToString() + " error/s.\nPlease try again.\n";
            Output.Text += "Lexical Analyzer " + result;

            foreach (var token in lex.token)
            {
                if (token.getTokens() == "INVALID")
                {

                    Output.Text += "Invalid input: "
                                + token.getLexemes()
                                + " on line "
                                + token.getLines() + "\n";
                }
                else if (token.getTokens() == "NODELIM")
                {
                    Output.Text += "Proper delimiter expected: "
                                + token.getLexemes()
                                + " on line "
                                + token.getLines() + "\n";
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

        private void LexBtn_Click(object sender, EventArgs e)
        {
            if (LexPanel.Location.X == 743)
            {

                LexPanel.Location = new Point(463, LexPanel.Location.Y);
                if (Code.Size.Width != 444)
                {
                    Code.Size = new Size(444, Code.Size.Height);
                    //.Size = new Size(444, Output.Size.Height);
                }
            }
            else if (LexPanel.Location.X == 463)
            {
                LexPanel.Location = new Point(743, LexPanel.Location.Y);
                Code.Size = new Size(691, Code.Size.Height);
               // Output.Size = new Size(691, Output.Size.Height);
            }
        }

        private void LexiCom_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SyntaxInitializer S_initialize = new SyntaxInitializer();
            dataGridView1.Rows.Clear();
            int i = 1;
            string s;
                s = S_initialize.Start(tokenDump(lex.token));
            //Syntax_Output.Text = "< ========== > Syntax Report < ========== > \n" + s + "\n"
            // + "< ========== > End of Report < ========== > \n";

            //Syntax_Table.Rows.Clear();
            //int c = 0;
            //foreach (var item in S_initialize.SET)
            //{
            //    Syntax_Table.Rows.Add(S_initialize.PRODUCTION[c].ToString(), "->", S_initialize.SET[c].ToString());
            //    c++;
            //}

            //MessageBox.Show(S_initialize.recursiveprod);
            if (s != "Syntax Analyzer Succeeded...")
            {
                int errornum = 1;
                dataGridView1.Rows.Clear();
                if (S_initialize.errors.getColumn() == 1)
                {
                    S_initialize.errors.setLines(S_initialize.errors.getLines() - 1);
                }
                dataGridView1.Rows.Add(errornum, S_initialize.errors.getErrorMessage(), S_initialize.errors.getLines());
                errornum++;
            }
            else
            {
                Output.Text += s;
            }
            //SemanticsInitializer semantics = new SemanticsInitializer();
            //semantics = SemanticsStart(tokenDumps(lex.token));
            //string semantics_result = semantics.Start();
            //Output.Text += semantics.error + semantics_result;
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

        private void LexPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
