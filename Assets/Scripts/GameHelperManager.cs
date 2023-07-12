using System.Collections;
using System;
using UnityEngine;
using System.Xml.Serialization;
using TMPro;

namespace LazyTurtle
{
    public class GameHelperManager : MonoBehaviour
    {
        public static GameHelperManager HelperInstance;

        [Header("Public Data References")]
     
        [SerializeField] public GameObject CurrentGround;
        [SerializeField] public Transform PlayerRef;
        [SerializeField] public float NewPositionZofSpawn;


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

        //// Update is called once per frame
        //void Update()
        //{

        //}
    }
}
