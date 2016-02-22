using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using bitzhuwei.CompilerBase;

namespace CSharpShadingLanguage.Compiler
{
    /// <summary>
    /// CSSLCompiler的词法分析器
    /// </summary>
    public partial class LexicalAnalyzerCSSLCompiler : LexicalAnalyzerBase<EnumTokenTypeCSSLCompiler>
    {
        /// <summary>
        /// CSSLCompiler的词法分析器
        /// </summary>
        public LexicalAnalyzerCSSLCompiler()
        { }
        /// <summary>
        /// CSSLCompiler的词法分析器
        /// </summary>
        /// <param name="sourceCode">要分析的源代码</param>
        public LexicalAnalyzerCSSLCompiler(string sourceCode)
            : base(sourceCode)
        { }
        /// <summary>
        /// 从<code>PtNextLetter</code>开始获取下一个<code>Token</code>
        /// </summary>
        /// <returns></returns>
        protected override Token<EnumTokenTypeCSSLCompiler> NextToken()
        {
            var result = new Token<EnumTokenTypeCSSLCompiler>();
            result.Line = m_CurrentLine;
            result.Column = m_CurrentColumn;
            result.IndexOfSourceCode = PtNextLetter;
            var count = this.GetSourceCode().Length;
            if (PtNextLetter < 0 || PtNextLetter >= count) return result;
            var gotToken = false;
            var ct = GetCharType(this.GetSourceCode()[PtNextLetter]);
            switch (ct)
            {
                case EnumCharTypeCSSLCompiler.Reverse:
                    gotToken = GetReverseOpt(result);
                    break;
                case EnumCharTypeCSSLCompiler.Not:
                    gotToken = GetNotOpt(result);
                    break;
                case EnumCharTypeCSSLCompiler.At:
                    gotToken = GetAt(result);
                    break;
                case EnumCharTypeCSSLCompiler.Pound:
                    gotToken = GetPound(result);
                    break;
                case EnumCharTypeCSSLCompiler.Percent:
                    gotToken = GetPercentOpt(result);
                    break;
                case EnumCharTypeCSSLCompiler.Xor:
                    gotToken = GetXorOpt(result);
                    break;
                case EnumCharTypeCSSLCompiler.And:
                    gotToken = GetAndOpt(result);
                    break;
                case EnumCharTypeCSSLCompiler.Multiply:
                    gotToken = GetMultiplyOpt(result);
                    break;
                case EnumCharTypeCSSLCompiler.LeftParentheses:
                    gotToken = GetLeftParentheses(result);
                    break;
                case EnumCharTypeCSSLCompiler.RightParentheses:
                    gotToken = GetRightParentheses(result);
                    break;
                case EnumCharTypeCSSLCompiler.Plus:
                    gotToken = GetPlusOpt(result);
                    break;
                case EnumCharTypeCSSLCompiler.LeftBrace:
                    gotToken = GetLeftBrace(result);
                    break;
                case EnumCharTypeCSSLCompiler.RightBrace:
                    gotToken = GetRightBrace(result);
                    break;
                case EnumCharTypeCSSLCompiler.LeftBracket:
                    gotToken = GetLeftBracket(result);
                    break;
                case EnumCharTypeCSSLCompiler.RightBracket:
                    gotToken = GetRightBracket(result);
                    break;
                case EnumCharTypeCSSLCompiler.Colon:
                    gotToken = GetColon(result);
                    break;
                case EnumCharTypeCSSLCompiler.Semicolon:
                    gotToken = GetSemicolon(result);
                    break;
                case EnumCharTypeCSSLCompiler.LessThan:
                    gotToken = GetLessThanOpt(result);
                    break;
                case EnumCharTypeCSSLCompiler.GreaterThan:
                    gotToken = GetGreaterThanOpt(result);
                    break;
                case EnumCharTypeCSSLCompiler.Comma:
                    gotToken = GetComma(result);
                    break;
                case EnumCharTypeCSSLCompiler.Dot:
                    gotToken = GetDot(result);
                    break;
                case EnumCharTypeCSSLCompiler.Question:
                    gotToken = GetQuestion(result);
                    break;
                case EnumCharTypeCSSLCompiler.Divide:
                    gotToken = GetDivideOpt(result);
                    break;
                case EnumCharTypeCSSLCompiler.Space:
                    gotToken = GetSpace(result);
                    break;
                default:
                    gotToken = GetUnknown(result);
                    break;
            }
            if (gotToken)
            {
                result.Length = PtNextLetter - result.IndexOfSourceCode;
                return result;
            }
            else
                return null;
        }
        #region 获取某类型的单词
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetReverseOpt(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Reverse
//todo: maybe you need to set TokenType to their right position.
            //Mapped nodes:
            //    "~"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Reverse_;
            //    "~="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Reverse_Equality_;
            if (PtNextLetter + 2 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 2);
                if ("~=" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Reverse_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
            }
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("~" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Reverse_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetNotOpt(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Not
//todo: maybe you need to set TokenType to their right position.
            //Mapped nodes:
            //    "!"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Not_;
            //    "!="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Not_Equality_;
            if (PtNextLetter + 2 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 2);
                if ("!=" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Not_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
            }
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("!" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Not_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetAt(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: At
            //Mapped nodes:
            //    "@"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_At;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("@" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_At;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetPound(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Pound
            //Mapped nodes:
            //    "#"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Pound_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("#" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Pound_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetPercentOpt(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Percent
//todo: maybe you need to set TokenType to their right position.
            //Mapped nodes:
            //    "%"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Percent_;
            //    "%="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Percent_Equality_;
            if (PtNextLetter + 2 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 2);
                if ("%=" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Percent_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
            }
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("%" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Percent_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetXorOpt(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Xor
//todo: maybe you need to set TokenType to their right position.
            //Mapped nodes:
            //    "^"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Xor_;
            //    "^="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Xor_Equality_;
            if (PtNextLetter + 2 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 2);
                if ("^=" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Xor_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
            }
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("^" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Xor_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetAndOpt(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: And
//todo: maybe you need to set TokenType to their right position.
            //Mapped nodes:
            //    "&"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_And_;
            //    "&="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_And_Equality_;
            //    "&&"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_And_And_;
            if (PtNextLetter + 2 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 2);
                if ("&=" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_And_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
                if ("&&" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_And_And_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
            }
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("&" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_And_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetMultiplyOpt(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Multiply
//todo: maybe you need to set TokenType to their right position.
            //Mapped nodes:
            //    "*"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Multiply_;
            //    "*="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Multiply_Equality_;
            if (PtNextLetter + 2 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 2);
                if ("*=" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Multiply_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
            }
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("*" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Multiply_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetLeftParentheses(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: LeftParentheses
            //Mapped nodes:
            //    "("
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_LeftParentheses_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("(" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_LeftParentheses_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetRightParentheses(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: RightParentheses
            //Mapped nodes:
            //    ")"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_RightParentheses_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if (")" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_RightParentheses_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetPlusOpt(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Plus
//todo: maybe you need to set TokenType to their right position.
            //Mapped nodes:
            //    "+"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Plus_;
            //    "+="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Plus_Equality_;
            //    "++"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Plus_Plus_;
            if (PtNextLetter + 2 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 2);
                if ("+=" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Plus_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
                if ("++" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Plus_Plus_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
            }
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("+" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Plus_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetLeftBrace(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: LeftBrace
            //Mapped nodes:
            //    "{"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_LeftBrace_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("{" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_LeftBrace_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetRightBrace(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: RightBrace
            //Mapped nodes:
            //    "}"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_RightBrace_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("}" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_RightBrace_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetLeftBracket(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: LeftBracket
            //Mapped nodes:
            //    "["
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_LeftBracket_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("[" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_LeftBracket_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetRightBracket(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: RightBracket
            //Mapped nodes:
            //    "]"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_RightBracket_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("]" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_RightBracket_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetColon(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Colon
            //Mapped nodes:
            //    ":"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Colon_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if (":" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Colon_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetSemicolon(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Semicolon
            //Mapped nodes:
            //    ";"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Semicolon_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if (";" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Semicolon_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetLessThanOpt(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: LessThan
//todo: maybe you need to set TokenType to their right position.
            //Mapped nodes:
            //    "<"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_LessThan_;
            //    "<="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_LessThan_Equality_;
            //    "<<"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_LessThan_LessThan_;
            if (PtNextLetter + 2 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 2);
                if ("<=" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_LessThan_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
                if ("<<" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_LessThan_LessThan_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
            }
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("<" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_LessThan_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetGreaterThanOpt(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: GreaterThan
//todo: maybe you need to set TokenType to their right position.
            //Mapped nodes:
            //    ">"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_GreaterThan_;
            //    ">="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_GreaterThan_Equality_;
            //    ">>"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_GreaterThan_GreaterThan_;
            if (PtNextLetter + 2 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 2);
                if (">=" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_GreaterThan_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
                if (">>" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_GreaterThan_GreaterThan_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
            }
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if (">" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_GreaterThan_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetComma(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Comma
            //Mapped nodes:
            //    ","
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Comma_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("," == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Comma_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetDot(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Dot
            //Mapped nodes:
            //    "."
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Dot_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("." == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Dot_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetQuestion(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Question
            //Mapped nodes:
            //    "?"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Question_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("?" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Question_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// )
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetDivideOpt(Token<EnumTokenTypeCSSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Divide
//todo: maybe you need to set TokenType to their right position.
            //Mapped nodes:
            //    "/"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Divide_;
            //    "/="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Divide_Equality_;
            if (PtNextLetter + 2 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 2);
                if ("/=" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Divide_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
            }
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("/" == str)
                {
                    result.TokenType = EnumTokenTypeCSSLCompiler.token_Divide_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        /// <summary>
        /// 未知符号
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetUnknown(Token<EnumTokenTypeCSSLCompiler> result)
        {
            result.TokenType = EnumTokenTypeCSSLCompiler.unknown;
            result.Detail = this.GetSourceCode()[PtNextLetter].ToString();
            result.LexicalError = true;
            result.Tag = string.Format("发现未知字符[{0}]。", result.Detail);
            PtNextLetter++;
            return true;
        }
        /// <summary>
        /// space tab \r \n
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetSpace(Token<EnumTokenTypeCSSLCompiler> result)
        {
            char c = this.GetSourceCode()[PtNextLetter];
            PtNextLetter++;
            if (c == '\n')// || c == '\r') //换行：Windows：\r\n Linux：\n
            {
                this.m_CurrentLine++;
                this.m_CurrentColumn = 0;
            }
            return false;
        }
        /// <summary>
        /// 跳过多行注释
        /// </summary>
        /// <returns></returns>
        protected virtual void SkipMultilineNote()
        {
            int count = this.GetSourceCode().Length;
            while (PtNextLetter < count)
            {
                if (GetSourceCode()[PtNextLetter] == '*')
                {
                    PtNextLetter++;
                    if (PtNextLetter < count)
                    {
                        if (GetSourceCode()[PtNextLetter] == '/')
                        {
                            PtNextLetter++;
                            break;
                        }
                        else
                            PtNextLetter++;
                    }
                }
                else
                    PtNextLetter++;
            }
        }
        /// <summary>
        /// 跳过单行注释
        /// </summary>
        /// <returns></returns>
        protected virtual void SkipSingleLineNote()
        {
            int count = this.GetSourceCode().Length;
            char cNext;
            while (PtNextLetter < count)
            {
                cNext = GetSourceCode()[PtNextLetter];
                if (cNext == '\r' || cNext == '\n')
                {
                    break;
                }
                PtNextLetter++;
            }
        }
        #endregion 获取某类型的单词
        /// <summary>
        /// 获取字符类型
        /// </summary>
        /// <param name="c">要归类的字符</param>
        /// <returns></returns>
        protected virtual EnumCharTypeCSSLCompiler GetCharType(char c)
        {
            if (('a' <= c && c <= 'z') || ('A' <= c && c <= 'Z')) return EnumCharTypeCSSLCompiler.Letter;
            if ('0' <= c && c <= '9') return EnumCharTypeCSSLCompiler.Number;
            if (c == '_') return EnumCharTypeCSSLCompiler.UnderLine;
            if (c == '.') return EnumCharTypeCSSLCompiler.Dot;
            if (c == ',') return EnumCharTypeCSSLCompiler.Comma;
            if (c == '+') return EnumCharTypeCSSLCompiler.Plus;
            if (c == '-') return EnumCharTypeCSSLCompiler.Minus;
            if (c == '*') return EnumCharTypeCSSLCompiler.Multiply;
            if (c == '/') return EnumCharTypeCSSLCompiler.Divide;
            if (c == '%') return EnumCharTypeCSSLCompiler.Percent;
            if (c == '^') return EnumCharTypeCSSLCompiler.Xor;
            if (c == '&') return EnumCharTypeCSSLCompiler.And;
            if (c == '|') return EnumCharTypeCSSLCompiler.Or;
            if (c == '~') return EnumCharTypeCSSLCompiler.Reverse;
            if (c == '$') return EnumCharTypeCSSLCompiler.Dollar;
            if (c == '<') return EnumCharTypeCSSLCompiler.LessThan;
            if (c == '>') return EnumCharTypeCSSLCompiler.GreaterThan;
            if (c == '(') return EnumCharTypeCSSLCompiler.LeftParentheses;
            if (c == ')') return EnumCharTypeCSSLCompiler.RightParentheses;
            if (c == '[') return EnumCharTypeCSSLCompiler.LeftBracket;
            if (c == ']') return EnumCharTypeCSSLCompiler.RightBracket;
            if (c == '{') return EnumCharTypeCSSLCompiler.LeftBrace;
            if (c == '}') return EnumCharTypeCSSLCompiler.RightBrace;
            if (c == '!') return EnumCharTypeCSSLCompiler.Not;
            if (c == '#') return EnumCharTypeCSSLCompiler.Pound;
            if (c == '\\') return EnumCharTypeCSSLCompiler.Slash;
            if (c == '?') return EnumCharTypeCSSLCompiler.Question;
            if (c == '\'') return EnumCharTypeCSSLCompiler.Quotation;
            if (c == '"') return EnumCharTypeCSSLCompiler.DoubleQuotation;
            if (c == ':') return EnumCharTypeCSSLCompiler.Colon;
            if (c == ';') return EnumCharTypeCSSLCompiler.Semicolon;
            if (c == '=') return EnumCharTypeCSSLCompiler.Equality;
            if (regChineseLetter.IsMatch(Convert.ToString(c))) return EnumCharTypeCSSLCompiler.ChineseLetter;
            if (c == ' ' || c == '\t' || c == '\r' || c == '\n') return EnumCharTypeCSSLCompiler.Space;
            return EnumCharTypeCSSLCompiler.Unknown;
        }
        /// <summary>
        /// 汉字 new Regex("^[^\x00-\xFF]")
        /// </summary>
        private static readonly Regex regChineseLetter = new Regex("^[^\x00-\xFF]");
    }

}

