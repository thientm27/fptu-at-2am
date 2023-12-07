using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEndMenu : MonoBehaviour {
    public string scene;
    public float jumpscareTime;
    // Start is called before the first frame update
    void Start() {
        Invoke("SwitchScene", jumpscareTime);
    }

    void SwitchScene() {
        SceneManager.LoadScene(scene);
    }
}
