using UnityEngine;

public class ObstaclePopulator : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacles;
    

    private void Start()
    {
       // PopulateObstaclesRandomObstacles();
    }

    private void PopulateObstaclesRandomObstacles()
    {
        int randomNumberofObstacles = Random.Range(0, _obstacles.Length);

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
                _obstacles[Random.Range(0, _obstacles.Length)].SetActive(false);
                break;
            case 2: // One Active Obstacle
                foreach (GameObject obstacle in _obstacles)
                {
                    obstacle.SetActive(true);
                }
                for (int i = 0; i < 2;)
                {
                    int rng = Random.Range(0, _obstacles.Length);
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
}
