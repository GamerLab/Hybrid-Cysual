using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

namespace LazyTurtle
{


    public class PlatformDespawner : MonoBehaviour
    {
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(DoDisable());
            }
        }

        public IEnumerator DoDisable()
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("DisablingGround ");
            GameHelperManager.HelperInstance.ActiveGroundCount--;
            this.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}

