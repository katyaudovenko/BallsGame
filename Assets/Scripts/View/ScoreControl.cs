using Controller;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ScoreControl : MonoBehaviour
    {
        [SerializeField] private int addScore;
        private Text _textScore;
        private int _score;

        private void Start()
        {
            _textScore = GetComponent<Text>();
            GlobalEventManager.DestroyBall.AddListener(AddScore);
        }

        private void AddScore()
        {
            _score += addScore;
            _textScore.text = _score.ToString();
        }
    }
}