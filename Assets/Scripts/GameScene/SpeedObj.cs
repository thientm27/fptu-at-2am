using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpeedObj : MonoBehaviour {
    public GameObject speedObject;
    public SC_FPSController fpsController;
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
    // Start is called before the first frame update
    void Start() {

    }

    float originalWalkingSpeed;
    float originalRunningSpeed;

    // Update is called once per frame
    void Update() {
        if (interactable && !isBoosting) {
            isBoosting = true;
            speedObject.SetActive(true);
            this.gameObject.SetActive(false);
            pickupSound.Play();
            interactable = false;

            originalWalkingSpeed = fpsController.walkingSpeed;
            originalRunningSpeed = fpsController.runningSpeed;

            fpsController.walkingSpeed += 3;
            fpsController.runningSpeed += 6;

            Invoke("DeactivateBoost", 15f);
        }
    }
    void DeactivateBoost() {

        fpsController.walkingSpeed = originalWalkingSpeed;
        fpsController.runningSpeed = originalRunningSpeed;

        isBoosting = false;
        speedObject.SetActive(false);

    }
}
