using System.Collections;
using System.Collections.Generic;
using LazyTurtle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static LazyTurtle.GameManager;
namespace LazyTurtle
{
    public class AnswerObjectHandler : MonoBehaviour
    {
        [SerializeField] public bool TrueAnswerObject;
        [SerializeField] public TextMeshProUGUI AnswerText;

        // Start is called before the first frame update
        //void Start()
        //{
        //    if (TrueAnswerObject)
        //    {
        //        //   AnswerText.text = GameHelperManager.HelperInstance.TrueAnswerText.text.ToString();
        //        this.AnswerText.text = GameHelperManager.HelperInstance.questionAnswersList[GameHelperManager.HelperInstance.ActiveQuestionCount].Answer1;
        //    }
        //    else
        //    {
        //        this.AnswerText.text = GameHelperManager.HelperInstance.questionAnswersList[GameHelperManager.HelperInstance.ActiveQuestionCount].Answer2;
        //    }
        //}
        private void OnEnable()
        {
            if (TrueAnswerObject)
            {
                //   AnswerText.text = GameHelperManager.HelperInstance.TrueAnswerText.text.ToString();
                this.AnswerText.text = GameHelperManager.HelperInstance.questionAnswersList[GameHelperManager.HelperInstance.ActiveQuestionCount].Answer1;
            }
            else
            {
                this.AnswerText.text = GameHelperManager.HelperInstance.questionAnswersList[GameHelperManager.HelperInstance.ActiveQuestionCount].Answer2;
            }
        }

        //// Update is called once per frame
        //void Update()
        //{

        //}
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {


                Debug.Log("AnswerText.text :" +this.gameObject.GetComponent<AnswerObjectHandler>().AnswerText.text);
                Debug.Log("TrueAnswer.text :" + GameHelperManager.HelperInstance.questionAnswersList[GameHelperManager.HelperInstance.ActiveQuestionCount].TrueAnswer);
                if (this.gameObject.GetComponent<AnswerObjectHandler>().AnswerText.text ==
                        GameHelperManager.HelperInstance.questionAnswersList[GameHelperManager.HelperInstance.ActiveQuestionCount].TrueAnswer)
                {
                    Debug.Log("TruthAnswer");
                    GameManager.GMInstance.DisableQuestion();

                    GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value += 0.5f;

                    GameManager.GMInstance.StartCoroutine(GameManager.GMInstance.ShowNotification(GameHelperManager.HelperInstance.AnswerTrueNotificationtext, 1.5f));

                    if (GameHelperManager.HelperInstance.dummyCount == GameManager.GMInstance.CurrentLevel)
                    {
                        GameManager.GMInstance.gameState = GameState.PreSuccess;
                        //   PlayerPrefs.SetInt("gameState", (int)gameState);
                        GameManager.GMInstance.UpdateGameState();
                    }
                    else
                    {
                        GameManager.GMInstance.gameState = GameState.DoorSpawn;
                        //   PlayerPrefs.SetInt("gameState", (int)gameState);
                        GameManager.GMInstance.UpdateGameState();
                    }

                    foreach (GameObject item in ObstaclePopulator.PoolerInst.TrueFalseObjects)
                    {
                        GameHelperManager.HelperInstance.ActiveTureFalseObjCount--;
                        item.SetActive(false);
                        item.transform.parent = null;

                    }
                }
                else if (this.gameObject.GetComponent<AnswerObjectHandler>().AnswerText.text !=
                        GameHelperManager.HelperInstance.questionAnswersList[GameHelperManager.HelperInstance.ActiveQuestionCount].TrueAnswer)
                {
                    Debug.Log("FalseAnswer");
                    GameManager.GMInstance.DisableQuestion();
                    GameHelperManager.HelperInstance.XpSlider.GetComponent<Slider>().value -= 0.1f;

                    GameManager.GMInstance.StartCoroutine(GameManager.GMInstance.ShowNotification(GameHelperManager.HelperInstance.AnswerFalseNotificationtext, 1.5f));

                    if (GameHelperManager.HelperInstance.dummyCount == GameManager.GMInstance.CurrentLevel)
                    {
                        GameManager.GMInstance.gameState = GameState.PreFail;
                        //   PlayerPrefs.SetInt("gameState", (int)gameState);
                        GameManager.GMInstance.UpdateGameState();
                    }
                    else
                    {
                        GameManager.GMInstance.gameState = GameState.DoorSpawn;
                        //   PlayerPrefs.SetInt("gameState", (int)gameState);
                        GameManager.GMInstance.UpdateGameState();
                    }

                    foreach (GameObject item in ObstaclePopulator.PoolerInst.TrueFalseObjects)
                    {
                        GameHelperManager.HelperInstance.ActiveTureFalseObjCount--;
                        item.SetActive(false);
                        item.transform.parent = null;
                    }
                }



            }
        }
    }
}

