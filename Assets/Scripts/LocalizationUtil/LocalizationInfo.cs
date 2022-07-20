using System.Collections.Generic;
using UnityEngine;

namespace LocalizationUtil
{
    [CreateAssetMenu(menuName = "Create LocalizationInfo", fileName = "LocalizationInfo")]
    public class LocalizationInfo : ScriptableObject
    {
        public List<TextAsset> translations;
    }
}