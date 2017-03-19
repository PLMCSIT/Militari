using System;
using System.Collections.Generic;
using System.Linq;

//Unused Libraries
//using System.Text;
//using System.Threading.Tasks;
using TokenLibrary;

namespace Lexical_Analyzer
{
    public class Tokens : TokensClass
    {

    }
    public class LexicalAnalyzer
    {
        public List<Tokens> token = new List<Tokens>();
        public List<int> linetokens = new List<int>();
        Boolean isReserved = false;
        public int invalid = 0;
        public int valid = 0;
        public int ctr = 0;
        public byte state = 0;
        public int lines = 0;
        public int idnum = 1;
        Dictionary td = new Dictionary();

        public Boolean GetTokenLines(string txt, int tokenctr)
        {

            Boolean hastokenlines = false;
            if (txt.ElementAt(0) == '\n')
            {
                lines++;
                linetokens.Add(tokenctr);
                hastokenlines = true;
                ctr = 1;
            }
            else if (txt.ElementAt(0) == ' ')
            {
                hastokenlines = true;
                ctr = 1;
            }
            return hastokenlines;
        }

        //GET TOKENS
        public Boolean GetReservedWords(string txt)
        {
            Dictionary.ReservedWordsDelims rwd = new Dictionary.ReservedWordsDelims();
            Dictionary.ReservedWords rw = new Dictionary.ReservedWords();
            Tokens t = new Tokens();

            List<String> words;
            List<char> delims;
            List<String> temp;
            Boolean found = false, hastoken = false, exitfor = false, ifEnd = false, nodelim = true;
            int tempctr = 0, limit = 0;

            if (txt.Length != 1)
            {
                while ((txt.Length - 1) > tempctr && !isEnd(txt[tempctr + 1], rwd))
                {
                    tempctr++;
                }
                tempctr++;
            }

            for (int i = 0; i < 5; i++)
            {
                ctr = 0;
                words = new List<String>();
                delims = new List<char>();
                found = true;
                switch (i)
                {
                    case 0:
                        words = rw.rw_1;
                        delims = rwd.delim_1;
                        break;
                    case 1:
                        words = rw.rw_2;
                        delims = rwd.delim_2;
                        break;
                    case 2:
                        words = rw.rw_3;
                        delims = rwd.delim_3;
                        break;
                    case 3:
                        words = rw.rw_4;
                        delims = rwd.delim_4;
                        break;
                    case 4:
                        words = rw.rw_5;
                        delims = rwd.delim_5;
                        break;
                }
                //Check Reserved Words
                foreach (char c in txt)
                {
                    limit = words.Count - 1;
                    temp = new List<string>();
                    found = false;
                    foreach (string w in words)
                    {
                        //IF NOT OUT OF RANGE
                        if ((w.Length - 1) >= ctr)
                        {
                            //IF LETTER MATCHED
                            if (c == w.ElementAt(ctr))
                            {
                                found = true;
                                //CHECK SIZE OF WORD AND INPUT
                                if (w.Length == tempctr)
                                {
                                    //CHECK DELIMITER
                                    if ((tempctr - 1) == ctr)
                                    {
                                        foreach (char delim in delims)
                                        {
                                            //IF NOT OUT OF RANGE
                                            if ((txt.Length - 1) > ctr)
                                            {
                                                //IF FOUND DELIMITER
                                                if (txt[ctr + 1] == delim)
                                                {
                                                    hastoken = true;
                                                    nodelim = false;
                                                    t.setTokens(w);
                                                    t.setLexemes(w);
                                                    t.setAttributes(w);
                                                    token.Add(t);
                                                    valid++;
                                                    break;
                                                }
                                            }
                                            else if (w == words[limit] && hastoken == false) { found = false; }

                                        }

                                        if (hastoken == false)
                                        {
                                            hastoken = true;
                                            nodelim = false;
                                            found = true;
                                            t.setTokens("NODELIM");
                                            t.setLexemes(w);
                                            t.setAttributes(w);
                                            token.Add(t);
                                            invalid++;
                                                
                                        }
                                        else if (nodelim)
                                        {
                                            hastoken = true;
                                            found = true;
                                            t.setTokens("INVALID");
                                            t.setLexemes(w);
                                            t.setAttributes(w);
                                            token.Add(t);
                                            invalid++;
                                            break;
                                        }
                                        if (hastoken)
                                        {
                                            break;
                                        }
                                    }
                                    else temp.Add(w);
                                }

                            }
                        }
                    }
                    ctr++;
                    words = temp;
                    if (found == false) break;
                    if (hastoken)
                    {
                        exitfor = true;
                        break;
                    }
                }
                if (exitfor)
                {
                    exitfor = false;
                    break;
                }
            }

            //IF NOTHING FOUND
            if (found == false)
            {
                hastoken = false;
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
            }

            if (!(txt.Length >= ctr)) ctr--;

            return hastoken;
        }
        /*  public Boolean GetReservedSymbols(string txt)
          {
              Dictionary td = new Dictionary();
              Dictionary.ReservedSymbols rs = new Dictionary.ReservedSymbols();
              Dictionary.ReservedSymbolsDelims rsd = new Dictionary.ReservedSymbolsDelims();
              Boolean found = false, hastoken = false, exitfor = false;
              List<String> words;
              List<char> delims;
              List<String> temp;
              int tempctr = 0, limit = 0, sctr= 0;

              if (txt.Length != 1)
              {
                  while ((txt.Length - 1) > tempctr && !isEnd(txt[tempctr + 1],rsd))
                  {
                      tempctr++;
                  }
                  tempctr++;
              }

              for (int i = 0; i < 16; i++)
              {
                  sctr = 0;
                  words = new List<String>();
                  delims = new List<char>();
                  found = true;
                  switch (i)
                  {
                      case 0:
                          words = rs.rs_1;
                          delims = rsd.del1;
                          break;
                      case 1:
                          words = rs.rs_2;
                          delims = rsd.del2;
                          break;
                      case 2:
                          words = rs.rs_3;
                          delims = rsd.del3;
                          break;
                      case 3:
                          words = rs.rs_4;
                          delims = rsd.del4;
                          break;
                      case 4:
                          words = rs.rs_5;
                          delims = rsd.del5;
                          break;
                      case 5:
                          words = rs.rs_6;
                          delims = rsd.del6;
                          break;
                      case 6:
                          words = rs.rs_7;
                          delims = rsd.del7;
                          break;
                      case 7:
                          words = rs.rs_8;
                          delims = rsd.del8;
                          break;
                      case 8:
                          words = rs.rs_9;
                          delims = rsd.del9;
                          break;
                      case 9:
                          words = rs.rs_10;
                          delims = rsd.del10;
                          break;
                      case 10:
                          words = rs.rs_11;
                          delims = rsd.del11;
                          break;
                      case 11:
                          words = rs.rs_12;
                          delims = rsd.del12;
                          break;
                      case 12:
                          words = rs.rs_13;
                          delims = rsd.del13;
                          break;
                      case 13:
                          words = rs.rs_14;
                          delims = rsd.del14;
                          break;
                      case 14:
                          words = rs.rs_15;
                          delims = rsd.del15;
                          break;
                      case 15:
                          words = rs.rs_16;
                          delims = rsd.del16;
                          break;

                  }
                  //Check Reserved Symbols
                  foreach (char c in txt)
                  {
                      limit = words.Count - 1;
                      temp = new List<string>();
                      found = false;
                      foreach (string w in words)
                      {
                          //IF NOT OUT OF RANGE
                          if ((w.Length - 1) >= sctr)
                          {
                              if (c == w.ElementAt(sctr))
                              {
                                  found = true;
                                  //CHECK SIZE OF WORD AND INPUT
                                  if (w.Length == tempctr)
                                  {
                                      //CHECK DELIMITER
                                      if ((tempctr - 1) == sctr)
                                      {
                                          foreach (char delim in delims)
                                          {
                                              //IF NOT OUT OF RANGE
                                              if ((txt.Length - 1) > sctr)
                                              {
                                                  if (txt[sctr + 1] == delim)
                                                  //IF FOUND DELIMITER
                                                  {
                                                      found = true;
                                                      hastoken = true;
                                                      tokens.Add(w);
                                                      lexemes.Add(w);
                                                      valid++;
                                                      break;

                                                  }
                                              }
                                              else if (w == words[limit] && hastoken == false) found = false;
                                          }

                                          if (hastoken) break;

                                      }
                                      else temp.Add(w);
                                  }
                              }
                          }
                      }
                      sctr++;
                      words = temp;
                      if (found == false) break;
                      if (hastoken)
                      {
                          exitfor = true;
                          break;
                      }
                  }
                  if (exitfor)
                  {
                      exitfor = false;
                      break;
                  }
              }
              if (hastoken) ctr = sctr;
                  return hastoken;
          } */

