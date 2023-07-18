using Unity.VisualScripting;
using UnityEngine;


namespace LazyTurtle
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] public float _speed = 5f;
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
        [SerializeField] private bool Stop;

        [Space(10)]
        [Header("Animator")]
        [SerializeField] private Animator PlayerAnim;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            
           // Debug.Log("GameState is : " + GameManager.GMInstance.gameState);
            if (!GameHelperManager.HelperInstance.GameStoped && isGrounded)
            {

                // Debug.Log("Grounded is Running: " );

                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");

                Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
                _rigidbody.velocity = new Vector3(movement.x, _rigidbody.velocity.y, movement.z);


                //transform.LookAt(movement);

                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                    PlayerAnim.SetTrigger("Jump");
                }
                if (verticalInput > 0)
                {
                    PlayerAnim.SetTrigger("Run");
                }
                else
                {
                    PlayerAnim.SetTrigger("Walk");
                }

                transform.Translate(Vector3.forward * Time.deltaTime * _speed);

            }
            else
            {
                PlayerAnim.SetTrigger("Idle");
            }

           
        }

        private void FixedUpdate()
        {
            if (!GameHelperManager.HelperInstance.GameStoped)
            {

              //  Debug.Log("Chhheck Ground ");
                CheckGround();

                if (!isGrounded)
                {
                    Invoke("ApplyGravity", 2.0f);
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
