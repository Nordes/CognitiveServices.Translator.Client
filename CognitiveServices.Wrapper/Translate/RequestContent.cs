using System;

namespace CognitiveServices.Wrapper.Translate
{
    public class RequestContent
    {
        public RequestContent(string text)
        {
            Text = text;
        }

        private string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text.Length > 1000)
                    throw new Exception("Range cannot exceed 1,000 characters");
                else
                    _text = value;
            }
        }
    }
}
