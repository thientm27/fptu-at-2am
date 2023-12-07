using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarObj : MonoBehaviour {
    public GameObject starObject;
    private GameObject[] toadObjs;
    public AudioSource pickupSound;
    private bool interactable;
    private bool isBoosting = false;

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            interactable = false;
        }
    }
    private void Awake() {
    }
    // Start is called before the first frame update
    void Start() {
        toadObjs = GameObject.FindGameObjectsWithTag("Toad");
    }


    // Update is called once per frame
    void Update() {
        if (interactable && !isBoosting) {
            isBoosting = true;
            starObject.SetActive(true);
            this.gameObject.SetActive(false);
            pickupSound.Play();
            interactable = false;

            foreach (GameObject toadObj in toadObjs) {
                AudioSource audio = toadObj.GetComponent<AudioSource>();
                Light light = toadObj.GetComponent<Light>();
                light.enabled = true;
                audio.Play();
            }

            Invoke("DeactivateBoost", 15f);
        }
    }
    void DeactivateBoost() {
        isBoosting = false;
        starObject.SetActive(false);
        foreach (GameObject toadObj in toadObjs) {
            AudioSource audio = toadObj.GetComponent<AudioSource>();
            Light light = toadObj.GetComponent<Light>();
            light.enabled = false;
            audio.Pause();
        }

    }
}
