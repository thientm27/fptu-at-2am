using UnityEngine;
using UnityEngine.UI;

namespace GameScene.Components
{
    public class AnswerQuizBtn : MonoBehaviour
    {
        public string option;

        private Quiz _quizScript;

        private void Start() {
            _quizScript = FindObjectOfType<Quiz>();
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick() {
            _quizScript.CheckAnswer(option);
        }
    }
}
