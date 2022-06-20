using UnityEngine;

namespace Controller
{
    public class DontDestroyable : MonoBehaviour
    {
        private void Awake() => 
            DontDestroyOnLoad(this);
    }
}