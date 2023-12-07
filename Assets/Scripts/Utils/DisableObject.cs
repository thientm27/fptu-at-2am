using System.Collections;
using UnityEngine;

namespace Utils
{
    public class DisableObject : MonoBehaviour
    {
        public GameObject obj;
        public float activeTime;

        void Update()
        {
            if (obj.activeInHierarchy)
            {
                StartCoroutine(Disableobj());
            }
        }
        IEnumerator Disableobj()
        {
            yield return new WaitForSeconds(activeTime);
            obj.SetActive(false);
        }
    }
}
