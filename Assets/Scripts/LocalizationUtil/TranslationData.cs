using System;

namespace LocalizationUtil
{
    [Serializable]
    public class TranslationData
    {
        public string key;
        public string value;
    }
    
    
    [Serializable]
    public class TranslationDataArray
    {
        public TranslationData[] data;
    }
}