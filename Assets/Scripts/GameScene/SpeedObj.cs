using UnityEngine;

namespace GameScene
{
    public class SpeedObj : MonoBehaviour
    {
        public GameObject speedObject;
        public SC_FPSController fpsController;
        public AudioSource pickupSound;
        private bool _interactable;
        private bool _isBoosting = false;

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _interactable = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _interactable = false;
            }
        }

        float _originalWalkingSpeed;
        float _originalRunningSpeed;

        // Update is called once per frame
        void Update()
        {
            if (_interactable && !_isBoosting)
            {
                _isBoosting = true;
                speedObject.SetActive(true);
                this.gameObject.SetActive(false);
                pickupSound.Play();
                _interactable = false;

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

            _isBoosting = false;
            speedObject.SetActive(false);
        }
    }
}