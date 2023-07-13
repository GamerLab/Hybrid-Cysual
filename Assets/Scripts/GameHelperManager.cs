using System.Collections;
using System;
using UnityEngine;
using System.Xml.Serialization;
using TMPro;
using System.Collections.Generic;

namespace LazyTurtle
{
    public class GameHelperManager : MonoBehaviour
    {
        public static GameHelperManager HelperInstance;

        [Header("Public Data References")]
     
        [SerializeField] public GameObject CurrentGround;
        [SerializeField] public Transform PlayerRef;
        [SerializeField] public float NewPositionZofSpawn;
        [SerializeField] public bool GameStoped = true;
        [SerializeField] public int ActiveGroundCount = 0;
        [SerializeField] public int ActiveDoorCount = 0;




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
                    GameStoped = false;
                    break;
                case 7://PreFail
                    GameStoped = false;
                    break;
                case 8://Failed
                    GameStoped = false;
                    break;
                case 9://Scccess
                    GameStoped = false;
                    break;
                case 10://StopToPlay
                    GameStoped = true;
                    break;



            }
        }
    }
}
