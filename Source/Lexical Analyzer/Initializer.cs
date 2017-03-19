﻿using System;
using System.Collections.Generic;
using System.Linq;

//Unused Libraries
//using System.Text;
//using System.Threading.Tasks;
//using System.Collections.Generic;

namespace Lexical_Analyzer
{
    public class Initializer
    {
        public int tokens = 0;  
        //INITIALIZATION
        public LexicalAnalyzer InitializeAnalyzer(string txt, LexicalAnalyzer lex)
        {
            Boolean hastoken = false;
            Tokens t = new Tokens();
            //txt = txt.TrimStart();
            lex.token.Clear();
            lex.invalid = 0;
            lex.valid = 0;
            while (txt != "")
            {
                if (hastoken = lex.GetTokenLines(txt, tokens))
                {
                    txt = txt.Remove(0, lex.ctr);
                    tokens--;
                }
                else if (hastoken = lex.GetReservedWords(txt))
                    txt = txt.Remove(0, lex.ctr);
                else if (hastoken = lex.GetReservedSymbols(txt))
                    txt = txt.Remove(0, lex.ctr);
                else if (hastoken = lex.GetLiterals(txt))
                    txt = txt.Remove(0, lex.ctr);
                else if (hastoken = lex.GetIdentifiers(txt))
                    txt = txt.Remove(0, lex.ctr);
                else
                {
                 t = new Tokens();
                    lex.invalid++;
                   // lex.token.Add("INVALID");
                    if (lex.state != 0)
                    {
                        switch (lex.state)
                        {
                            case 1:
                                lex.ctr = GetCtr(txt, 1);
                                break;
                        }
                    }
                    if (lex.ctr == 0 && txt.Length != 1) lex.ctr = GetCtr(txt);
                    else if (lex.ctr == 0 && txt.Length == 1) lex.ctr = 1;
                    else if (lex.ctr >= txt.Length) lex.ctr = txt.Length;
                    t.setTokens("INVALID");
                    t.setLexemes(txt.Substring(0, lex.ctr));
                    lex.token.Add(t);
                    txt = txt.Remove(0, lex.ctr);

                }
                tokens++;
                //txt = txt.TrimStart();
            }
            lex.linetokens.Add(tokens);
            lex = setLines(lex);

            return lex;
        }

        private LexicalAnalyzer setLines(LexicalAnalyzer lex)
        {
            for (int ctr = 0; ctr < lex.token.Count; ctr++)
            {
                for (int i = 0; i < lex.linetokens.Count; i++)
                {
                    if (ctr + 1 <= lex.linetokens[i])
                    {
                        lex.token[ctr].setLines(i + 1);
                        break;
                    }
                }
            }
            return lex;
        }

        //GET CTRS
        private int GetCtr(string txt)
        {
            Dictionary.ReservedWordsDelims rwd = new Dictionary.ReservedWordsDelims();
            Dictionary td = new Dictionary();
            
            Boolean ifEnd = false;
            int ctr = 0;

            foreach (var item in rwd.delim_end)
            {   
                if (txt.ElementAt(ctr - 1) == item)
                    ifEnd = true;
            }
            while (ifEnd != true)
            {
                foreach (var item in rwd.delim_end)
                {
                    if ((txt.Length) > ctr)
                    {
                        if (txt.ElementAt(ctr) == item)
                        {
                            ifEnd = true;
                            break;
                        }
                    }
                    else ifEnd = true;
                }
                if (ifEnd != true)
                    ctr++;
            }

            if (!(txt.Length >= ctr)) ctr--;
            return ctr;
        }
        private int GetCtr(string txt, int ctr)
        {
            Boolean notEnd = true;
            List<char> delims = new List<char>{ '"', '\\', '\n' };
            while (notEnd && (txt.Length - 1) >= ctr)
            {
                foreach (char c in delims)
                {
                    if ((txt.Length - 1) > ctr)
                    {
                        if (c == txt.ElementAt(ctr))
                        {
                            notEnd = false;
                            if (c == '\\')
                                if (txt.Length - 1 != ctr)
                                    ctr++;
                        }
                    }
                    else
                        notEnd = false;
                }
                ctr++;
            }
            return ctr;
        }
    }
}
