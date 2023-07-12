using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace LazyTurtle
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager GMInstance;

        public enum GameState { Objective, GameStart, GamePause, DoorSpawn, TruthDoor, DareDoor, PreSuccess, PreFail, Failed, Scccess, GameStopToPlay };
        public  GameState gameState;
      

        [Space(20)]
        [Header("UIPanels")]
        public List<GameObject> UIPanels = new List<GameObject>();

        #region Private Data
        [SerializeField]private bool XpCount = false;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            GMInstance = this;
            gameState = GameState.Objective;
         
            //PlayerPrefs.SetInt("gameState", (int)gameState);
            UpdateGameState();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.GMInstance.gameState != GameState.GamePause
              || GameManager.GMInstance.gameState == GameState.GameStart
              || GameManager.GMInstance.gameState != GameState.GameStopToPlay) {

                GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value -= 0.01f * Time.deltaTime;

            }
        }

        #region GameMAinLogic
        public void UpdateGameState()    
        {
            switch ((int)gameState)
            {
               
                case 0://Objective
                    UIPanels[0].SetActive(true);
                    break;
                case 1://GameStart
                    UIPanels[2].SetActive(true);
                    GameHelperManager.HelperInstance.XpTicking = true;
                    Invoke("ShowXpWarning", 4.0f);
                    break;
                case 2://GamePause
                    break;
                case 3://DoorSpawn
                    break;
                case 4://TruthDoor
                    break;
                case 5://DareDoor
                    break;
                case 6://PreSuccess
                    break;
                case 7://PreFail
                    break;
                case 8://Failed
                    break;
                case 9://Scccess
                    break;
                case 10://StopToPlay
                    StartCoroutine(startNoCounter());
                    break;



            }


        }

        #endregion
        #region Public Functions and coroutine s

        public void F_StartGame()
        {
            UIPanels[0].SetActive(false);
            gameState = GameState.GameStopToPlay;
         //   PlayerPrefs.SetInt("gameState", (int)gameState);
            UpdateGameState();
        }

        public IEnumerator startNoCounter()
        {
            UIPanels[1].SetActive(true);
            int countdown = 3;
            while (countdown >= 0)
            {
                
                UIPanels[1].gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = countdown.ToString() ;
                yield return new WaitForSeconds(0.5f);
                countdown--;
            }
            UIPanels[1].SetActive(false) ;
            gameState = GameState.GameStart;
            UpdateGameState();
            //   PlayerPrefs.SetInt("gameState", (int)gameState);
            StopCoroutine("startNoCounter");
        }

        public void ShowXpWarning()
        {
            StartCoroutine(ShowNotification(GameHelperManager.HelperInstance.XpDeductNotificationtext, 3.0f));
        }

        #endregion

        #region Notification
        public IEnumerator ShowNotification(string text,float offTime)
        {
          
            GameHelperManager.HelperInstance.NotificationUitext.text = text;
            GameHelperManager.HelperInstance.NotificationUi.SetActive(true);
            yield return new WaitForSeconds(offTime);

            DisableNotification();

        }
        public void DisableNotification()
        {
      
            GameHelperManager.HelperInstance.NotificationUi.SetActive(false);

        }
        #endregion
    }
}
