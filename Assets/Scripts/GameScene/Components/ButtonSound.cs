using UnityEngine;

namespace GameScene.Components
{
    public class ButtonSound : MonoBehaviour {
        public AudioClip hoverSound;
        public AudioClip clickSound;
        public AudioClip exitSound;
        private AudioSource audioSource;

        private void Start() {
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null) {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        public void PlayHoverSound() {
            audioSource.PlayOneShot(hoverSound);
        }

        public void PlayClickSound() {
            audioSource.PlayOneShot(clickSound);
        }
        public void PlayExitSound() {
            audioSource.PlayOneShot(exitSound);
        }
    }
}
