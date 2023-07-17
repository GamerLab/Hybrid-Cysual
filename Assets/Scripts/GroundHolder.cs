using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


namespace LazyTurtle
{
    [System.Serializable]
    public class LinesAndPoints
    {
        [Header("holder for Line to pool spawn objects ")]
        [SerializeField] public GameObject Line;
        [Header("holder for Points to pool spawn objects ")]
        [SerializeField] public List<GameObject> Points = new List<GameObject>();
        

    }
    public class GroundHolder : MonoBehaviour
    {
       
        [SerializeField]
        public List<LinesAndPoints> linesAndPoints = new List<LinesAndPoints>();
        [SerializeField] public bool autoadd = false;

        private void OnEnable()
        {
            if (autoadd)
                ObstaclePopulator.PoolerInst.activeGrounds.Add(this.gameObject);
        }
        private void OnDisable()
        {
            ObstaclePopulator.PoolerInst.activeGrounds.Remove(this.gameObject);
        }

        
    }



}