        public Boolean GetReservedSymbols(string txt)
        {
            Dictionary td = new Dictionary();
            Dictionary.ReservedSymbols rs = new Dictionary.ReservedSymbols();
            Dictionary.ReservedSymbolsDelims rsd = new Dictionary.ReservedSymbolsDelims();
            Boolean found = false, hastoken = false, exitfor = false;

            Tokens t = new Tokens();
            //rsd = td.AddRange(rsd);
            List<String> words;
            List<char> delims;
            List<String> temp;
            int tempctr = 0, limit = 0, sctr = 0;

            if (txt.Length != 1)
            {
                while ((txt.Length - 1) > tempctr && !isEnd(txt[tempctr + 1], rsd))
                {
                    tempctr++;
                }
                tempctr++;
            }

            for (int i = 0; i < 24; i++)
            {
                sctr = 0;
                words = new List<String>();
                delims = new List<char>();
                found = true;
                switch (i)
                {
                    case 0:
                        words = rs.rs_1;
                        delims = rsd.del1;
                        break;
                    case 1:
                        words = rs.rs_2;
                        delims = rsd.del2;
                        break;
                    case 2:
                        words = rs.rs_3;
                        delims = rsd.del3;
                        break;
                    case 3:
                        words = rs.rs_4;
                        delims = rsd.del4;
                        break;
                    case 4:
                        words = rs.rs_5;
                        delims = rsd.del5;
                        break;
                    case 5:
                        words = rs.rs_6;
                        delims = rsd.del6;
                        break;
                    case 6:
                        words = rs.rs_7;
                        delims = rsd.del7;
                        break;
                    case 7:
                        words = rs.rs_8;
                        delims = rsd.del8;
                        break;
                    case 8:
                        words = rs.rs_9;
                        delims = rsd.del9;
                        break;
                    case 9:
                        words = rs.rs_10;
                        delims = rsd.del10;
                        break;
                    case 10:
                        words = rs.rs_11;
                        delims = rsd.del11;
                        break;
                    case 11:
                        words = rs.rs_12;
                        delims = rsd.del12;
                        break;
                    case 12:
                        words = rs.rs_13;
                        delims = rsd.del13;
                        break;
                    case 13:
                        words = rs.rs_14;
                        delims = rsd.del14;
                        break;
                    case 14:
                        words = rs.rs_15;
                        delims = rsd.del15;
                        break;
                    case 15:
                        words = rs.rs_16;
                        delims = rsd.del16;
                        break;
                    case 16:
                        words = rs.rs_17;
                        delims = rsd.del17;
                        break;
                    case 17:
                        words = rs.rs_18;
                        delims = rsd.del18;
                        break;
                    case 18:
                        words = rs.rs_19;
                        delims = rsd.del19;
                        break;
                    case 19:
                        words = rs.rs_20;
                        delims = rsd.del20;
                        break;
                    case 20:
                        words = rs.rs_21;
                        delims = rsd.del21;
                        break;
                    case 21:
                        words = rs.rs_22;
                        delims = rsd.del22;
                        break;
                    case 22:
                        words = rs.rs_23;
                        delims = rsd.del23;
                        break;
                    case 23:
                        words = rs.rs_24;
                        delims = rsd.del24;
                        break;

                }
                foreach (char c in txt)
                {
                    limit = words.Count - 1;
                    temp = new List<string>();
                    found = false;
                    foreach (string w in words)
                    {
                        //IF NOT OUT OF RANGE
                        if ((w.Length - 1) >= sctr)
                        {
                            if (c == w.ElementAt(sctr))
                            {
                                found = true;
                                //CHECK SIZE OF WORD AND INPUT
                                if (w.Length == tempctr)
                                {
                                    //CHECK DELIMITER
                                    if ((tempctr - 1) == sctr)
                                    {
                                        foreach (char delim in delims)
                                        {
                                            //IF NOT OUT OF RANGE
                                            if ((txt.Length - 1) > sctr)
                                            {
                                                //IF FOUND DELIMITER
                                                if (txt[sctr + 1] == delim)
                                                {
                                                    found = true;
                                                    hastoken = true;
                                                    t = new Tokens();
                                                    t.setTokens(w);
                                                    t.setLexemes(w);
                                                    t.setAttributes(w);
                                                    token.Add(t);
                                                    valid++;
                                                    break;

                                                }
                                            }
                                            else if (w == words[limit] && hastoken == false) found = false;
                                        }

                                        if (hastoken) break;

                                    }
                                    else temp.Add(w);
                                }
                            }
                        }
                    }
                    sctr++;
                    words = temp;
                    if (found == false) break;
                    if (hastoken)
                    {
                        exitfor = true;
                        break;
                    }
                }

                if (exitfor)
                {
                    exitfor = false;
                    break;
                }
            }
            if (hastoken) ctr = sctr;
            return hastoken;
        }

