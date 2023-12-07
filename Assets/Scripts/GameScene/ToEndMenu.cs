using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameScene
{
    public class ToEndMenu : MonoBehaviour
    {
        public string scene;
        public float jumpScareTime;

        // Start is called before the first frame update
        void Start()
        {
            Invoke("SwitchScene", jumpScareTime);
        }

        void SwitchScene()
        {
            SceneManager.LoadScene(scene);
        }
    }
}