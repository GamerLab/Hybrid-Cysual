using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
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


  
        [Header("swipe")]
        private float fingerStartTime = 0.0f;
        private Vector2 fingerStartPos = Vector2.zero;

        private bool isSwipe = false;
        private float minSwipeDist = 50.0f;
        private float maxSwipeTime = 0.5f;


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        Vector3 StartPos;
      
        float stopDelay = 1.5f; // Delay in seconds before stopping movement
        Vector3 currentVelocity = Vector3.zero;
        float smoothTime = 0.1f; // Smoothing time for Vector3.SmoothDamp
        bool isTouching = false;
        float touchReleaseTime = 0f;

        float horizontalInput = 0f;
        float verticalInput = 0f;
        bool setVelocityR = false;
        bool setVelocityL = false;

        private void Update()
        {

            //  Debug.Log("GameState is : " + GameManager.GMInstance.gameState);

#if UNITY_ANDROID && !UNITY_EDITOR



            if (!GameHelperManager.HelperInstance.GameStoped && isGrounded)
            {


                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        verticalInput = 1f;
                        fingerStartPos = touch.position;
                        isTouching = true;

                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        isTouching = false;
                        setVelocityL = false;
                        setVelocityR = false;

                    }
                    else if (touch.phase == TouchPhase.Stationary)
                    {
                        Debug.Log("Stationary");

                        horizontalInput = 0f;

                        setVelocityL = false;
                        setVelocityR = false;

                    }

                    if (isTouching)
                    {
                        Vector2 direction = touch.position - fingerStartPos;
                        Vector2 swipeType = Vector2.zero;

                        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                        {
                            // the swipe is horizontal:
                            swipeType = Vector2.right * Mathf.Sign(direction.x);
                        }
                        //else
                        //{
                        //    // the swipe is vertical:
                        //    swipeType = Vector2.up * Mathf.Sign(direction.y);
                        //}

                        if (swipeType.x != 0.0f)
                        {
                            if (swipeType.x > 0.0f)
                            {
                                // MOVE RIGHT
                                if (!setVelocityR)
                                {
                                    setVelocityL = false;
                                    setVelocityR = true;
                                    _rigidbody.velocity = Vector3.zero;

                                }
                                horizontalInput = 1f;
                                Debug.Log("horizontalInput" + horizontalInput);
                            }
                            else
                            {
                                // MOVE LEFT
                                if (!setVelocityL)
                                {
                                    setVelocityL = true;
                                    setVelocityR = false;
                                    _rigidbody.velocity = Vector3.zero;

                                }
                                horizontalInput = -1f;
                                Debug.Log("horizontalInput" + horizontalInput);

                            }
                        }
                    }
                }

                // Check if the touch is released and delay time has passed
                if (!isTouching)
                {
                    setVelocityL = false;
                    setVelocityR = false;
                    _rigidbody.velocity = Vector3.zero;
                    horizontalInput = 0f;
                    verticalInput = 0f;
                }

                Vector3 targetVelocity = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
                Vector3 movement = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref currentVelocity, smoothTime);

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
#endif

#if UNITY_EDITOR || UNITY_WEBGL


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

#endif
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