        /* public Boolean GetLiterals(string txt)
        {
            Dictionary.LiteralsDelims ld = new Dictionary.LiteralsDelims();
            Dictionary.Literals l = new Dictionary.Literals();
            List<char> delims = new List<char>();
            Boolean hastoken = false, validtxt = false;
            string literal = "";
            state = 0;
            int lctr = 0;

            if (txt.ElementAt(lctr) == '"')
                state = 1;
            else if (txt.ElementAt(lctr) == '\'')
                state = 2;
            else
            {
                foreach (char num in l.nums)
                {
                    if (txt.ElementAt(lctr) == num)
                        state = 3;
                }
            }

            if (state != 0)
            {
                switch (state)
                {
                    case 1: case 2:
                        delims = ld.delim_txt;
                        //String Literal Analyzer
                        if (state == 1)
                        {
                            if (txt.Length != 1)
                            {
                                while ((txt.Length - 1) > lctr && !(txt[lctr + 1] == '"') && !(txt[lctr + 1] == '\n'))
                                {
                                    literal += txt[lctr].ToString();
                                    lctr++;
                                }
                                if ((txt.Length - 1) == lctr && (txt[lctr] != '"'))
                                    hastoken = false;
                                else
                                {
                                    if (!(lctr == 1 && txt[lctr] == '\\'))
                                    {
                                        validtxt = true;
                                        lctr++;
                                        foreach (char c in delims)
                                        {
                                            if ((txt.Length - 1) >= (lctr + 1))
                                                if (txt[lctr + 1] == c)
                                                {
                                                    hastoken = true;
                                                    break;
                                                }
                                        }
                                    }
                                    if (hastoken && validtxt)
                                    {
                                        valid++;
                                        tokens.Add("Stringlit");
                                        lexemes.Add(txt.Substring(0, (lctr + 1)));
                                        ctr = lctr + 1;
                                    }
                                    else if (!validtxt)
                                    {
                                        ctr = lctr + 2;
                                        hastoken = false;
                                    }

                                }
                            }
                        }

                        //Character Literal Analyzer
                        else
                        {
                            if (txt.Length != 1)
                            {
                               
                                while ((txt.Length - 1) > lctr && !(txt[lctr + 1] == '\'') && !(txt[lctr + 1] == '\n'))
                                {
                                    literal += txt[lctr].ToString();
                                    lctr++;
                                }
                                if (lctr >= 3)
                                {
                                    hastoken = false;
                                    ctr = lctr + 2;
                                    if (ctr > txt.Length)
                                        ctr = txt.Length;
                                }
                                else
                                {
                                    if ((txt[1] == '\\' && lctr == 2) || (lctr == 1 && txt[1] != '\\') || lctr == 0)
                                        validtxt = true;
                                    else
                                    {
                                        validtxt = false;
                                        hastoken = false;
                                        ctr = lctr + 2;
                                        if (ctr > txt.Length)
                                            ctr = txt.Length;
                                    }
                                    if (validtxt)
                                    {
                                        if ((txt.Length - 1) >= (lctr + 1) && txt[lctr + 1] == '\'')
                                        {
                                            lctr++;
                                            foreach (char c in delims)
                                            {
                                                if ((txt.Length - 1) >= (lctr + 1))
                                                    if (txt[lctr + 1] == c)
                                                    {
                                                        hastoken = true;
                                                        break;
                                                    }
                                            }
                                        }
                                        if (hastoken)
                                        {
                                            valid++;
                                            tokens.Add("Charlit");
                                            lexemes.Add(txt.Substring(0, (lctr + 1)));
                                            ctr = lctr + 1;
                                        }
                                        else
                                        {

                                            ctr = lctr + 1;
                                            if (ctr > txt.Length)
                                                ctr = lctr;
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    case 3:
                        Dictionary.Identifier id = new Dictionary.Identifier();
                        delims = ld.delim_num;
                        Boolean isNumNext = true, hasnum = true, hasid = false;
                        List<char> num = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                        id.id.AddRange(id.delim_caplet);
                        id.id.AddRange(id.delim_caplet);

                        //If Negative
                        if (txt.ElementAt(lctr) == '-')
                        {
                            hasnum = false;
                            foreach (char n in num)
                            {
                                if ((txt.Length - 1) > lctr)
                                    if (txt.ElementAt(lctr + 1) == n)
                                    {
                                        hasnum = true;
                                        lctr++;
                                    }
                            }
                        }

                        if (hasnum)
                        {
                            while (isNumNext)
                            {
                                isNumNext = false;
                                foreach (char n in num)
                                {
                                    if ((txt.Length - 1) > lctr)
                                        if (txt.ElementAt(lctr + 1) == n)
                                        {
                                            lctr++;
                                            isNumNext = true;
                                        }
                                }
                            }

                            //Double Literal Analyzer
                            Boolean isDouble = false;
                            if ((txt.Length - 1) > lctr)
                                if (txt.ElementAt(lctr + 1) == '.')
                                {
                                    if ((txt.Length - 1) > lctr + 1)
                                        foreach (char n in num)
                                        {
                                            if (txt.ElementAt(lctr + 2) == n)
                                                isDouble = true;
                                        }
                                }

                            //Double Literal Analyzer
                            if (isDouble)
                            {
                                lctr++;
                                isNumNext = true;
                                while (isNumNext)
                                {
                                    isNumNext = false;
                                    foreach (char n in num)
                                    {
                                        if ((txt.Length - 1) > lctr)
                                            if (txt.ElementAt(lctr + 1) == n)
                                            {
                                                lctr++;
                                                isNumNext = true;
                                            }
                                    }
                                }

                                foreach (char delim in delims)
                                {
                                    if ((txt.Length - 1) > lctr)
                                        if (txt.ElementAt(lctr + 1) == delim)
                                        {
                                            hastoken = true;
                                            break;
                                        }
                                }

                                if (hastoken)
                                {
                                    valid++;
                                    tokens.Add("Declit");
                                    lexemes.Add(txt.Substring(0, (lctr + 1)));
                                }
                                else
                                {
                                    foreach (char c in id.id)
                                    {
                                        if ((txt.Length - 1) > lctr)
                                            if (txt.ElementAt(lctr + 1) == c)
                                            {
                                                hasid = true;
                                            }
                                    }
                                }

                                if (!hasid)
                                    ctr = lctr + 1;
                            }
                            //Integer Literal Analyzer
                            else
                                {
                                    foreach (char delim in delims)
                                    {
                                        if (txt.ElementAt(lctr + 1) == delim)
                                        {
                                            hastoken = true;
                                            break;
                                        }
                                    }

                                    if (hastoken)
                                    {
                                        valid++;
                                        tokens.Add("Numlit");
                                        lexemes.Add(txt.Substring(0, (lctr + 1)));
                                    }
                                    else
                                    {
                                        foreach (char c in id.id)
                                        {
                                            if (txt.ElementAt(lctr + 1) == c)
                                            {
                                                hasid = true;
                                            }
                                        }
                                    }
                                    if (!hasid)
                                        ctr = lctr + 1;
                                }
                        }
                        break;
                }
            }
            return hastoken;
        } */

