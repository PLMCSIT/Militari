/*
 * SyntaxTokenizer.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using Core.Library;

/**
 * <remarks>A character stream tokenizer.</remarks>
 */
public class SyntaxTokenizer : Tokenizer {

    /**
     * <summary>Creates a new tokenizer for the specified input
     * stream.</summary>
     *
     * <param name='input'>the input stream to read</param>
     *
     * <exception cref='ParserCreationException'>if the tokenizer
     * couldn't be initialized correctly</exception>
     */
    public SyntaxTokenizer(TextReader input)
        : base(input, false) {

        CreatePatterns();
    }

    /**
     * <summary>Initializes the tokenizer by creating all the token
     * patterns.</summary>
     *
     * <exception cref='ParserCreationException'>if the tokenizer
     * couldn't be initialized correctly</exception>
     */
    private void CreatePatterns() {
        TokenPattern  pattern;

        pattern = new TokenPattern((int) SyntaxConstants.MAIN_N,
                                   "MAIN_N",
                                   TokenPattern.PatternType.STRING,
                                   "PrimaryMission");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.PRINT_N,
                                   "PRINT_N",
                                   TokenPattern.PatternType.STRING,
                                   "post");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.SCAN_N,
                                   "SCAN_N",
                                   TokenPattern.PatternType.STRING,
                                   "capture");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.CONST_N,
                                   "CONST_N",
                                   TokenPattern.PatternType.STRING,
                                   "hold");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.RETURN,
                                   "RETURN",
                                   TokenPattern.PatternType.STRING,
                                   "backup");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.SWITCH_N,
                                   "SWITCH_N",
                                   TokenPattern.PatternType.STRING,
                                   "campaign");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.CASE_N,
                                   "CASE_N",
                                   TokenPattern.PatternType.STRING,
                                   "operation");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.BREAK,
                                   "BREAK",
                                   TokenPattern.PatternType.STRING,
                                   "abort");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.FOR_N,
                                   "FOR_N",
                                   TokenPattern.PatternType.STRING,
                                   "inquire");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.IF,
                                   "IF",
                                   TokenPattern.PatternType.STRING,
                                   "inorder");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.ELSEIF_N,
                                   "ELSEIF_N",
                                   TokenPattern.PatternType.STRING,
                                   "otherorder");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.ELSE_N,
                                   "ELSE_N",
                                   TokenPattern.PatternType.STRING,
                                   "order");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.DO,
                                   "DO",
                                   TokenPattern.PatternType.STRING,
                                   "go");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.WHILE_N,
                                   "WHILE_N",
                                   TokenPattern.PatternType.STRING,
                                   "phase");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.VOID,
                                   "VOID",
                                   TokenPattern.PatternType.STRING,
                                   "miss");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.GETCH,
                                   "GETCH",
                                   TokenPattern.PatternType.STRING,
                                   "deploy");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.STRUCT_N,
                                   "STRUCT_N",
                                   TokenPattern.PatternType.STRING,
                                   "struct");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.DEFAULT,
                                   "DEFAULT",
                                   TokenPattern.PatternType.STRING,
                                   "action");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.CLEAR,
                                   "CLEAR",
                                   TokenPattern.PatternType.STRING,
                                   "commence");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.SQROOT,
                                   "SQROOT",
                                   TokenPattern.PatternType.STRING,
                                   "sqrt");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.PLUS,
                                   "PLUS",
                                   TokenPattern.PatternType.STRING,
                                   "+");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.MINUS,
                                   "MINUS",
                                   TokenPattern.PatternType.STRING,
                                   "-");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.TIMES,
                                   "TIMES",
                                   TokenPattern.PatternType.STRING,
                                   "*");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.DIVIDE,
                                   "DIVIDE",
                                   TokenPattern.PatternType.STRING,
                                   "/");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.MODULUS,
                                   "MODULUS",
                                   TokenPattern.PatternType.STRING,
                                   "%");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.EQUALS,
                                   "EQUALS",
                                   TokenPattern.PatternType.STRING,
                                   "=");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.SEMIC,
                                   "SEMIC",
                                   TokenPattern.PatternType.STRING,
                                   ";");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.DOT,
                                   "DOT",
                                   TokenPattern.PatternType.STRING,
                                   ".");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.COMMA,
                                   "COMMA",
                                   TokenPattern.PatternType.STRING,
                                   ",");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.AND,
                                   "AND",
                                   TokenPattern.PatternType.STRING,
                                   "&");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.OR,
                                   "OR",
                                   TokenPattern.PatternType.STRING,
                                   "||");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.NOT,
                                   "NOT",
                                   TokenPattern.PatternType.STRING,
                                   "!");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.INCREMENT,
                                   "INCREMENT",
                                   TokenPattern.PatternType.STRING,
                                   "++");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.DECREMENT,
                                   "DECREMENT",
                                   TokenPattern.PatternType.STRING,
                                   "--");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.P_E,
                                   "P_E",
                                   TokenPattern.PatternType.STRING,
                                   "+=");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.M_E,
                                   "M_E",
                                   TokenPattern.PatternType.STRING,
                                   "-=");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.T_E,
                                   "T_E",
                                   TokenPattern.PatternType.STRING,
                                   "*=");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.D_E,
                                   "D_E",
                                   TokenPattern.PatternType.STRING,
                                   "/=");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.MOD_E,
                                   "Mod_E",
                                   TokenPattern.PatternType.STRING,
                                   "%=");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.NEWLINE,
                                   "NEWLINE",
                                   TokenPattern.PatternType.STRING,
                                   "\\n");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.N_E,
                                   "N_E",
                                   TokenPattern.PatternType.STRING,
                                   "!=");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.O_PAREN,
                                   "O_PAREN",
                                   TokenPattern.PatternType.STRING,
                                   "(");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.C_PAREN,
                                   "C_PAREN",
                                   TokenPattern.PatternType.STRING,
                                   ")");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.D_QUOTE,
                                   "D_QUOTE",
                                   TokenPattern.PatternType.REGEXP,
                                   "[\"]");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.COLON,
                                   "COLON",
                                   TokenPattern.PatternType.STRING,
                                   ":");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.O_BRACKET,
                                   "O_BRACKET",
                                   TokenPattern.PatternType.STRING,
                                   "{");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.C_BRACKET,
                                   "C_BRACKET",
                                   TokenPattern.PatternType.STRING,
                                   "}");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.GREATER,
                                   "GREATER",
                                   TokenPattern.PatternType.STRING,
                                   "<");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.LESS,
                                   "LESS",
                                   TokenPattern.PatternType.STRING,
                                   ">");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.GREATER_E,
                                   "GREATER_E",
                                   TokenPattern.PatternType.STRING,
                                   "<=");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.LESS_E,
                                   "LESS_E",
                                   TokenPattern.PatternType.STRING,
                                   ">=");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.S_OBRACKET,
                                   "S_OBRACKET",
                                   TokenPattern.PatternType.STRING,
                                   "[");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.S_CBRACKET,
                                   "S_CBRACKET",
                                   TokenPattern.PatternType.STRING,
                                   "]");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.DOLLAR,
                                   "DOLLAR",
                                   TokenPattern.PatternType.STRING,
                                   "$");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.POWER,
                                   "POWER",
                                   TokenPattern.PatternType.STRING,
                                   "^");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.HASH,
                                   "HASH",
                                   TokenPattern.PatternType.STRING,
                                   "#");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.NEGA,
                                   "NEGA",
                                   TokenPattern.PatternType.STRING,
                                   "~");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.INT,
                                   "INT",
                                   TokenPattern.PatternType.STRING,
                                   "unit");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.CHAR,
                                   "CHAR",
                                   TokenPattern.PatternType.STRING,
                                   "joe");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.FLOAT,
                                   "FLOAT",
                                   TokenPattern.PatternType.STRING,
                                   "digit");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.STRING,
                                   "STRING",
                                   TokenPattern.PatternType.STRING,
                                   "company");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.BOOL_N,
                                   "BOOL_N",
                                   TokenPattern.PatternType.STRING,
                                   "response");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.ID,
                                   "ID",
                                   TokenPattern.PatternType.STRING,
                                   "id");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.NUM,
                                   "NUM",
                                   TokenPattern.PatternType.STRING,
                                   "Numlit");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.DECIMAL,
                                   "DECIMAL",
                                   TokenPattern.PatternType.STRING,
                                   "Declit");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.S_CHAR,
                                   "S_CHAR",
                                   TokenPattern.PatternType.STRING,
                                   "Charlit");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.TEXT,
                                   "TEXT",
                                   TokenPattern.PatternType.STRING,
                                   "Stringlit");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.COM,
                                   "COM",
                                   TokenPattern.PatternType.STRING,
                                   "comment");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.YES,
                                   "YES",
                                   TokenPattern.PatternType.STRING,
                                   "AFFIRMATIVE");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.NO,
                                   "NO",
                                   TokenPattern.PatternType.STRING,
                                   "NEGATIVE");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.FUNCTNAME,
                                   "FUNCTNAME",
                                   TokenPattern.PatternType.STRING,
                                   "functName");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.STRUCTNAME,
                                   "STRUCTNAME",
                                   TokenPattern.PatternType.STRING,
                                   "structname");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.IDSTRUCT,
                                   "IDSTRUCT",
                                   TokenPattern.PatternType.STRING,
                                   "idStruct");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.F,
                                   "F",
                                   TokenPattern.PatternType.STRING,
                                   "f");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.D,
                                   "D",
                                   TokenPattern.PatternType.STRING,
                                   "d");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.S,
                                   "S",
                                   TokenPattern.PatternType.STRING,
                                   "s");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.ZERO,
                                   "ZERO",
                                   TokenPattern.PatternType.STRING,
                                   "Zero");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.SPACE,
                                   "SPACE",
                                   TokenPattern.PatternType.STRING,
                                   " ");
        pattern.Ignore = true;
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.N_LINE,
                                   "N_LINE",
                                   TokenPattern.PatternType.STRING,
                                   "\\n");
        pattern.Ignore = true;
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.WHITESPACE,
                                   "WHITESPACE",
                                   TokenPattern.PatternType.REGEXP,
                                   "[ \\t\\n\\r]+");
        pattern.Ignore = true;
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.TOCHAR,
                                   "TOCHAR",
                                   TokenPattern.PatternType.STRING,
                                   "ToJoeRange");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.LENGTHF,
                                   "LENGTHF",
                                   TokenPattern.PatternType.STRING,
                                   "Extent");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.CONTAINS,
                                   "CONTAINS",
                                   TokenPattern.PatternType.STRING,
                                   "Carry");
        AddPattern(pattern);

        pattern = new TokenPattern((int) SyntaxConstants.REVERSE,
                                   "REVERSE",
                                   TokenPattern.PatternType.STRING,
                                   "Swap");
        AddPattern(pattern);
    }
}
