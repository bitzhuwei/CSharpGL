using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using bitzhuwei.CompilerBase;

namespace CSharpGL.GLSLCompiler
{
    /// <summary>
    /// CSSLCompiler的词法分析器
    /// </summary>
    public partial class LexicalAnalyzerGLSLCompiler : LexicalAnalyzerBase<EnumTokenTypeGLSLCompiler>
    {
        /// <summary>
        /// CSSLCompiler的词法分析器
        /// </summary>
        public LexicalAnalyzerGLSLCompiler()
        { }
        /// <summary>
        /// CSSLCompiler的词法分析器
        /// </summary>
        /// <param name="sourceCode">要分析的源代码</param>
        public LexicalAnalyzerGLSLCompiler(string sourceCode)
            : base(sourceCode)
        { }
        /// <summary>
        /// 从<code>PtNextLetter</code>开始获取下一个<code>Token</code>
        /// </summary>
        /// <returns></returns>
        protected override Token<EnumTokenTypeGLSLCompiler> NextToken()
        {
            var result = new Token<EnumTokenTypeGLSLCompiler>();
            result.Line = m_CurrentLine;
            result.Column = m_CurrentColumn;
            result.IndexOfSourceCode = PtNextLetter;
            var count = this.GetSourceCode().Length;
            if (PtNextLetter < 0 || PtNextLetter >= count) return result;
            var gotToken = false;
            var ct = GetCharType(this.GetSourceCode()[PtNextLetter]);
            switch (ct)
            {
                case EnumCharTypeGLSLCompiler.Reverse:
                    gotToken = GetReverseOpt(result);
                    break;
                case EnumCharTypeGLSLCompiler.Not:
                    gotToken = GetNotOpt(result);
                    break;
                case EnumCharTypeGLSLCompiler.At:
                    gotToken = GetAt(result);
                    break;
                case EnumCharTypeGLSLCompiler.Pound:
                    gotToken = GetPound(result);
                    break;
                case EnumCharTypeGLSLCompiler.Percent:
                    gotToken = GetPercentOpt(result);
                    break;
                case EnumCharTypeGLSLCompiler.Xor:
                    gotToken = GetXorOpt(result);
                    break;
                case EnumCharTypeGLSLCompiler.And:
                    gotToken = GetAndOpt(result);
                    break;
                case EnumCharTypeGLSLCompiler.Multiply:
                    gotToken = GetMultiplyOpt(result);
                    break;
                case EnumCharTypeGLSLCompiler.LeftParentheses:
                    gotToken = GetLeftParentheses(result);
                    break;
                case EnumCharTypeGLSLCompiler.RightParentheses:
                    gotToken = GetRightParentheses(result);
                    break;
                case EnumCharTypeGLSLCompiler.Minus:
                    gotToken = GetMinusOpt(result);
                    break;
                case EnumCharTypeGLSLCompiler.Plus:
                    gotToken = GetPlusOpt(result);
                    break;
                case EnumCharTypeGLSLCompiler.Equality:
                    gotToken = GetEquality(result);
                    break;
                case EnumCharTypeGLSLCompiler.LeftBrace:
                    gotToken = GetLeftBrace(result);
                    break;
                case EnumCharTypeGLSLCompiler.RightBrace:
                    gotToken = GetRightBrace(result);
                    break;
                case EnumCharTypeGLSLCompiler.LeftBracket:
                    gotToken = GetLeftBracket(result);
                    break;
                case EnumCharTypeGLSLCompiler.RightBracket:
                    gotToken = GetRightBracket(result);
                    break;
                case EnumCharTypeGLSLCompiler.Colon:
                    gotToken = GetColon(result);
                    break;
                case EnumCharTypeGLSLCompiler.Semicolon:
                    gotToken = GetSemicolon(result);
                    break;
                case EnumCharTypeGLSLCompiler.LessThan:
                    gotToken = GetLessThanOpt(result);
                    break;
                case EnumCharTypeGLSLCompiler.GreaterThan:
                    gotToken = GetGreaterThanOpt(result);
                    break;
                case EnumCharTypeGLSLCompiler.Comma:
                    gotToken = GetComma(result);
                    break;
                case EnumCharTypeGLSLCompiler.Dot:
                    gotToken = GetDot(result);
                    break;
                case EnumCharTypeGLSLCompiler.Question:
                    gotToken = GetQuestion(result);
                    break;
                case EnumCharTypeGLSLCompiler.Divide:
                    gotToken = GetDivideOpt(result);
                    break;
                case EnumCharTypeGLSLCompiler.DoubleQuotation:
                    gotToken = GetConstentString(result);
                    break;
                case EnumCharTypeGLSLCompiler.Letter:
                    gotToken = GetIdentifier(result);
                    break;
                case EnumCharTypeGLSLCompiler.Number:
                    gotToken = GetConstentNumber(result);
                    break;
                case EnumCharTypeGLSLCompiler.Space:
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
        protected virtual bool GetReverseOpt(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Reverse_Equality_;
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Reverse_;
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
        protected virtual bool GetNotOpt(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Not_Equality_;
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Not_;
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
        protected virtual bool GetAt(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_At;
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
        protected virtual bool GetPound(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Pound_;
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
        protected virtual bool GetPercentOpt(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Percent_Equality_;
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Percent_;
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
        protected virtual bool GetXorOpt(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Xor_Equality_;
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Xor_;
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
        protected virtual bool GetAndOpt(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_And_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
                if ("&&" == str)
                {
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_And_And_;
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_And_;
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
        protected virtual bool GetMultiplyOpt(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Multiply_Equality_;
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Multiply_;
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
        protected virtual bool GetLeftParentheses(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_LeftParentheses_;
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
        protected virtual bool GetRightParentheses(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_RightParentheses_;
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
        protected virtual bool GetMinusOpt(Token<EnumTokenTypeGLSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Minus
//todo: maybe you need to set TokenType to their right position.
            //Mapped nodes:
            //    "-"
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Minus_;
            //    "-="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Minus_Equality_;
            if (PtNextLetter + 2 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 2);
                if ("-=" == str)
                {
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Minus_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
            }
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("-" == str)
                {
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Minus_;
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
        protected virtual bool GetPlusOpt(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Plus_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
                if ("++" == str)
                {
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Plus_Plus_;
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Plus_;
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
        protected virtual bool GetEquality(Token<EnumTokenTypeGLSLCompiler> result)
        {
            var count = this.GetSourceCode().Length;
            //item.CharType: Equality
            //Mapped nodes:
            //    "="
            //result.TokenType = EnumTokenTypeCSSLCompiler.token_Equality_;
            if (PtNextLetter + 1 <= count)
            {
                var str = this.GetSourceCode().Substring(PtNextLetter, 1);
                if ("=" == str)
                {
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Equality_;
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
        protected virtual bool GetLeftBrace(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_LeftBrace_;
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
        protected virtual bool GetRightBrace(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_RightBrace_;
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
        protected virtual bool GetLeftBracket(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_LeftBracket_;
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
        protected virtual bool GetRightBracket(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_RightBracket_;
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
        protected virtual bool GetColon(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Colon_;
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
        protected virtual bool GetSemicolon(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Semicolon_;
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
        protected virtual bool GetLessThanOpt(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_LessThan_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
                if ("<<" == str)
                {
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_LessThan_LessThan_;
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_LessThan_;
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
        protected virtual bool GetGreaterThanOpt(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_GreaterThan_Equality_;
                    result.Detail = str;
                    PtNextLetter += 2;
                    return true;
                }
                if (">>" == str)
                {
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_GreaterThan_GreaterThan_;
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_GreaterThan_;
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
        protected virtual bool GetComma(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Comma_;
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
        protected virtual bool GetDot(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Dot_;
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
        protected virtual bool GetQuestion(Token<EnumTokenTypeGLSLCompiler> result)
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Question_;
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
        protected virtual bool GetDivideOpt(Token<EnumTokenTypeGLSLCompiler> result)
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
                if ("//" == str) { SkipSingleLineNote(); return false; }
                if ("/=" == str)
                {
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Divide_Equality_;
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
                    result.TokenType = EnumTokenTypeGLSLCompiler.token_Divide_;
                    result.Detail = str;
                    PtNextLetter += 1;
                    return true;
                }
            }
            
            return false;
        }
        #region GetIdentifier
        /// <summary>
        /// 获取标识符（函数名，变量名，等）
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetIdentifier(Token<EnumTokenTypeGLSLCompiler> result)
        {
            result.TokenType = EnumTokenTypeGLSLCompiler.identifier;
            StringBuilder builder = new StringBuilder();
            while (PtNextLetter < this.GetSourceCode().Length)
            {
                var ct = GetCharType(this.GetSourceCode()[PtNextLetter]);
                if (ct == EnumCharTypeGLSLCompiler.Letter
                    || ct == EnumCharTypeGLSLCompiler.Number
                    || ct == EnumCharTypeGLSLCompiler.UnderLine
                    || ct == EnumCharTypeGLSLCompiler.ChineseLetter)
                {
                    builder.Append(this.GetSourceCode()[PtNextLetter]);
                    PtNextLetter++;
                }
                else
                    break;
            }
            result.Detail = builder.ToString();
            // specify if this string is a keyword
            foreach (var item in LexicalAnalyzerGLSLCompiler.keywords)
            {
                if (item.ToString().Substring(6) == result.Detail)
                {
                    result.TokenType = item;
                    break;
                }
            }
            return true;
        }
        
        public static readonly IEnumerable<EnumTokenTypeGLSLCompiler> keywords = new List<EnumTokenTypeGLSLCompiler>()
        {
        };
        
        #endregion GetIdentifier
        #region GetConstentNumber
        /// <summary>
        /// 数值
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetConstentNumber(Token<EnumTokenTypeGLSLCompiler> result)
        {
            result.TokenType = EnumTokenTypeGLSLCompiler.number;
            if (this.GetSourceCode()[PtNextLetter] == '0')//可能是八进制或十六进制数
            {
                if (PtNextLetter + 1 < this.GetSourceCode().Length)
                {
                    char c = this.GetSourceCode()[PtNextLetter + 1];
                    if (c == 'x' || c == 'X')
                    {//十六进制数
                        return GetConstentHexadecimalNumber(result);
                    }
                    else if (GetCharType(c) == EnumCharTypeGLSLCompiler.Number)
                    {//八进制数
                        return GetConstentOctonaryNumber(result);
                    }
                    else//十进制数
                    {
                        return GetConstentDecimalNumber(result);
                    }
                }
                else
                {//源代码最后一个字符 0
                    result.Detail = "0";//0
                    PtNextLetter++;
                    return true;
                }
            }
            else//十进制数
            {
                return GetConstentDecimalNumber(result);
            }
        }
        /// <summary>
        /// 十进制数
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetConstentDecimalNumber(Token<EnumTokenTypeGLSLCompiler> result)
        {
            char c;
            StringBuilder tag = new StringBuilder();
            c = this.GetSourceCode()[PtNextLetter];
            string numberSerial1, numberSerial2, numberSerial3;
            numberSerial1 = GetNumberSerial(this.GetSourceCode(), 10);
            tag.Append(numberSerial1);
            result.LexicalError = string.IsNullOrEmpty(numberSerial1);
            if (PtNextLetter < this.GetSourceCode().Length)
            {
                c = this.GetSourceCode()[PtNextLetter];
                if (c == 'l' || c == 'L')
                {
                    tag.Append(c);
                    PtNextLetter++;
                }
                if (c == '.')
                {
                    tag.Append(c);
                    PtNextLetter++;
                    numberSerial2 = GetNumberSerial(this.GetSourceCode(), 10);
                    tag.Append(numberSerial2);
                    result.LexicalError = result.LexicalError || string.IsNullOrEmpty(numberSerial2);
                    if (PtNextLetter < this.GetSourceCode().Length)
                    {
                        c = this.GetSourceCode()[PtNextLetter];
                    }
                }
                if (c == 'e' || c == 'E')
                {
                    tag.Append(c);
                    PtNextLetter++;
                    if (PtNextLetter < this.GetSourceCode().Length)
                    {
                        c = this.GetSourceCode()[PtNextLetter];
                        if (c == '+' || c == '-')
                        {
                            tag.Append(c);
                            PtNextLetter++;
                        }
                    }
                    numberSerial3 = GetNumberSerial(this.GetSourceCode(), 10);
                    tag.Append(numberSerial3);
                    result.LexicalError = result.LexicalError || string.IsNullOrEmpty(numberSerial3);
                }
            }
            result.Detail = tag.ToString();
            if (result.LexicalError)
            {
                result.Tag = string.Format("十进制数[{0}]格式错误，无法解析。", tag.ToString());
            }
            return true;
        }
        /// <summary>
        /// 八进制数
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetConstentOctonaryNumber(Token<EnumTokenTypeGLSLCompiler> result)
        {
            char c;
            StringBuilder tag = new StringBuilder(this.GetSourceCode().Substring(PtNextLetter, 1));
            PtNextLetter++;
            string numberSerial = GetNumberSerial(this.GetSourceCode(), 8);
            tag.Append(numberSerial);
            if (PtNextLetter < this.GetSourceCode().Length)
            {
                c = this.GetSourceCode()[PtNextLetter];
                if (c == 'l' || c == 'L')
                {
                    tag.Append(c);
                    PtNextLetter++;
                }
            }
            result.Detail = tag.ToString();
            if (string.IsNullOrEmpty(numberSerial))
            {
                result.LexicalError = true;
                result.Tag = string.Format("八进制数[{0}]格式错误，无法解析。", tag.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// 十六进制数
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetConstentHexadecimalNumber(Token<EnumTokenTypeGLSLCompiler> result)
        {
            char c;
            StringBuilder tag = new StringBuilder(this.GetSourceCode().Substring(PtNextLetter, 2));
            PtNextLetter += 2;
            string numberSerial = GetNumberSerial(this.GetSourceCode(), 16);
            tag.Append(numberSerial);
            if (PtNextLetter < this.GetSourceCode().Length)
            {
                c = this.GetSourceCode()[PtNextLetter];
                if (c == 'l' || c == 'L')
                {
                    tag.Append(c);
                    PtNextLetter++;
                }
            }
            result.Detail = tag.ToString();
            if (string.IsNullOrEmpty(numberSerial))
            {
                result.LexicalError = true;
                result.Tag = string.Format("十六进制数[{0}]格式错误。", tag.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// 数字序列
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <param name="scale">进制</param>
        /// <returns></returns>
        protected virtual string GetNumberSerial(string sourceCode, int scale)
        {
            if (scale == 10)
            {
                return GetNumberSerialDecimal(this.GetSourceCode());
            }
            if (scale == 16)
            {
                return GetNumberSerialHexadecimal(this.GetSourceCode());
            }
            if (scale == 8)
            {
                return GetNumberSerialOctonary(this.GetSourceCode());
            }
            return string.Empty;
        }
        /// <summary>
        /// 十进制数序列
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <returns></returns>
        protected virtual string GetNumberSerialDecimal(string sourceCode)
        {
            StringBuilder result = new StringBuilder(String.Empty);
            char c;
            while (PtNextLetter < this.GetSourceCode().Length)
            {
                c = this.GetSourceCode()[PtNextLetter];
                if ('0' <= c && c <= '9')
                {
                    result.Append(c);
                    PtNextLetter++;
                }
                else
                    break;
            }
            return result.ToString();
        }
        /// <summary>
        /// 八进制数序列
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <returns></returns>
        protected virtual string GetNumberSerialOctonary(string sourceCode)
        {
            StringBuilder result = new StringBuilder(String.Empty);
            char c;
            while (PtNextLetter < this.GetSourceCode().Length)
            {
                c = this.GetSourceCode()[PtNextLetter];
                if ('0' <= c && c <= '7')
                {
                    result.Append(c);
                    PtNextLetter++;
                }
                else
                    break;
            }
            return result.ToString();
        }
        /// <summary>
        /// 十六进制数序列（不包括0x前缀）
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <returns></returns>
        protected virtual string GetNumberSerialHexadecimal(string sourceCode)
        {
            StringBuilder result = new StringBuilder(String.Empty);
            char c;
            while (PtNextLetter < this.GetSourceCode().Length)
            {
                c = this.GetSourceCode()[PtNextLetter];
                if (('0' <= c && c <= '9')
                || ('a' <= c && c <= 'f')
                || ('A' <= c && c <= 'F'))
                {
                    result.Append(c);
                    PtNextLetter++;
                }
                else
                    break;
            }
            return result.ToString();
        }
        #endregion GetConstentNumber
        /// <summary>
        /// 字符串常量 "XXX"
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetConstentString(Token<EnumTokenTypeGLSLCompiler> result)
        {
            result.TokenType = EnumTokenTypeGLSLCompiler.constString;
            int count = this.GetSourceCode().Length;
            StringBuilder constString = new StringBuilder("\"");
            PtNextLetter++;
            bool notMatched = true;
            char c;
            while ((PtNextLetter < count) && notMatched)
            {
                c = this.GetSourceCode()[PtNextLetter];
                if (c == '"')
                {
                    constString.Append(c);
                    notMatched = false;
                    PtNextLetter++;
                }
                else if (c == '\r' || c == '\n')
                {
                    break;
                }
                else
                {
                    constString.Append(c);
                    PtNextLetter++;
                }
            }
            result.Detail = constString.ToString();
            return true;
        }
        /// <summary>
        /// 未知符号
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual bool GetUnknown(Token<EnumTokenTypeGLSLCompiler> result)
        {
            result.TokenType = EnumTokenTypeGLSLCompiler.unknown;
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
        protected virtual bool GetSpace(Token<EnumTokenTypeGLSLCompiler> result)
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
        protected virtual EnumCharTypeGLSLCompiler GetCharType(char c)
        {
            if (('a' <= c && c <= 'z') || ('A' <= c && c <= 'Z')) return EnumCharTypeGLSLCompiler.Letter;
            if ('0' <= c && c <= '9') return EnumCharTypeGLSLCompiler.Number;
            if (c == '_') return EnumCharTypeGLSLCompiler.UnderLine;
            if (c == '.') return EnumCharTypeGLSLCompiler.Dot;
            if (c == ',') return EnumCharTypeGLSLCompiler.Comma;
            if (c == '+') return EnumCharTypeGLSLCompiler.Plus;
            if (c == '-') return EnumCharTypeGLSLCompiler.Minus;
            if (c == '*') return EnumCharTypeGLSLCompiler.Multiply;
            if (c == '/') return EnumCharTypeGLSLCompiler.Divide;
            if (c == '%') return EnumCharTypeGLSLCompiler.Percent;
            if (c == '^') return EnumCharTypeGLSLCompiler.Xor;
            if (c == '&') return EnumCharTypeGLSLCompiler.And;
            if (c == '|') return EnumCharTypeGLSLCompiler.Or;
            if (c == '~') return EnumCharTypeGLSLCompiler.Reverse;
            if (c == '$') return EnumCharTypeGLSLCompiler.Dollar;
            if (c == '<') return EnumCharTypeGLSLCompiler.LessThan;
            if (c == '>') return EnumCharTypeGLSLCompiler.GreaterThan;
            if (c == '(') return EnumCharTypeGLSLCompiler.LeftParentheses;
            if (c == ')') return EnumCharTypeGLSLCompiler.RightParentheses;
            if (c == '[') return EnumCharTypeGLSLCompiler.LeftBracket;
            if (c == ']') return EnumCharTypeGLSLCompiler.RightBracket;
            if (c == '{') return EnumCharTypeGLSLCompiler.LeftBrace;
            if (c == '}') return EnumCharTypeGLSLCompiler.RightBrace;
            if (c == '!') return EnumCharTypeGLSLCompiler.Not;
            if (c == '#') return EnumCharTypeGLSLCompiler.Pound;
            if (c == '\\') return EnumCharTypeGLSLCompiler.Slash;
            if (c == '?') return EnumCharTypeGLSLCompiler.Question;
            if (c == '\'') return EnumCharTypeGLSLCompiler.Quotation;
            if (c == '"') return EnumCharTypeGLSLCompiler.DoubleQuotation;
            if (c == ':') return EnumCharTypeGLSLCompiler.Colon;
            if (c == ';') return EnumCharTypeGLSLCompiler.Semicolon;
            if (c == '=') return EnumCharTypeGLSLCompiler.Equality;
            if (c == '@') return EnumCharTypeGLSLCompiler.At;
            if (regChineseLetter.IsMatch(Convert.ToString(c))) return EnumCharTypeGLSLCompiler.ChineseLetter;
            if (c == ' ' || c == '\t' || c == '\r' || c == '\n') return EnumCharTypeGLSLCompiler.Space;
            return EnumCharTypeGLSLCompiler.Unknown;
        }
        /// <summary>
        /// 汉字 new Regex("^[^\x00-\xFF]")
        /// </summary>
        private static readonly Regex regChineseLetter = new Regex("^[^\x00-\xFF]");
    }

}