        public Boolean GetLiterals(string txt)
        {
            Dictionary.LiteralsDelims ld = new Dictionary.LiteralsDelims();
            Dictionary.Literals l = new Dictionary.Literals();
            Tokens t = new Tokens();
            List<char> delims = new List<char>();
            Boolean hastoken = false, validtxt = false;
            string literal = "";
            state = 0;
            int lctr = 0;

            if (txt.ElementAt(lctr) == '"')
                state = 1;
            else if (txt.ElementAt(lctr) == '\'')
                state = 2;
            else if (txt.ElementAt(lctr) == '@')
                state = 3;
            else
            {
                foreach (char num in l.nums)
                {
                    if (txt.ElementAt(lctr) == num)
                        state = 4;
                }
            }

            if (state != 0)
            {
                switch (state)
                {
                    case 1:
                    case 2:
                    case 3:
                        delims = ld.delim_txt;
                        //String Literal Analyzer
                        if (state == 1)
                        {
                            if (txt.Length != 1)
                            {
                                while ((txt.Length - 1) > lctr && !(txt[lctr + 1] == '"') && !(txt[lctr + 1] == '\n'))
                                {
                                    literal += txt[lctr].ToString();
                                    lctr++;
                                }
                                if ((txt.Length - 1) == lctr && (txt[lctr] != '"'))
                                    hastoken = false;
                                else
                                {
                                    if (!(lctr == 1 && txt[lctr] == '\\'))
                                    {
                                        validtxt = true;
                                        lctr++;
                                        foreach (char c in delims)
                                        {
                                            if ((txt.Length - 1) >= (lctr + 1))
                                                if (txt[lctr + 1] == c)
                                                {
                                                    hastoken = true;
                                                    break;
                                                }
                                        }
                                    }
                                    if (hastoken && validtxt)
                                    {
                                        valid++;
                                        t = new Tokens();
                                        t.setTokens("Stringlit");
                                        t.setLexemes(txt.Substring(0, (lctr + 1)));
                                        t.setAttributes("Stringlit");
                                        token.Add(t);
                                        ctr = lctr + 1;
                                    }
                                    else if (!validtxt)
                                    {
                                        ctr = lctr + 2;
                                        hastoken = false;
                                    }

                                }
                            }
                        }

                        //Character Literal Analyzer
                        else if(state == 2)
                        {
                            if (txt.Length != 1)
                            {

                                while ((txt.Length - 1) > lctr && !(txt[lctr + 1] == '\'') && !(txt[lctr + 1] == '\n'))
                                {
                                    literal += txt[lctr].ToString();
                                    lctr++;
                                }
                                if (lctr >= 3)
                                {
                                    hastoken = false;
                                    ctr = lctr + 2;
                                    if (ctr > txt.Length)
                                        ctr = txt.Length;
                                }
                                else
                                {
                                    if ((txt[1] == '\\' && lctr == 2) || (lctr == 1 && txt[1] != '\\') || lctr == 0)
                                        validtxt = true;
                                    else
                                    {
                                        validtxt = false;
                                        hastoken = false;
                                        ctr = lctr + 2;
                                        if (ctr > txt.Length)
                                            ctr = txt.Length;
                                    }
                                    if (validtxt)
                                    {
                                        if ((txt.Length - 1) >= (lctr + 1) && txt[lctr + 1] == '\'')
                                        {
                                            lctr++;
                                            foreach (char c in delims)
                                            {
                                                if ((txt.Length - 1) >= (lctr + 1))
                                                    if (txt[lctr + 1] == c)
                                                    {
                                                        hastoken = true;
                                                        break;
                                                    }
                                            }
                                        }
                                        if (hastoken)
                                        {
                                            valid++;
                                            t = new Tokens();
                                            t.setTokens("Charlit");
                                            t.setLexemes(txt.Substring(0, (lctr + 1)));
                                            t.setAttributes("Charlit");
                                            token.Add(t);
                                            ctr = lctr + 1;
                                        }
                                        else
                                        {

                                            ctr = lctr + 1;
                                            if (ctr > txt.Length)
                                                ctr = lctr;
                                        }
                                    }
                                }
                            }
                        }
                        else if(state == 3) { 
                        if (txt.Length != 1)
                        {
                            while ((txt.Length - 1) > lctr && !(txt[lctr + 1] == '@') && !(txt[lctr + 1] == '\n'))
                            {
                                literal += txt[lctr].ToString();
                                lctr++;
                            }
                            if ((txt.Length - 1) == lctr && (txt[lctr] != '@'))
                                hastoken = false;
                            else
                            {
                                if (!(lctr == 1 && txt[lctr] == '\\'))
                                {
                                    validtxt = true;
                                    lctr++;
                                    foreach (char c in delims)
                                    {
                                        if ((txt.Length - 1) >= (lctr + 1))
                                            if (txt[lctr + 1] == c)
                                            {
                                                hastoken = true;
                                                break;
                                            }
                                    }
                                }
                                if (hastoken && validtxt)
                                {
                                    valid++;
                                    t = new Tokens();
                                    t.setTokens("comment");
                                    t.setLexemes(txt.Substring(0, (lctr + 1)));
                                    t.setAttributes("comment");
                                    token.Add(t);
                                    ctr = lctr + 1;
                                }
                                else if (!validtxt)
                                {
                                    ctr = lctr + 2;
                                    hastoken = false;
                                }

                            }
                        }
                        }
                        break;

                    case 4:
                        Dictionary.Identifier id = new Dictionary.Identifier();
                        delims = ld.delim_num;
                        Boolean isNumNext = true, hasnum = true, hasid = false;
                        List<char> num = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                        id.id.AddRange(id.delim_caplet);
                        id.id.AddRange(id.delim_caplet);
                        int storedval = 0;
                        //If Negative
                        if (txt.ElementAt(lctr) == '~')
                        {
                            hasnum = false;
                            foreach (char n in num)
                            {
                                if ((txt.Length - 1) > lctr)
                                    if (txt.ElementAt(lctr + 1) == n)
                                    { 
                                        hasnum = true;
                                        lctr++;
                                    }
                            }
                        }

                        if (hasnum)
                        {
                            while (isNumNext)
                            {
                                isNumNext = false;
                                foreach (char n in num)
                                {
                                    if ((txt.Length - 1) > lctr)
                                        if (txt.ElementAt(lctr + 1) == n)
                                        {
                                            storedval++;
                                            if (storedval <= 8)
                                            {
                                                lctr++;
                                                isNumNext = true;
                                            }
                                            else if(storedval > 8) {
                                                isNumNext = false;
                                                hastoken = false;
                                            }
                                        }
                                }
                            }

                            //Double Literal Analyzer
                            Boolean isDouble = false;
                            if ((txt.Length - 1) > lctr)
                                if (txt.ElementAt(lctr + 1) == '.')
                                {
                                    if ((txt.Length - 1) > lctr + 1)
                                        foreach (char n in num)
                                        {
                                            if (txt.ElementAt(lctr + 2) == n)
                                                isDouble = true;
                                        }
                                }

                            if (isDouble)
                            {
                                lctr++;
                                isNumNext = true;
                                while (isNumNext)
                                {
                                    isNumNext = false;
                                    foreach (char n in num)
                                    {
                                        if ((txt.Length - 1) > lctr)
                                            if (txt.ElementAt(lctr + 1) == n)
                                            {
                                                lctr++;
                                                isNumNext = true;
                                            }
                                    }
                                }

                                foreach (char delim in delims)
                                {
                                    if ((txt.Length - 1) > lctr)
                                        if (txt.ElementAt(lctr + 1) == delim)
                                        {
                                            hastoken = true;
                                            break;
                                        }
                                }

                                if (hastoken)
                                {
                                    valid++;
                                    t = new Tokens();
                                    t.setTokens("Declit");
                                    t.setLexemes(txt.Substring(0, (lctr + 1)));
                                    t.setAttributes("Declit");
                                    token.Add(t);
                                }
                                else
                                {
                                    foreach (char c in id.id)
                                    {
                                        if ((txt.Length - 1) > lctr)
                                            if (txt.ElementAt(lctr + 1) == c)
                                            {
                                                hasid = true;
                                            }
                                    }
                                }

                                if (!hasid)
                                    ctr = lctr + 1;
                            }
                            //Integer Literal Analyzer
                            else
                            {
                                foreach (char delim in delims)
                                {
                                    //if (txt.ElementAt(lctr + 1) == delim)
                                    {
                                        hastoken = true;
                                        break;
                                    }

                                }

                                if (hastoken)
                                {
                                    valid++;
                                    t = new Tokens();
                                    t.setTokens("Numlit");
                                    t.setLexemes(txt.Substring(0, (lctr + 1)));
                                    t.setAttributes("Numlit");
                                    token.Add(t);
                                }
                                else
                                {
                                    foreach (char c in id.id)
                                    {
                                        if (txt.ElementAt(lctr + 1) == c)
                                        {
                                            hasid = true;
                                        }
                                    }
                                }
                                if (!hasid)
                                    ctr = lctr + 1;
                            }
                        }
                        break;
                }
            }
            return hastoken;
        }


