using UnityEngine;
using UnityEngine.UI;

namespace GameScene.Components
{
    public class AnswerQuizBtn : MonoBehaviour
    {
        public string option;

        private Quiz quizScript;

        private void Start() {
            quizScript = GameObject.FindObjectOfType<Quiz>();
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick() {
            quizScript.CheckAnswer(option);
        }
    }
}
