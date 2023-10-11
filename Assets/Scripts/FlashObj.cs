using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlashObj : MonoBehaviour {
    public GameObject flashObject;
    public Light light;
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

    float originalAngle;
    float originalIntensity;
    float originalRange;

    // Update is called once per frame
    void Update() {
        if (interactable && !isBoosting) {
            isBoosting = true;
            flashObject.SetActive(true);
            this.gameObject.SetActive(false);
            pickupSound.Play();
            interactable = false;

            originalAngle = light.spotAngle;
            originalRange = light.range;
            originalIntensity = light.intensity;

            light.spotAngle = 80;
            light.intensity = 1.8f;
            light.range = 80;

            Invoke("DeactivateFlash", 15f);
        }
    }
    void DeactivateFlash() {

        light.spotAngle = originalAngle;
        light.intensity = originalIntensity;
        light.range = originalRange;

        isBoosting = false;
        flashObject.SetActive(false);

    }
}
