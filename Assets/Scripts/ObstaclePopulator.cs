using LazyTurtle;
using System.Collections.Generic;
using UnityEngine;
using static LazyTurtle.GameManager;
using static UnityEditor.Progress;

public class ObstaclePopulator : MonoBehaviour
{
    public static ObstaclePopulator PoolerInst;
    [Space(10)]
    [Header("holder for Doors to pool spawn objects ")]
    [SerializeField] public List<GameObject> Doors = new List<GameObject>();
    [Space(10)]
    [Header("holder for Truth/Dare to pool spawn objects ")]
    [SerializeField] public List<GameObject> TruthObstacles = new List<GameObject>();
    [SerializeField] public List<GameObject> DareObstacles = new List<GameObject>();

    [Header("holder for Active Grounds  ")]
    [SerializeField] public List<GameObject> activeGrounds = new List<GameObject>();




    [Space(10)]
    [Header("Required Variable Data ")]
    private int groundToSpawn;
    private int randomLine;

    // Start is called before the first frame update
    void Awake()
    {
        PoolerInst = this;
    }

    // Update is called once per frame
    void Update()
    {

        //switch ((int)GameManager.GMInstance.gameState)
        //{

        //    case 0://Objective 
        //        break;
        //    case 1://GameStart

        //        break;
        //    case 2://GamePause
        //        break;
        //    case 3://DoorSpawn

        //        break;
        //    case 4://TruthDoor
        //        break;
        //    case 5://DareDoor
        //        break;
        //    case 6://PreSuccess
        //        break;
        //    case 7://PreFail
        //        break;
        //    case 8://Failed
        //        break;
        //    case 9://Scccess
        //        break;
        //    case 10://StopToPlay  
        //        break;
        //}
    }

    #region Spawn | Pool Logics

    //manuammy placed obbjects 
    private void PopulateObstaclesRandomObstacles(List<GameObject> _obstacles)
    {
        int randomNumberofObstacles = Random.Range(0, _obstacles.Count);

        switch (randomNumberofObstacles)
        {
            case 0: // No Obstacles
                foreach (GameObject obstacle in _obstacles)
                {
                    obstacle.SetActive(false);
                }
                break;
            case 1: // Two Active Obstacles
                foreach (GameObject obstacle in _obstacles)
                {
                    obstacle.SetActive(true);
                }
                _obstacles[Random.Range(0, _obstacles.Count)].SetActive(false);
                break;
            case 2: // One Active Obstacle
                foreach (GameObject obstacle in _obstacles)
                {
                    obstacle.SetActive(true);
                }
                for (int i = 0; i < 2;)
                {
                    int rng = Random.Range(0, _obstacles.Count);
                    if (_obstacles[rng].activeInHierarchy)
                    {
                        _obstacles[rng].SetActive(false);
                        i++;
                    }
                }
                break;
            case 3: // All Active Obstacles
                foreach (GameObject obstacle in _obstacles)
                {
                    obstacle.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
    // dynamically placing doors 
    public void SpawnDoorsNow()
    {
       // Debug.Log("Spawning Door :" + GameHelperManager.HelperInstance.ActiveGroundCount);
        if (GameHelperManager.HelperInstance.ActiveGroundCount == 3 && GameHelperManager.HelperInstance.ActiveDoorCount <= 2)
        {
            Vector3 lastPos = new Vector3(0f, 0f, 0f);
            foreach (GameObject item in Doors)
            {
               // Debug.Log("Spawning :" + item.name);
                
                Vector3 gotPos = GetRandomDoorPositionForPool();
                while (gotPos == lastPos)
                {
                    gotPos = GetRandomDoorPositionForPool();
                }
                if (lastPos != gotPos)
                {
                    item.transform.position = gotPos;
                    item.transform.parent = activeGrounds[groundToSpawn].GetComponent<GroundHolder>().linesAndPoints[randomLine].Line.transform;
                    item.SetActive(true);
                    GameHelperManager.HelperInstance.ActiveDoorCount++;
                    lastPos = gotPos;
                   // Debug.Log("Spawning pos :" + item.transform.position);
                }
               
            }
        }
    }
    

    private Vector3 GetRandomDoorPositionForPool()
    {
        
        groundToSpawn = activeGrounds.Count - 2;
        randomLine = Random.Range(0,  activeGrounds[groundToSpawn].GetComponent<GroundHolder>().linesAndPoints.Count - 1);

       
            Transform spawnLine = activeGrounds[groundToSpawn].GetComponent<GroundHolder>().linesAndPoints[randomLine].Points[Random.Range(0, 4)].transform;
        Vector3 randomPos = new Vector3(spawnLine.transform.position.x +0.1f, spawnLine.transform.position.y , spawnLine.transform.position.z);

        //// Get the bounds of the bbox collider
        //Bounds bounds = activeGrounds[groundToSpawn].GetComponent<GroundHolder>().Lines[randomLine].GetComponent<BoxCollider>().bounds;
        //float randomZ = Random.Range(bounds.min.z, bounds.max.z);
        //Vector3 randomPos = new Vector3(0.385f, -0.483f, randomZ);
        //randomPos = activeGrounds[groundToSpawn].GetComponent<GroundHolder>().Lines[randomLine].GetComponent<BoxCollider>().transform.InverseTransformPoint(randomPos);
       // Debug.Log("randomPos : " + randomPos);
        return randomPos;
    }
    #endregion
}


