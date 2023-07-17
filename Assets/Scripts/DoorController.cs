using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static LazyTurtle.GameManager;

namespace LazyTurtle
{

    public class DoorController : MonoBehaviour
    {
        [SerializeField] public bool TruthDoor;
        [SerializeField] public GameObject particleColl;
        [SerializeField] public Animator DoorAnim;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (this.TruthDoor)
                {
                    Debug.Log("Collided with Truth");
                    particleColl.SetActive(true);
                    DoorAnim.SetTrigger("goIn");
                    GameManager.GMInstance.gameState = GameState.TruthDoor;
                    //   PlayerPrefs.SetInt("gameState", (int)gameState);
                    GameManager.GMInstance.UpdateGameState();
                    StartCoroutine(Disable());
                }
                else
                {
                    Debug.Log("Collided with False");
                    particleColl.SetActive(true);
                    DoorAnim.SetTrigger("goIn");
                    GameManager.GMInstance.gameState = GameState.DareDoor;
                    //   PlayerPrefs.SetInt("gameState", (int)gameState);
                    GameManager.GMInstance.UpdateGameState();
                    StartCoroutine( Disable());


                }


            }
        }


        public IEnumerator Disable()
        {
            yield return new WaitForSeconds(0.5f);
            particleColl.SetActive(false);
            foreach (var item in ObstaclePopulator.PoolerInst.Doors)
            {
                GameHelperManager.HelperInstance.ActiveDoorCount--;
                item.gameObject.SetActive(false);
            }
        }

        //private void OnDisable()
        //{
        //    particleColl.SetActive(false);
        //    GameHelperManager.HelperInstance.ActiveDoorCount--;
        //}

    }
}
