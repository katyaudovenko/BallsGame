using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View.UIViews
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button play;

        private void Awake()
        {
            play.onClick.AddListener(PlayGame);
        }

        private void PlayGame()
        {
            SceneManager.LoadScene(1);
        }
   
    }
}
