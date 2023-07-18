using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace LazyTurtle
{ 
    public class DeathScene : MonoBehaviour
    {
        //[SerializeField] private Transform DroneStartPos;
        //[SerializeField] private Transform DroneEndPos;
        //[SerializeField] private bool move =true;
        //[SerializeField] private float speed = 5.0f;
        //[SerializeField] private GameObject LaserShot;
        //[SerializeField] private GameObject Drone;





        // Start is called before the first frame update
        void Start()
        {
            //Drone.transform.parent = null;
        }

        // Update is called once per frame
        void LateUpdate()
        {

            //if (move)
            //{
            //    Debug.Log("Moving");
            //    //Drone.transform.position = Vector3.MoveTowards(DroneStartPos.position, DroneEndPos.position, speed *Time.deltaTime);
            //    //if (Drone.transform.position == DroneEndPos.position)
            //    //{
            //    //    Debug.Log("equal");
            //    //    move = false;
            //    //    LaserShot.SetActive(true);
            //    //    Invoke("nowPlayPlayerDeath", 1.0f);
            //    //}

            //    var step = speed * Time.deltaTime; // calculate distance to move
            //    transform.position = Vector3.MoveTowards(DroneStartPos.position, DroneEndPos.position, step);

            //    // Check if the position of the cube and sphere are approximately equal.
            //    if (Vector3.Distance(Drone.transform.position, DroneEndPos.position) < 0.001f)
            //    {
            //        // Swap the position of the cylinder.
            //        DroneEndPos.position *= -1.0f;
            //        Debug.Log("equal");
            //        move = false;
            //        LaserShot.SetActive(true);
            //        Invoke("nowPlayPlayerDeath", 1.0f);
            //    }
            //}

        }

        public void nowPlayPlayerDeath()
        {
            Quaternion CamRot = Quaternion.Euler(new Vector3(20f, 0f, 0f));
            GameHelperManager.HelperInstance.MainCam.transform.rotation = CamRot;


            GameHelperManager.HelperInstance.deathParticle.SetActive(true);
            GameHelperManager.HelperInstance.PlayerRef.GetComponentInChildren<Animator>().SetTrigger("Die");
            GameManager.GMInstance.Invoke("GoFailed", 5.0f);
        }
    }
}
