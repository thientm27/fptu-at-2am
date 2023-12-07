using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    public GameObject menu, options, credits, loading;
    public string gameSceneName;
    public AudioSource menuAudio;
    public void openOptions() {
        menu.SetActive(false);
        options.SetActive(true);
    }
    public void openCredits() {
        menu.SetActive(false);
        credits.SetActive(true);
    }
    public void goBack() {
        options.SetActive(false);
        credits.SetActive(false);
        //difficulty.SetActive(false);
        menu.SetActive(true);
    }
    public void quitGame() {
        Application.Quit();
    }
    public void playGame() {
        menu.SetActive(false);
        menuAudio.Stop();
        veryHard();
    }
    public void veryHard() {
        PlayerPrefs.SetInt("difficulty", 0);
        PlayerPrefs.Save();
        loading.SetActive(true);
        SceneManager.LoadScene(gameSceneName);
    }
}