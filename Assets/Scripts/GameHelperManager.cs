using System.Collections;
using System;
using UnityEngine;
using System.Xml.Serialization;
using TMPro;
using System.Collections.Generic;

namespace LazyTurtle
{
    [System.Serializable]
    public class QuestionAnswers
    {
        [Header("holder for Questions")]
        [SerializeField] public string Question;
        [Header("holder for TrueAnswer")]
        [SerializeField] public string TrueAnswer;
        [Header("holder for Answer1")]
        [SerializeField] public string Answer1;
        [Header("holder for Answer2")]
        [SerializeField] public string Answer2;
    }
    public class GameHelperManager : MonoBehaviour
    {
        public static GameHelperManager HelperInstance;

        [Header("Public Data References")]
        [SerializeField] public Camera DeathCam;
        [SerializeField] public Camera MainCam;
        [SerializeField] public Transform PlayerRef;
        [SerializeField] public GameObject deathParticle;
        [SerializeField] public GameObject deathScene;


        [SerializeField] public GameObject CurrentGround;
        [SerializeField] public float NewPositionZofSpawn;
        [SerializeField] public bool GameStoped = true;
        [SerializeField] public int ActiveGroundCount = 0;
        [SerializeField] public int ActiveDoorCount = 0;
        [SerializeField] public int ActiveTureFalseObjCount = 1;
        [SerializeField] public int ActiveQuestionCount = 1;
        [SerializeField] public int dummyCount = 0;





        [Space(10)]
        [Header("Ui Items Required To Scripts")]
        [Header("Xp Progression Data ")]
        [SerializeField] public GameObject XpSlider;
        [SerializeField] public bool XpTicking;

        [Space(10)]
        [Header("Notification")]
       
        [SerializeField] public GameObject NotificationUi;
        [SerializeField] public TextMeshProUGUI NotificationUitext;
        [SerializeField] public  String XpDeductNotificationtext = "Get To The Door XP Is Ticking Down !";


        [Space(10)]
        [Header("Questions")]
        [SerializeField] public List<QuestionAnswers> questionAnswersList = new List<QuestionAnswers>();
        [SerializeField] public GameObject QuestionsUi;
        [SerializeField] public TextMeshProUGUI QuestionText;
        [SerializeField] public TextMeshProUGUI Answer1Text;
        [SerializeField] public TextMeshProUGUI Answer2Text;
        [SerializeField] public String AnswerTrueNotificationtext = "Amazing Its Rite Answer !";
        [SerializeField] public String AnswerFalseNotificationtext = "Oops The Right Answer is : !";


        [Space(10)]
        [Header("Dare Things Ui")]
        [SerializeField] public List<String> DareInfo = new List<String>();
        [SerializeField] public GameObject DareUi;
        [SerializeField] public TextMeshProUGUI DareInfoText;
        [SerializeField] public TextMeshProUGUI DareTargetText;
        [SerializeField] public TextMeshProUGUI DareTragetAchivedText;
        [SerializeField] public int DareObjectsCollected = 0;
        [SerializeField] public int DareObjectsToCollect = 0;

        [SerializeField] public String ObjectCollectedGem = "Gem Collected";
        [SerializeField] public String FalseObjectCollected = "Oops Collect Other Objects!";



        [Space(10)]
        [Header("Complete")]
       
        [SerializeField] public GameObject CompeteCelibration;







        void Start()
        {
            if(HelperInstance == null){
                HelperInstance = this;
            }
       
        }

        // Update is called once per frame
        void Update()
        {
            switch ((int)GameManager.GMInstance.gameState)
            {

                case 0://Objective
                    GameStoped = true;
                    break;
                case 1://GameStart
                    GameStoped = false;
                    break;
                case 2://GamePause
                    GameStoped = true;
                    break;
                case 3://DoorSpawn
                    GameStoped = false;
                    break;
                case 4://TruthDoor
                    GameStoped = false;
                    break;
                case 5://DareDoor
                    GameStoped = false;
                    break;
                case 6://PreSuccess
                    GameStoped = true;
                    break;
                case 7://PreFail
                    GameStoped = true;
                    break;
                case 8://Failed
                    GameStoped = true;
                    break;
                case 9://Scccess
                    GameStoped = true;
                    break;
                case 10://StopToPlay
                    GameStoped = true;
                    break;



            }
        }
    }
}
