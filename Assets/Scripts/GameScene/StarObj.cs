using UnityEngine;

public class StarObj : MonoBehaviour
{
    public GameObject starObject;
    private GameObject[] _toadObjs;
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

    void Start()
    {
        _toadObjs = GameObject.FindGameObjectsWithTag("Toad");
    }

    void Update()
    {
        if (_interactable && !_isBoosting)
        {
            _isBoosting = true;
            starObject.SetActive(true);
            this.gameObject.SetActive(false);
            pickupSound.Play();
            _interactable = false;

            foreach (GameObject toadObj in _toadObjs)
            {
                AudioSource audio = toadObj.GetComponent<AudioSource>();
                Light light = toadObj.GetComponent<Light>();
                light.enabled = true;
                audio.Play();
            }

            Invoke("DeactivateBoost", 15f);
        }
    }

    void DeactivateBoost()
    {
        _isBoosting = false;
        starObject.SetActive(false);
        foreach (GameObject toadObj in _toadObjs)
        {
            AudioSource audio = toadObj.GetComponent<AudioSource>();
            Light light = toadObj.GetComponent<Light>();
            light.enabled = false;
            audio.Pause();
        }
    }
}