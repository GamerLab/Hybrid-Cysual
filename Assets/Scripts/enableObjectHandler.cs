using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableObjectHandler : MonoBehaviour
{
    [SerializeField] private float timeToEnable = 0f;
    [SerializeField] private GameObject objectToEnable;

    private void OnEnable()
    {
        Invoke("enableNow", timeToEnable);
    }
    void enableNow()
    {
        objectToEnable.SetActive(true);
    }

    private void OnDisable()
    {
        objectToEnable.SetActive(false);
    }
}
