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

    public AudioSource footstepAudioSource; // Fonte de áudio para os passos
    public AudioClip footstepClip; // Clipe de áudio dos passos

    Vector3 velocity;
    bool isGrounded;
    float initialSpeed;

    // Declaração de um evento de delegado
    public delegate void TutorialEventHandler();
    public static event TutorialEventHandler OnTutorialTriggered;

    void Start()
    {
        initialSpeed = speed;

        // Certifique-se de que o AudioSource está configurado corretamente
        if (footstepAudioSource != null)
        {
            footstepAudioSource.clip = footstepClip;
            footstepAudioSource.loop = true; // Fazer o som de passos repetir enquanto o jogador estiver se movendo
        }
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

        // Reproduzir som de passos
        HandleFootsteps(move.magnitude > 0 && isGrounded);
    }

    void HandleFootsteps(bool isMoving)
    {
        if (isMoving)
        {
            if (!footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Play();
            }
        }
        else
        {
            if (footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Stop();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TT"))
        {
            // Verificar se alguém está ouvindo o evento e, em seguida, chamar o evento
            OnTutorialTriggered?.Invoke();
        }
    }
}

