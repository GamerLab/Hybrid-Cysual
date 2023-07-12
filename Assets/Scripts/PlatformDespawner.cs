using UnityEngine;
namespace LazyTurtle
{


    public class PlatformDespawner : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {

                this.gameObject.transform.parent.gameObject.SetActive(false); 
              

            }
        }
    }
}

