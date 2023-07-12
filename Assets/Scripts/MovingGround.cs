using UnityEngine;
namespace LazyTurtle {

    public class MovingGround : MonoBehaviour
    {
        //public Transform player; // Reference to the player's transform
        public float moveSpeed = 5f; // Speed at which the ground moves

        private Vector3 initialOffset; // Initial offset between the ground and the player

        private void Start()
        {

            //// Calculate the initial offset between the ground and the player
            //initialOffset = transform.position - player.position;
        }

        private void Update()
        {
            //// Calculate the target position for the ground
            //Vector3 targetPosition = player.position + initialOffset;

            //// Move the ground towards the target position
            //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);


           
        }
    }
}

