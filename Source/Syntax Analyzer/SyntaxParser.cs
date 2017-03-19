/*
 * SyntaxParser.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using Core.Library;

/**
 * <remarks>A token stream parser.</remarks>
 */
public class SyntaxParser : RecursiveDescentParser {

    /**
     * <summary>An enumeration with the generated production node
     * identity constants.</summary>
     */
    private enum SynteticPatterns {
    }

    /**
     * <summary>Creates a new parser with a default analyzer.</summary>
     *
     * <param name='input'>the input stream to read from</param>
     *
     * <exception cref='ParserCreationException'>if the parser
     * couldn't be initialized correctly</exception>
     */
    public SyntaxParser(TextReader input)
        : base(input) {

        CreatePatterns();
    }

    /**
     * <summary>Creates a new parser.</summary>
     *
     * <param name='input'>the input stream to read from</param>
     *
     * <param name='analyzer'>the analyzer to parse with</param>
     *
     * <exception cref='ParserCreationException'>if the parser
     * couldn't be initialized correctly</exception>
     */
    public SyntaxParser(TextReader input, SyntaxAnalyzer analyzer)
        : base(input, analyzer) {

        CreatePatterns();
    }

    /**
     * <summary>Creates a new tokenizer for this parser. Can be overridden
     * by a subclass to provide a custom implementation.</summary>
     *
     * <param name='input'>the input stream to read from</param>
     *
     * <returns>the tokenizer created</returns>
     *
     * <exception cref='ParserCreationException'>if the tokenizer
     * couldn't be initialized correctly</exception>
     */
    protected override Tokenizer NewTokenizer(TextReader input) {
        return new SyntaxTokenizer(input);
    }

