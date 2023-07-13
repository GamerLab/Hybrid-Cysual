using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LazyTurtle
{
    public class InfiniteGroundSpawner : MonoBehaviour
    {
        public List<GameObject> groundPrefab = new List<GameObject>(); // The prefab for the ground section
        [SerializeField] public int preSpawnCount = 10; // Number of ground sections to pre-spawn at the start
                                       //public float minChangeInterval = 60f; // Minimum interval for changing the ground direction
                                       //public float maxChangeInterval = 120f; // Maximum interval for changing the ground direction

        [SerializeField] private Vector3 spawnPosition; // The position to spawn the next ground section
        [SerializeField] public float incrimentPos;
        [SerializeField] public float PosChanged;                               //  private Quaternion groundRotation; // The rotation of the ground section

        //  private Quaternion groundRotation; // The rotation of the ground section
        //  private float changeDirectionTimer; // Timer for changing the ground direction
        //  private float changeDirectionInterval; // Interval for changing the ground direction

        private void Start()
        {

            //  incrimentPos = GameHelperManager.HelperInstance.CurrentGround.gameObject.GetComponent<Collider>().bounds.max.z;
            incrimentPos = 5.0f;

            // Pre-spawn 
            for (int i = 0; i < preSpawnCount; i++)
            {
                SpawnGround();
            }


            //// Set initial ground rotation
            //groundRotation = groundP()refab.transform.rotation;

            //// Set initial direction change timer and interval
            //changeDirectionTimer = 0f;
            //changeDirectionInterval = Random.Range(minChangeInterval, maxChangeInterval);
        }

        private void Update()
        {
            // Check if the player has moved past the spawn position (or use a trigger-based condition)
           
            if (GameHelperManager.HelperInstance.PlayerRef.transform.position.z + 10 >= spawnPosition.z)
            {
                SpawnGround();
            }
            // Spawn new ground sections based on player movement or specific condition

            // Update the direction change timer
            //changeDirectionTimer += Time.deltaTime;

            //// Check if it's time to change the ground direction
            //if (changeDirectionTimer >= changeDirectionInterval)
            //{


            //    // Reset the direction change timer and interval
            //    changeDirectionTimer = 0f;
            //    changeDirectionInterval = Random.Range(minChangeInterval, maxChangeInterval);
            //    ChangeGroundDirection();
            //}
        }

        private void SpawnGround()
        {
            //// Generate a random rotation for the ground
            //Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 0f), 0f);

            // Instantiate a new ground section at the spawn position with the random rotation
            for (int i = 0; i < groundPrefab.Count; i++)
            {
                if (groundPrefab[i].gameObject.activeInHierarchy == false)
                {
                    GameHelperManager.HelperInstance.NewPositionZofSpawn = (GameHelperManager.HelperInstance.CurrentGround.transform.position.z + incrimentPos);
                    spawnPosition = new Vector3(0f, 0f, GameHelperManager.HelperInstance.NewPositionZofSpawn);

                       //Debug.Log("item.added at : " + spawnPosition.z.ToString()); 
                    groundPrefab[i].transform.position = spawnPosition;

                    groundPrefab[i].gameObject.SetActive(true);
                    GameHelperManager.HelperInstance.ActiveGroundCount++;
                    GameHelperManager.HelperInstance.CurrentGround = groundPrefab[i].gameObject;

                    break;
                }
               
            }
            //foreach (GameObject item in groundPrefab)
            //{
            //    if (!item.activeInHierarchy)
            //    {
            //        Debug.Log("item.added at : " + GameHelperManager.HelperInstance.NewPositionZofSpawn);
            //        spawnPosition = new Vector3(GameHelperManager.HelperInstance.CurrentGround.transform.position.x, GameHelperManager.HelperInstance.CurrentGround.transform.position.y, GameHelperManager.HelperInstance.CurrentGround.transform.position.z + GameHelperManager.HelperInstance.NewPositionZofSpawn);
            //        item.transform.position = spawnPosition;

            //        item.gameObject.SetActive(true);
            //        item.transform.position = spawnPosition;
            //        GameHelperManager.HelperInstance.NewPositionZofSpawn += incrimentPos;
            //        GameHelperManager.HelperInstance.CurrentGround = item.gameObject;
            //        yield return new WaitForSeconds(0.5f);
            //        break;
            //    }
            //}
            // GameObject newGround = Instantiate(groundPrefab, spawnPosition, Quaternion.identity);

            //// Get the length of the new ground prefab based on its scale
            //Vector3 newGroundScale = newGround.transform.localScale;
            //float groundLength = newGroundScale.z;

            //// Update the spawn position for the next ground section based on the prefab's length and random direction
            //Vector3 randomDirection = randomRotation * Vector3.forward;
            //spawnPosition += randomDirection * groundLength;
        }


        //private void ChangeGroundDirection()
        //{
        //    // Generate a new random rotation for the ground
        //    Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(-90f, 90f), 0f);

        //    // Interpolate smoothly between the current rotation and the new random rotation
        //    groundRotation = Quaternion.RotateTowards(groundRotation, randomRotation, 45f);
        //}
    }
}