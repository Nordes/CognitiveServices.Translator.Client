using System;
using System.Collections.Generic;
using System.Linq;

namespace CognitiveServices.Translator.Client.Extension
{
    public static class EnumExtension
    {
        ////public static IEnumerable<T> GetUniqueFlags<T>(this Enum flags)
        ////    where T : Enum    // New constraint for C# 7.3
        ////{
        ////    foreach (Enum value in Enum.GetValues(flags.GetType()))
        ////        if (flags.HasFlag(value))
        ////            yield return (T)value;
        ////}

        /// <summary>
        /// Gets the flags from the Enum.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        public static IEnumerable<Enum> GetFlags(this Enum input)
        {
            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return value;
        }
    }
}