        /* public Boolean GetIdentifiers(string txt)
        {
            Dictionary.Identifier id = new Dictionary.Identifier();
            Dictionary.IdentifierDelims delims = new Dictionary.IdentifierDelims();
            Boolean hastoken = false, valID = false, isvalID = true;

            id.id.AddRange(id.delim_lowlet);
            id.id.AddRange(id.delim_caplet);
            id.id.AddRange(id.delim_undscr);
            id.id.AddRange(id.delim_digit);

            int ictr = 0;

            foreach (char c in id.id)
            {
                if (txt.ElementAt(ictr) == c)
                {
                    valID = true;
                }
            }

            id.id.AddRange(id.delim_digit);
            if (valID)
            {
                //ictr++;
                isvalID = true;
                while (isvalID)
                {
                    isvalID = false;
                    foreach (char n in id.id)
                    {
                        if ((txt.Length - 1) > ictr)
                            if (txt.ElementAt(ictr + 1) == n)
                            {
                                ictr++;
                                isvalID = true;
                            }
                    }
                    if (ictr > 17)
                        valID = false;
                }
                
                if (valID)
                {
                    foreach (char delim in delims.delim_end)
                    {
                        if ((txt.Length - 1) > ictr)
                            if (txt.ElementAt(ictr + 1) == delim)
                            {
                                hastoken = true;
                                break;
                            }
                    }
                }

                if(hastoken)
                {
                    valid++;
                    tokens.Add("id");
                    lexemes.Add(txt.Substring(0, (ictr + 1)));
                }

                ctr = ictr + 1;
            }
            return hastoken;
        }

        //IS ENDS
        public Boolean isEnd(char c, Dictionary.ReservedWordsDelims rwd)
        {
            Boolean result = false;
            foreach (var item in rwd.delim_end)
            {
                if (item == c)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public Boolean isEnd(char c, Dictionary.ReservedSymbolsDelims rsd)
        {
            Boolean result = false;
            foreach (var item in rsd.delim_end)
            {
                if (item == c)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public Boolean isEnd(char c, List<char> ld)
        {
            Boolean result = false;
            foreach (var item in ld)
            {
                if (item == c)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
} */

