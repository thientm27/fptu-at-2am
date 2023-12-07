using System.Collections;

using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public GameObject Obj;
    public float activeTime;

    void Update()
    {
        if (Obj.activeInHierarchy)
        {
            StartCoroutine(Disableobj());
        }
    }
    IEnumerator Disableobj()
    {
        yield return new WaitForSeconds(activeTime);
        Obj.SetActive(false);
    }
}
