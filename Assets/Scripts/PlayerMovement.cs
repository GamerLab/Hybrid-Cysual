using Unity.VisualScripting;
using UnityEngine;
using static LazyTurtle.GameManager;

namespace LazyTurtle
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] public float _speed = 5f;
        public Transform[] _lanes;
        [SerializeField] public float _distToGround = 0.1f;
        [SerializeField] public Transform raycastpoint;

        [SerializeField] public bool _canMove = true;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] public float moveSpeed = 5f;

        [Space(10)]
        [Header("Jump Thhings")]
        [SerializeField] private bool isJumping;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private bool isGrounded;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void LateUpdate()
        {
            if (GameManager.GMInstance.gameState != GameState.Objective || GameManager.GMInstance.gameState != GameState.GamePause || GameManager.GMInstance.gameState != GameState.GameStopToPlay)
            {


                if (isGrounded)
                {
                    float horizontalInput = Input.GetAxis("Horizontal");
                    float verticalInput = Input.GetAxis("Vertical");

                    Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
                    _rigidbody.velocity = new Vector3(movement.x, _rigidbody.velocity.y, movement.z);

                    if (Input.GetButtonDown("Jump"))
                    {
                        Jump();
                    }
                    transform.Translate(Vector3.forward * Time.deltaTime * _speed);
                }
            }
        }

        private void FixedUpdate()
        {
            if (GameManager.GMInstance.gameState != GameState.Objective || GameManager.GMInstance.gameState != GameState.GamePause || GameManager.GMInstance.gameState != GameState.GameStopToPlay)

            {


                CheckGround();

                if (!isGrounded)
                {
                    ApplyGravity();
                }
            }
        }

        private void CheckGround()
        {
            RaycastHit hit;
            if (Physics.Raycast(raycastpoint.position, Vector3.down, out hit, _distToGround))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    isGrounded = true;
                }
                else
                {
                    isGrounded = false;
                }
            }
            else
            {
                isGrounded = false;
            }
        }

        private void ApplyGravity()
        {
            _rigidbody.AddForce(Physics.gravity, ForceMode.Acceleration);
        }

        private void Jump()
        {
            if (isGrounded)
            {
                isJumping = true;
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
        }
    }
}
