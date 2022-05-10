using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private List<Image> lives;

        public void UpdateLivesCount(int countLives)
        {
            for (var i = 0; i < lives.Count; i++)
            {
                var isActive = i < countLives;
                lives[i].gameObject.SetActive(isActive);
            }
        }
    }
}