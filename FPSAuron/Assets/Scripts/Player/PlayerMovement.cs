using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    Vector2 moveInput;
    public float speed = 5f;

    public float gravity = -9.81f;
    Vector3 velocity;


    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;  // que no salte encima de enemigos u otros objetos
    bool isGrounded;

    public float jumpHeight = 3f;

    void Update()
    {
        float x = moveInput.x;
        float z = moveInput.y;
        Vector3 move = transform.right * x + transform.forward * z; 
        characterController.Move(move * speed * Time.deltaTime); 


        velocity.y += gravity * Time.deltaTime; 
        characterController.Move(velocity * Time.deltaTime); 

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // para que no se quede pegado al suelo
        }

        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
