using UnityEngine;

namespace GameScene
{
    public class SpeedObj : MonoBehaviour
    {
        public GameObject speedObject;
        public SC_FPSController fpsController;
        public AudioSource pickupSound;
        private bool interactable;
        private bool isBoosting = false;

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                interactable = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                interactable = false;
            }
        }

        float _originalWalkingSpeed;
        float _originalRunningSpeed;

        // Update is called once per frame
        void Update()
        {
            if (interactable && !isBoosting)
            {
                isBoosting = true;
                speedObject.SetActive(true);
                this.gameObject.SetActive(false);
                pickupSound.Play();
                interactable = false;

                _originalWalkingSpeed = fpsController.walkingSpeed;
                _originalRunningSpeed = fpsController.runningSpeed;

                fpsController.walkingSpeed += 3;
                fpsController.runningSpeed += 6;

                Invoke("DeactivateBoost", 15f);
            }
        }

        void DeactivateBoost()
        {
            fpsController.walkingSpeed = _originalWalkingSpeed;
            fpsController.runningSpeed = _originalRunningSpeed;

            isBoosting = false;
            speedObject.SetActive(false);
        }
    }
}