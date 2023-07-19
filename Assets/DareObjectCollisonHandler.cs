using System.Collections;
using System.Collections.Generic;
using LazyTurtle;
using UnityEngine;

public class DareObjectCollisonHandler : MonoBehaviour
{
    [SerializeField] public GameObject ParticleHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.GMInstance.CheckCollectedTarget(this.gameObject);
            ParticleHit.SetActive(true);
           
        }
        Invoke("DisableObject", 1.0f);
    }


    public void DisableObject()
    {
        ParticleHit.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
