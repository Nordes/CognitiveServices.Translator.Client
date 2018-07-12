using System;

namespace CognitiveServices.Translator.Client.Language
{
    [Flags]
    public enum Scope
    {
        /// <summary>
        /// By default, it is all the scopes
        /// </summary>
        All             = 0b111,
        Translation     = 0b001,
        Transliteration = 0b010,
        Dictionary      = 0b100
    }
}
