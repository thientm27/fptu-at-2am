using UnityEngine;

namespace GameScene
{
    public class JumpscareTrig : MonoBehaviour
    {
        public string sceneName;
        public MonsterAI monsterScript;

        public GameObject questionobj;
        public SC_FPSController player;
        public Quiz quiz;
        public string subjectName;
        void PauseGame() {

            player.enabled = false;
            questionobj.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            AudioListener.pause = true;
        }

        public void ResumeGame() {
            player.enabled = true;
            questionobj.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            AudioListener.pause = false;
        }


        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PauseGame();
                quiz.LoadQuestion(subjectName);
                questionobj.SetActive(true);
                //SceneManager.LoadScene(sceneName);
            }
        }


    }
}