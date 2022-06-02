using UnityEngine;

namespace View
{
    public class ColdEffect : MonoBehaviour
    {
        private Object _effect;
        public void StartColdEffect()
        {
            _effect = Resources.Load("Effects/Frost/FrostExampleCamera_smooth_subtleDistortion");
            Instantiate(_effect);
        }

        public void EndColdEffect()
        {
            Destroy(_effect);
        }
    }
}