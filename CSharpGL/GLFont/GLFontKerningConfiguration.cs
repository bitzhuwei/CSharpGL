using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public class GLFontKerningConfiguration
    {
        /// <summary>
        /// Kerning rules for particular characters
        /// </summary>
        private Dictionary<char, GLFontCharacterKerningRule> CharacterKerningRules = new Dictionary<char, GLFontCharacterKerningRule>();

        /// <summary>
        /// When measuring the bounds of glyphs, and performing kerning calculations, 
        /// this is the minimum alpha level that is necessray for a pixel to be considered
        /// non-empty. This should be set to a value on the range [0,255]
        /// </summary>
        public byte AlphaEmptyPixelTolerance = 0;


        /// <summary>
        /// Sets all characters in the given string to the specified kerning rule.
        /// </summary>
        /// <param name="chars"></param>
        /// <param name="rule"></param>
        public void BatchSetCharacterKerningRule(String chars, GLFontCharacterKerningRule rule)
        {
            foreach (var c in chars)
            {
                CharacterKerningRules[c] = rule;
            }
        }

        /// <summary>
        /// Sets the specified character kerning rule.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="rule"></param>
        public void SetCharacterKerningRule(char c, GLFontCharacterKerningRule rule)
        {
            CharacterKerningRules[c] = rule;
        }

        public GLFontCharacterKerningRule GetCharacterKerningRule(char c)
        {
            if (CharacterKerningRules.ContainsKey(c))
            {
                return CharacterKerningRules[c];
            }

            return GLFontCharacterKerningRule.Normal;
        }

        /// <summary>
        /// Given a pair of characters, this will return the overriding 
        /// CharacterKerningRule.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public GLFontCharacterKerningRule GetOverridingCharacterKerningRuleForPair(String str)
        {
            if (str.Length < 2)
            {
                return GLFontCharacterKerningRule.Normal;
            }

            char c1 = str[0];
            char c2 = str[1];

            if (GetCharacterKerningRule(c1) == GLFontCharacterKerningRule.Zero || GetCharacterKerningRule(c2) == GLFontCharacterKerningRule.Zero)
            {
                return GLFontCharacterKerningRule.Zero;
            }
            else if (GetCharacterKerningRule(c1) == GLFontCharacterKerningRule.NotMoreThanHalf || GetCharacterKerningRule(c2) == GLFontCharacterKerningRule.NotMoreThanHalf)
            {
                return GLFontCharacterKerningRule.NotMoreThanHalf;
            }

            return GLFontCharacterKerningRule.Normal;
        }

        public GLFontKerningConfiguration()
        {
            SetCharacterKerningRule('^', GLFontCharacterKerningRule.NotMoreThanHalf);
            SetCharacterKerningRule('_', GLFontCharacterKerningRule.NotMoreThanHalf);
            SetCharacterKerningRule('\"', GLFontCharacterKerningRule.NotMoreThanHalf);
            SetCharacterKerningRule('\'', GLFontCharacterKerningRule.NotMoreThanHalf);
        }
    }
}