        public Boolean GetIdentifiers(string txt)
        {
            Dictionary.Identifier id = new Dictionary.Identifier();
            Dictionary.IdentifierDelims delims = new Dictionary.IdentifierDelims();
            Boolean hastoken = false, valID = false, isvalID = true;
            Tokens t = new Tokens();
           

            id.id.AddRange(id.delim_lowlet);
            id.id.AddRange(id.delim_caplet);
            id.id.AddRange(id.delim_undscr);
            id.id.AddRange(id.delim_digit);

            int ictr = 0;

            foreach (char c in id.id)
            {
                if (txt.ElementAt(ictr) == c)
                {
                    valID = true;
                }
            }

            id.id.AddRange(id.delim_digit);
            if (valID)
            {
                isvalID = true;
                while (isvalID)
                {
                    isvalID = false;
                    foreach (char n in id.id)
                    {
                        if ((txt.Length - 1) > ictr)
                            if (txt.ElementAt(ictr + 1) == n)
                            {
                                ictr++;
                                isvalID = true;
                            }
                    }
                    if (ictr >= 18)
                        valID = false;
                }

                if (valID)
                {
                    foreach (char delim in delims.delim_end)
                    {
                        if ((txt.Length - 1) > ictr)
                            if (txt.ElementAt(ictr + 1) == delim)
                            {
                                hastoken = true;
                                break;
                            }
                    }
                }

                if (hastoken)
                {
                    valid++;
                    t = new Tokens();
                    t.setTokens("id");
                    t.setLexemes(txt.Substring(0, (ictr + 1)));
                    t.setAttributes("identifier" + idnum);
                    token.Add(t);
                    idnum++;
                }

                ctr = ictr + 1;
            }
            return hastoken;
        }

        public Boolean isEnd(char c, Dictionary.ReservedWordsDelims rwd)
        {
            Boolean result = false;
            foreach (var item in rwd.delim_end)
            {
                if (item == c)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public Boolean isEnd(char c, Dictionary.ReservedSymbolsDelims rsd)
        {
            Boolean result = false;
            foreach (var item in rsd.delim_end)
            {
                if (item == c)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public Boolean isEnd(char c, List<char> ld)
        {
            Boolean result = false;
            foreach (var item in ld)
            {
                if (item == c)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}





