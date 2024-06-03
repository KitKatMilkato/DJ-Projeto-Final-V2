using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = -10f;
    public float speed = 6f;

    public Transform GroundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    public float jumpHeight;
    public float runningSpeed = 12f;

    Vector3 velocity;
    bool isGrounded;
    float initialSpeed;

    // Declara��o de um evento de delegado
    public delegate void TutorialEventHandler();
    public static event TutorialEventHandler OnTutorialTriggered;

    void Start()
    {
        initialSpeed = speed;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TT"))
        {
            // Verificar se algu�m est� ouvindo o evento e, em seguida, chamar o evento
            if (OnTutorialTriggered != null)
            {
                OnTutorialTriggered();
            }
        }
    }
}
