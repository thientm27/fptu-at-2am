using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public GameObject endMenu, playAgain, quitToMenu, loading;
    public string gameScene, menuScene;
    public AudioSource menuAudio;

    public GameObject transition;
    public Image black;
    void Start() {
        StartCoroutine(TransitionCoroutine());
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    IEnumerator TransitionCoroutine() {
        transition.SetActive(true);

        yield return new WaitUntil(() => black.color.a == 0);

        transition.SetActive(false);
    }

    private void Update() {
    }

    public void PlayAgain() {
        endMenu.SetActive(false);
        loading.SetActive(true);
        menuAudio.Stop();
        SceneManager.LoadScene(gameScene);
    }
    public void QuitToMenu() {
        menuAudio.Stop();
        endMenu.SetActive(false);
        SceneManager.LoadScene(menuScene);
    }
}
