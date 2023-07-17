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

        [Space(10)]
        [Header("Required Variable Data ")]

        [SerializeField] public float InitialDoorSpawnTime;
        [SerializeField] public float DoorSpawnDelay;
        [SerializeField] public int CurrentLevel;
        //#region Private Data
        //[SerializeField]private bool XpCount = false;
        //#endregion

        // Start is called before the first frame update
        void Start()
        {
            GMInstance = this;
            gameState = GameState.Objective;
            CurrentLevel =UnityEngine.Random.Range(4, 10);
            //PlayerPrefs.SetInt("gameState", (int)gameState);
            UpdateGameState();
        }

        // Update is called once per frame
        void Update()
        {
            
            switch ((int)gameState)
            {

                case 0://Objective              
                    break;
                case 1://GameStart
                    if (GameHelperManager.HelperInstance.XpTicking)
                    {
                        Debug.Log("GameStart");
                        GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value -= 0.01f * Time.deltaTime;
                    }
                    break;
                case 2://GamePause
                    break;
                case 3://DoorSpawn
                    Debug.Log("DoorSpawn");
                   
                    if (GameHelperManager.HelperInstance.XpTicking)
                    {
                        GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value -= 0.01f * Time.deltaTime;
                    }
                    break;
                case 4://TruthDoor
                    Debug.Log("TruthDoor");
                    
                    if (GameHelperManager.HelperInstance.XpTicking)
                    {
                        GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value -= 0.01f * Time.deltaTime;
                    }
                    break;
                case 5://DareDoor
                    Debug.Log("DareDoor");
                   
                    if (GameHelperManager.HelperInstance.XpTicking)
                    {
                        GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value -= 0.01f * Time.deltaTime;
                    }
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
                    break;



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

                    Invoke("ShowXpWarning", 3.0f);
                    Invoke("InvokeDoorSpawning", InitialDoorSpawnTime);
                    break;
                case 2://GamePause
                    break;
                case 3://DoorSpawn
                    ObstaclePopulator.PoolerInst.SpawnDoorsNow();
                    break;
                case 4://TruthDoor
                    Invoke("ShowQuestion", 1.0f);
                    ObstaclePopulator.PoolerInst.SpawnTrueFalseObjectNow();
                    break;
                case 5://DareDoor
                    GameManager.GMInstance.gameState = GameState.DoorSpawn;
                    GameManager.GMInstance.UpdateGameState();
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
            StopCoroutine("ShowNotification");
        }
        public void DisableNotification()
        {
      
            GameHelperManager.HelperInstance.NotificationUi.SetActive(false);

        }
        #endregion

        #region Helping Functions

        private void InvokeDoorSpawning()
        {
            gameState = GameManager.GameState.DoorSpawn;
            UpdateGameState();
            Debug.Log("InvokeDoorSpawning");
        }


        #endregion

        #region Question Answer

        public void ShowQuestion()
        {
            //GameHelperManager.HelperInstance.ActiveQuestionCount = PlayerPrefs.GetInt("ActiveQuestionCount");
            //if (GameHelperManager.HelperInstance.ActiveQuestionCount >= GameHelperManager.HelperInstance.questionAnswersList.Count)
            //{
            //    GameHelperManager.HelperInstance.ActiveQuestionCount = 0;
            //}
            GameHelperManager.HelperInstance.ActiveQuestionCount = UnityEngine.Random.Range(0, GameHelperManager.HelperInstance.questionAnswersList.Count);
            PlayerPrefs.SetInt("ActiveQuestionCount", GameHelperManager.HelperInstance.ActiveQuestionCount);

            GameHelperManager.HelperInstance.QuestionText.text
                = GameHelperManager.HelperInstance.questionAnswersList[GameHelperManager.HelperInstance.ActiveQuestionCount].Question;
            GameHelperManager.HelperInstance.Answer1Text.text
                = GameHelperManager.HelperInstance.questionAnswersList[GameHelperManager.HelperInstance.ActiveQuestionCount].Answer1;
            GameHelperManager.HelperInstance.Answer2Text.text
                = GameHelperManager.HelperInstance.questionAnswersList[GameHelperManager.HelperInstance.ActiveQuestionCount].Answer2;
            GameHelperManager.HelperInstance.QuestionsUi.SetActive(true);

        }
        bool textMatched = false;
      


        
        public void DisableQuestion()
        {
            //GameHelperManager.HelperInstance.ActiveQuestionCount++;
            //PlayerPrefs.SetInt("ActiveQuestionCount", GameHelperManager.HelperInstance.ActiveQuestionCount);
  
            GameHelperManager.HelperInstance.dummyCount++;

            //GameHelperManager.HelperInstance.QuestionText.text
            //= ' '.ToString();
            //GameHelperManager.HelperInstance.Answer1Text.text
            //= ' '.ToString();
            //GameHelperManager.HelperInstance.Answer2Text.text
            //= ' '.ToString();
            GameHelperManager.HelperInstance.QuestionsUi.SetActive(false);
        }


        #endregion

     
    }
}

