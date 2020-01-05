//----------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// .es extensiones extaticas para ayudar en el calculo de códigos hash
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// Calculate hash with algorthim MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CalculateMD5Hash(this string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                return CalculateHash(input, md5);
            }
        }

        /// <summary>
        /// Calculate hash with algorthim SHA1
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CalculateSHA1Hash(this string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                return CalculateHash(input, sha1);
            }
        }

        /// <summary>
        /// Calculate hash
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hashAlgorithm"></param>
        /// <returns></returns>
        private static string CalculateHash(string input, HashAlgorithm hashAlgorithm)
        {
            byte[] inputBytes;
            byte[] hash;

            using (var hashProvider = hashAlgorithm)
            {
                inputBytes = Encoding.ASCII.GetBytes(input);
                hash = hashProvider.ComputeHash(inputBytes);
            }

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2", CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// .es Extensiones estaticas para simplifica el uso de cadenas de html
    /// </summary>
    public static class HtmlHelper
    {
        /// <summary>
        /// remove html marks
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string StripHtml(this string text)
        {
            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            return reg.Replace(text, "");
        }
    }

    /// <summary>
    /// funciones de transformacion de "slug urls"
    /// </summary>
    public static class StringSlugExtension
    {
        private static readonly Dictionary<string, string> rules1;
        private static readonly Dictionary<string, string> rules2;

        /// <summary>
        /// constructor estatico que inicializa los 
        /// </summary>
        static StringSlugExtension()
        {
            List<char> invalidChars = "àáâãäåçèéêëìíîïñòóôõöøùúûüýÿ".ToCharArray().ToList();
            List<char> validChars = "aaaaaaceeeeiiiinoooooouuuuyy".ToCharArray().ToList();

            rules1 = invalidChars.ToDictionary(i => i.ToString(), i => validChars[invalidChars.IndexOf(i)].ToString());

            invalidChars = new[] { 'Þ', 'þ', 'Ð', 'ð', 'ß', 'Œ', 'œ', 'Æ', 'æ', 'µ', '&', '(', ')' }.ToList();

            List<string> validStrings =
                new[] { "TH", "th", "DH", "dh", "ss", "OE", "oe", "AE", "ae", "u", "and", "", "" }.ToList();

            rules2 = invalidChars.ToDictionary(i => i.ToString(), i => validStrings[invalidChars.IndexOf(i)]);
        }

        /// <summary>
        /// .es transformaciones de url feas en urls feas con espacios.
        /// .en Will transform "some $ugly ###url wit[]h spaces" into "some-ugly-url-with-spaces"
        /// </summary>
        public static string Slugify(this string phrase)
        {
            string str = phrase.ToLower();

            // Transform Invalid Chars.
            str = str._StrTr(rules1);

            // Transform Special Chars.
            str = str._StrTr(rules2);

            // Final clean up.
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            // convert multiple spaces/hyphens into one space
            str = Regex.Replace(str, @"[\s-]+", " ").Trim();

            // hyphens
            str = Regex.Replace(str, @"\s", "-");

            return str;
        }

        /// <summary>
        /// .es elimina caracteres con acentos extraños y lo sustituye siguiendo las reglas internas.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="replacements"></param>
        /// <returns></returns>
        private static string _StrTr(this string source, Dictionary<string, string> replacements)
        {
            var finds = new string[replacements.Keys.Count];

            replacements.Keys.CopyTo(finds, 0);

            string findpattern = string.Join("|", finds);

            var regex = new Regex(findpattern);

            MatchEvaluator evaluator =
                delegate(Match m)
            {
                string match = m.Captures[0].Value; // either "hello" or "hi" from the original string

                if (replacements.ContainsKey(match))
                {
                    return replacements[match];
                }
                else
                {
                    return match;
                }
            };

            return regex.Replace(source, evaluator);
        }

        /// <summary>
        /// Get a pascal case version from the string
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static string PascalCase(this string origin)
        {
            if (string.IsNullOrEmpty(origin))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(origin[0]) + origin.Substring(1).ToLower();
        }


        /// <summary>
        /// https://stackoverflow.com/questions/17252615/get-string-between-two-strings-in-a-string
        /// takes a substring between two anchor strings (or the end of the string if that anchor is null)
        /// </summary>
        /// <param name="this">a string</param>
        /// <param name="from">an optional string to search after</param>
        /// <param name="until">an optional string to search before</param>
        /// <param name="comparison">an optional comparison for the search</param>
        /// <returns>a substring based on the search</returns>
        public static string Substring(this string @this, string from = null, string until = null, StringComparison comparison = StringComparison.InvariantCulture)
        {
            var fromLength = (from ?? string.Empty).Length;
            var startIndex = !string.IsNullOrEmpty(from)
                ? @this.IndexOf(from, comparison) + fromLength
                : 0;

            if (startIndex < fromLength) { throw new ArgumentException("from: Failed to find an instance of the first anchor"); }

            var endIndex = !string.IsNullOrEmpty(until)
            ? @this.IndexOf(until, startIndex, comparison)
            : @this.Length;

            if (endIndex < 0) { throw new ArgumentException("until: Failed to find an instance of the last anchor"); }

            var subString = @this.Substring(startIndex, endIndex - startIndex);
            return subString;
        }
    }
}