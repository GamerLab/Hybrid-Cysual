using UnityEngine;
namespace LazyTurtle
{


    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject platformPrefab;
        //[SerializeField] public static Transform LastSpawnedGround;

        private void OnTriggerEnter(Collider other)
        {
            //if (other.CompareTag("Player"))
            //{
            //   //GameObject groundClone= Instantiate(platformPrefab, new Vector3(0,0,GameHelperManager.HelperInstance.CurrentGround.GetComponent<Collider>().bounds.size.z), Quaternion.identity);
            //   //GameHelperManager.HelperInstance.CurrentGround = groundClone.transform;
            //}
        }
    }

}