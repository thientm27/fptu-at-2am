using UnityEngine;

namespace GameScene.Components
{
    public class ButtonSound : MonoBehaviour {
        public AudioClip hoverSound;
        public AudioClip clickSound;
        public AudioClip exitSound;
        private AudioSource _audioSource;

        private void Start() {
            _audioSource = GetComponent<AudioSource>();

            if (_audioSource == null) {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        public void PlayHoverSound() {
            _audioSource.PlayOneShot(hoverSound);
        }

        public void PlayClickSound() {
            _audioSource.PlayOneShot(clickSound);
        }
        public void PlayExitSound() {
            _audioSource.PlayOneShot(exitSound);
        }
    }
}