    /**
     * <summary>Initializes the parser by creating all the production
     * patterns.</summary>
     *
     * <exception cref='ParserCreationException'>if the parser
     * couldn't be initialized correctly</exception>
     */
    private void CreatePatterns() {
        ProductionPattern             pattern;
        ProductionPatternAlternative  alt;

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_START_PROGRAM,
                                        "Prod_StartProgram");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_PROGRAM, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_END, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_PROGRAM,
                                        "Prod_program");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_GLOBAL_DEC, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_MAIN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_CLEAR,
                                        "Prod_Clear");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.CLEAR, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_COMMENTS,
                                        "Prod_comments");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.COM, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_NEGATE,
                                        "Prod_Negate");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.NEGA, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_DATATYPE,
                                        "Prod_datatype");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.INT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.FLOAT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.STRING, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.CHAR, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.BOOL_N, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_LITERALS,
                                        "Prod_Literals");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_NEGATE, 0, 1);
        alt.AddToken((int) SyntaxConstants.NUM, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.DECIMAL, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.TEXT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.S_CHAR, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.YES, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.NO, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_LITERALS2,
                                        "Prod_Literals2");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_NEGATE, 0, 1);
        alt.AddToken((int) SyntaxConstants.NUM, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.DECIMAL, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.TEXT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.S_CHAR, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_GLOBAL_DEC,
                                        "Prod_globalDec");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_DATATYPE, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_DECLARE, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.VOID, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_FUNCTVOID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.STRUCT_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_STRUCT, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.CONST_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CONSTANT, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_DECLARE,
                                        "Prod_Declare");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_DECLARE_CHOICE, 0, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_GLOBAL_DEC, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CLEAR, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_FUNCTRET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_GLOBAL_DEC, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CLEAR, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_DECLARE_CHOICE,
                                        "Prod_DeclareChoice");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_INIT_CHOICE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_N1, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ARRAY_AID, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_INIT_CHOICE,
                                        "Prod_InitChoice");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_INIT_CHOICE, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_LITERALS, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ADD_ID, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ADD_ID,
                                        "Prod_addID");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_INIT_CHOICE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_N1,
                                        "Prod_N1");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.S_OBRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_INDEX, 1, 1);
        alt.AddToken((int) SyntaxConstants.S_CBRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_N2, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_N2,
                                        "Prod_N2");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.S_OBRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_INDEX, 1, 1);
        alt.AddToken((int) SyntaxConstants.S_CBRACKET, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_INDEX,
                                        "Prod_index");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.NUM, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_SMATH, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_SMATH, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_SMATH,
                                        "Prod_Smath");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_SYM, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_INDEX, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ARRAY_AID,
                                        "Prod_arrayAID");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ELEM_CHOICE, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ELEM_CHOICE,
                                        "Prod_ElemChoice");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_ELEMENT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ELEMENT, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_M_ELEM, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ELEMENT,
                                        "Prod_Element");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_LITERALS2, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ADD_ELEM, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ADD_ELEM,
                                        "Prod_addElem");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ELEMENT, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_M_ELEM,
                                        "Prod_M_Elem");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ELEMENT, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_M2_ELEM, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_M2_ELEM,
                                        "Prod_M2_Elem");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_M_ELEM, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_FUNCTRET,
                                        "Prod_functret");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_DTYPE_A, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        alt.AddToken((int) SyntaxConstants.RETURN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_RETURN, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_GLOBAL_DEC, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_DTYPE_A,
                                        "Prod_dtypeA");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_DATATYPE, 0, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_N1, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_EXDTYPE_A, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_EXDTYPE_A,
                                        "Prod_EXdtypeA");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_DTYPE_A, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_RETURN,
                                        "Prod_return");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_LITERALS, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_NEGATE, 0, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OUT_C, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.SQROOT, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_RETURN, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_FUNCTVOID,
                                        "Prod_functvoid");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_DTYPE_A, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_GLOBAL_DEC, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_STRUCT,
                                        "Prod_struct");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_MEM_DEC, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_GLOBAL_DEC, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CLEAR, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_MEM_DEC,
                                        "Prod_memDec");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_DATATYPE, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_INIT_DEC, 0, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_MEM_DEC, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_INIT_DEC,
                                        "Prod_initDec");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_INIT_DEC_CHOICE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_N1, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_INIT_DEC_CHOICE,
                                        "Prod_initDecChoice");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_INIT_DEC_CHOICE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONSTANT,
                                        "Prod_constant");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_LITERALS, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_GLOBAL_DEC, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CLEAR, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_LOCAL_CHOICE,
                                        "Prod_LocalChoice");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_DATATYPE, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_DECLARE1, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CLEAR, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.VOID, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_FUNCTVOID1, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CLEAR, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.STRUCT_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_STRUCT1, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CLEAR, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.CONST_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CONSTANT1, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CLEAR, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_DECLARE1,
                                        "Prod_Declare1");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_DECLARE_CHOICE, 0, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_LOCAL_CHOICE, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_FUNCTRET1, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_LOCAL_CHOICE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_FUNCTRET1,
                                        "Prod_functret1");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_DTYPE_A, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        alt.AddToken((int) SyntaxConstants.RETURN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_RETURN, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_LOCAL_CHOICE, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_FUNCTVOID1,
                                        "Prod_functvoid1");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_DTYPE_A, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_LOCAL_CHOICE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_STRUCT1,
                                        "Prod_struct1");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_MEM_DEC, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_LOCAL_CHOICE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONSTANT1,
                                        "Prod_constant1");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_LITERALS, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_LOCAL_CHOICE, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CLEAR, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_MAIN,
                                        "Prod_main");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.MAIN_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ASSIGN_CHOICE,
                                        "Prod_assignChoice");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_ACCESS_ASSIGN_DTYPE, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_MNT_COND_T, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.REVERSE, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_RETURN, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ACCESS_ASSIGN_DTYPE,
                                        "Prod_AccessAssignDtype");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ASSIGN_VALUE_CHOICE, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ASSIGN_VALUE_CHOICE,
                                        "Prod_assignValueChoice");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_ASSIGNING, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ASSIGN_VALUE, 0, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ASSIGN_CHOICE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ASSIGNING,
                                        "Prod_assigning");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_ARRAY_ID, 1, 1);
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_ASSIGN_SYM, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_MATH_OP, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.DOT, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_MNT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_FUNCT_PARAM, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ARRAY_ID,
                                        "Prod_ArrayID");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.S_OBRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_INDEX, 1, 1);
        alt.AddToken((int) SyntaxConstants.S_CBRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ARRAY_IDTAIL, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ARRAY_IDTAIL,
                                        "Prod_ArrayIDTail");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.S_OBRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_INDEX, 1, 1);
        alt.AddToken((int) SyntaxConstants.S_CBRACKET, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ASSIGN_SYM,
                                        "Prod_AssignSym");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_SYM, 1, 1);
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ASSIGN_VALUE,
                                        "Prod_assignValue");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_MATH_OP, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_FUNCT_PARAM, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONVERT,
                                        "Prod_Convert");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.TOCHAR, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.LENGTHF, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.CONTAINS, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_RETURN, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_FUNCT_PARAM,
                                        "Prod_functParam");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_FUNCT_IDPARAM, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_SYM, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPERAND, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_FUNCT_PARAM, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_FUNCT_IDPARAM,
                                        "Prod_functIDParam");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPERAND, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ADDFUNCT_IDPARAM, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ADDFUNCT_IDPARAM,
                                        "Prod_addfunctIDParam");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPERAND, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ADDFUNCT_IDPARAM, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_BODY,
                                        "Prod_body");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_LOCAL_CHOICE, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_PRINT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_SCAN, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_FOR_STATE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_IFELSE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_DOWHILE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_WHILE_STATE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_SWITCH_STATE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_ASSIGN_CHOICE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_COMMENTS, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_CLEAR, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.BREAK, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_PRINT,
                                        "Prod_print");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.PRINT_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_POSTVAL, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_POSTVAL,
                                        "Prod_postval");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OUT, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CONCAT_LIT, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_OUT,
                                        "Prod_Out");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_RETURN, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_OUT_C,
                                        "Prod_OutC");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_ARRAY_ID, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPERAND, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ADDFUNCT_IDPARAM, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.DOT, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CONVERT, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_CONCAT_LIT,
                                        "Prod_ConcatLit");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.PLUS, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OUT, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CONCAT_LIT, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_SCAN,
                                        "Prod_scan");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.SCAN_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.HASH, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ARRAY_ID, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_EXT_I, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_EXT_I,
                                        "Prod_ExtI");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
        alt.AddToken((int) SyntaxConstants.HASH, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ARRAY_ID, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_EXT_I, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_FOR_STATE,
                                        "Prod_for_state");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.FOR_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_VAL1, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ARRAY_ID, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OP1, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_VAL1, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_MNT_COND, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_FORSTATEMENT, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_FORSTATEMENT,
                                        "Prod_forstatement");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_VAL1,
                                        "Prod_val1");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.NUM, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ARRAY_ID, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_MNT_COND,
                                        "Prod_mntCond");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_MNT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_MNT_COND_T, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_MNT_COND_T,
                                        "Prod_mntCondT");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_MNT, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_MNT,
                                        "Prod_mnt");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.INCREMENT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.DECREMENT, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_IFELSE,
                                        "Prod_ifelse");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.IF, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_IFCONDITION, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_IFSTATEMENT, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ELSEIF, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ELSE_STATE, 0, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_IFCONDITION,
                                        "Prod_ifcondition");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_REL_OP, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_LOG_OP, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_IFSTATEMENT,
                                        "Prod_ifstatement");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.RETURN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_RETURN, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ELSEIF,
                                        "Prod_elseif");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.ELSEIF_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_IFCONDITION, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ELSEIFSTATEMENT, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ELSEIF, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ELSEIFSTATEMENT,
                                        "Prod_elseifstatement");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.RETURN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_RETURN, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ELSE_STATE,
                                        "Prod_else_state");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.ELSE_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_ELSESTATEMENT, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_ELSESTATEMENT,
                                        "Prod_elsestatement");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.RETURN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_RETURN, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_DOWHILE,
                                        "Prod_dowhile");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.DO, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_DOSTATEMENT, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddToken((int) SyntaxConstants.WHILE_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_IFCONDITION, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_DOSTATEMENT,
                                        "Prod_dostatement");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_WHILE_STATE,
                                        "Prod_while_state");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.WHILE_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_IFCONDITION, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_WHILESTATEMENT, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_WHILESTATEMENT,
                                        "Prod_whilestatement");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_SWITCH_STATE,
                                        "Prod_switch_state");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.SWITCH_N, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.ID, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CASE_STATE, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_DEF, 0, 1);
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_CASE_STATE,
                                        "Prod_case_state");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.CASE_N, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_LITERALS, 1, 1);
        alt.AddToken((int) SyntaxConstants.COLON, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CASESTATEMENT, 0, 1);
        alt.AddToken((int) SyntaxConstants.BREAK, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CASE_STATE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_DEF,
                                        "Prod_def");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.DEFAULT, 1, 1);
        alt.AddToken((int) SyntaxConstants.COLON, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_CASESTATEMENT, 0, 1);
        alt.AddToken((int) SyntaxConstants.BREAK, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_CASESTATEMENT,
                                        "Prod_casestatement");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_BODY, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_MATH_OP,
                                        "Prod_MathOp");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_COND, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPER_COND,
                                        "Prod_operCond");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPERAND, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_SYM, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_EXT_S, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_COND_EXT, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPERAND, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_COND_CHOICE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPER_COND_CHOICE,
                                        "Prod_operCondChoice");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_SYM, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_EXT_S, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPER_SYM,
                                        "Prod_operSym");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.PLUS, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.MINUS, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.TIMES, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.DIVIDE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.MODULUS, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.POWER, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.DOT, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPER_EQ,
                                        "Prod_operEq");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.P_E, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.M_E, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.T_E, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.D_E, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.MOD_E, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPER_EXT_S,
                                        "Prod_operExt_s");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPERAND, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_S_MATH_EXT, 0, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_SIM_MATH_OP, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_EXT_REP, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPER_EXT_REP,
                                        "Prod_operExt_rep");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_SYM, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_EXT_S, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPERAND,
                                        "Prod_operand");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_RETURN, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_SIM_MATH_OP,
                                        "Prod_simMathOp");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPERAND, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_S_MATH_EXT, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_S_MATH_EXT,
                                        "Prod_S_MathExt");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_SYM, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPERAND, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_S_MATH_EXT, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_OPER_COND_EXT,
                                        "Prod_operCondExt");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_SYM, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_EXT_S, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_REL_OP,
                                        "Prod_RelOp");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPERAND, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_RELOP_EXT, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_RELOP_EXT,
                                        "Prod_RelopExt");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OP1, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_OPERAND, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_RELOP_EXT, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_OP1,
                                        "Prod_op1");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.N_E, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.GREATER, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.LESS, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.GREATER_E, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.LESS_E, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        alt.AddToken((int) SyntaxConstants.EQUALS, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_OPER_EQ, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.MODULUS, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_LOG_OP,
                                        "Prod_LogOp");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_REL_OP, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_EXT_LOG_OP, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_EXT_LOG_OP,
                                        "Prod_ExtLogOp");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) SyntaxConstants.PROD_LOG_OPER, 1, 1);
        alt.AddProduction((int) SyntaxConstants.PROD_LOG_OP, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_LOG_OPER,
                                        "Prod_LogOper");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.OR, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.AND, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SyntaxConstants.PROD_END,
                                        "Prod_end");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) SyntaxConstants.C_BRACKET, 1, 1);
        alt.AddToken((int) SyntaxConstants.GETCH, 1, 1);
        alt.AddToken((int) SyntaxConstants.O_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.C_PAREN, 1, 1);
        alt.AddToken((int) SyntaxConstants.SEMIC, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);
    }
}
