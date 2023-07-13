using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                    particleColl.SetActive(true);
                    DoorAnim.SetTrigger("goIn");
                    //GameManager.GMInstance.gameState = GameState.TruthDoor;
                    ////   PlayerPrefs.SetInt("gameState", (int)gameState);
                    //GameManager.GMInstance.UpdateGameState();
                }
                else
                {
                    particleColl.SetActive(true);
                    DoorAnim.SetTrigger("goIn");
                    //GameManager.GMInstance.gameState = GameState.DareDoor;
                    ////   PlayerPrefs.SetInt("gameState", (int)gameState);
                    //GameManager.GMInstance.UpdateGameState();
                }


            }
        }

    }
}
