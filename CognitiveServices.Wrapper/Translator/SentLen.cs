namespace CognitiveServices.Wrapper.Translator
{
    public class SentLen
    {
        /// <summary>
        /// An integer array representing the lengths of the sentences in the input text. 
        /// The length of the array is the number of sentences, and the values are the 
        /// length of each sentence.
        /// </summary>
        public int SrcSentLen { get; set; }

        /// <summary>
        ///  An integer array representing the lengths of the sentences in the translated 
        ///  text. The length of the array is the number of sentences, and the values are 
        ///  the length of each sentence.            
        /// </summary>
        public int TransSentLen { get; set; }
    }
}
