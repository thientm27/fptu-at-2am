using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour {
    public GameObject pausemenuobj, optionsmenu;
    public SC_FPSController player;
    public bool paused;
    public string menuSceneName;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;
            if (paused == true) {
                player.enabled = false;
                pausemenuobj.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                AudioListener.pause = true;
            }
            if (paused == false) {
                player.enabled = true;
                pausemenuobj.SetActive(false);
                optionsmenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                AudioListener.pause = false;
            }
        }
    }
    public void resumeGame() {
        player.enabled = true;
        pausemenuobj.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
        paused = false;
    }

    public void openOptions() {
        pausemenuobj.SetActive(false);
        optionsmenu.SetActive(true);

    }

    public void goBack() {
        pausemenuobj.SetActive(true);
        optionsmenu.SetActive(false);
    }
    public void backToMenu() {
        player.enabled = true;
        pausemenuobj.SetActive(false);
        optionsmenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
        SceneManager.LoadScene(menuSceneName);
    }
    public void quitGame() {
        Application.Quit();
        Debug.Log("quit game");
    }
}