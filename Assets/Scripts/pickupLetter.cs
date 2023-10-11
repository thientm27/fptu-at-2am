using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pickupLetter : MonoBehaviour
{
    public GameObject collectTextObj, intText;
    public GameObject monster1, monster2, monster3, monster4, monster5;
    public AudioSource pickupSound, ambianceLayer1, ambianceLayer2, ambianceLayer3, ambianceLayer4, ambianceLayer5, ambianceLayer6, ambianceLayer7;
    private bool interactable;
    public static int pagesCollected;
    public Text collectText;
    public string scene;
    void Start()
    {
        pagesCollected = 0; 
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pagesCollected = pagesCollected + 1;
                collectText.text = pagesCollected + "/7 golden toad";
                collectTextObj.SetActive(true);
                pickupSound.Play();
                if (pagesCollected == 1)
                {
                    ambianceLayer1.Play();
                    if (monster1.activeSelf == false) {
                        monster1.SetActive(true);
                    }
                }
                if (pagesCollected == 2)
                {
                    ambianceLayer1.Stop();
                    ambianceLayer2.Play();
                    if (monster2.activeSelf == false) {
                        monster2.SetActive(true);
                    }
                }
                if (pagesCollected == 3)
                {
                    ambianceLayer2.Stop();
                    ambianceLayer3.Play();
                    if (monster3.activeSelf == false) {
                        monster3.SetActive(true);
                    }
                }
                if (pagesCollected == 4)
                {
                    ambianceLayer3.Stop();
                    ambianceLayer4.Play();
                    if (monster4.activeSelf == false) {
                        monster4.SetActive(true);
                    }
                }
                if (pagesCollected == 5)
                {
                    ambianceLayer4.Stop();
                    ambianceLayer5.Play();
                    if (monster5.activeSelf == false) {
                        monster5.SetActive(true);
                    }
                }
                if (pagesCollected == 6)
                {
                    ambianceLayer5.Stop();
                    ambianceLayer6.Play();
                }
                if (pagesCollected == 7)
                {
                    ambianceLayer6.Stop();
                    ambianceLayer7.Play();
                    SceneManager.LoadScene(scene);
                }
                intText.SetActive(false);
                this.gameObject.SetActive(false);
                interactable = false;
            }
        }
    }
}