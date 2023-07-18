using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace LazyTurtle
{
    public class LevelEndPreSuccess : MonoBehaviour
    {
        [SerializeField] public List<GameObject> points = new List<GameObject>();
        [SerializeField] public GameObject GoldCoins;
        [SerializeField] public GameObject SilverCoins;
        [SerializeField] public GameObject BronzeCoins;
        [SerializeField] public int  TotalSpawned;
        [SerializeField] public int MaxSpawned;
        [SerializeField] public float spawnDelay;
      
        [SerializeField] private int randomNo = 0;



        private void OnEnable()
        {
            InvokeRepeating("SpawnCoinWinAnim", 0f, spawnDelay);
        }

        void SpawnCoinWinAnim()
        {
            if (TotalSpawned < MaxSpawned)
            {
                if (GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value > 0.5f)
                {
                    GameObject clone = Instantiate(GoldCoins, points[randomNo].transform.position, GoldCoins.transform.rotation);
                    TotalSpawned++;
                    randomNo++;
                }
                else if (GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value > 0.3f &&
                    GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value < 0.6f)
                {
                    GameObject clone = Instantiate(SilverCoins, points[randomNo].transform.position, SilverCoins.transform.rotation);
                    TotalSpawned++;
                    randomNo++;
                }
                else if (GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value > 0 &&
                  GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value < 0.4f)
                {
                    GameObject clone = Instantiate(SilverCoins, points[randomNo].transform.position, SilverCoins.transform.rotation);
                    TotalSpawned++;
                    randomNo++;
                }
                if (randomNo > 2)
                {
                    randomNo = 0;
                }
            }

        }

        int randomSpawnPoint()
        {
            int randomNo = UnityEngine.Random.Range(0, points.Count);
            return randomNo;
        }
        //int countRandom()
        //{

        //    // randomNo = randomNo != 0 ? randomNo = (randomNo < points.Count - 1) ? (randomNo += counter) : (randomNo = 0) : randomNo = 0;
       
        //    Debug.Log("randomNo =" + randomNo);
        //    return randomNo;
        //}
    }
}
