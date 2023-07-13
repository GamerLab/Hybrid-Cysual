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

                this.gameObject.transform.parent.gameObject.SetActive(false);
                GameHelperManager.HelperInstance.ActiveGroundCount--;
                //ObstaclePopulator.PoolerInst.activeGrounds.Sort();


                foreach (Transform child in transform)
                {
                        // ...

                        if (child.CompareTag("TruthDoor") || child.CompareTag("DareDoor"))
                        {
                            Debug.Log("DisablingChild");

                         child.gameObject.SetActive(false);
                         child.transform.parent.parent = null;
                         child.transform.GetChild(3).gameObject.SetActive(false);
                         GameHelperManager.HelperInstance.ActiveDoorCount--;

                        }
                }


                

            }
        }
    }
}

