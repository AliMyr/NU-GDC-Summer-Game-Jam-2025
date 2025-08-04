using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private CharacterData characterData;

    private float currentSpeed;

    private float verticalVelocity;
    private bool isGrounded;
    private Vector3 velocity;

    private Vector2 move;



    private void Awake()
    {
        Initialize(characterData);
    }

    private void Initialize(CharacterData characterData)
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        currentSpeed = characterData.WalkSpeed;
    }

    public void OnMove(InputValue inputValue) 
    {
        move = inputValue.Get<Vector2>();
    }

    public void OnSprint(InputValue inputValue)
    {
        if(inputValue.Get<float>() > 0.5f)
        {
            currentSpeed = characterData.SprintSpeed;
        }
        else
        {
            currentSpeed = characterData.WalkSpeed;
        }
    }

    public void OnJump(InputValue inputValue)
    {
        if (isGrounded && inputValue.isPressed)
        {
            verticalVelocity = Mathf.Sqrt(characterData.JumpHeight * -2f * characterData.Gravity);
        }
    }


    private void Update()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && verticalVelocity < 0)
            verticalVelocity = -2f; // принудительное прилипание к земле

        Vector3 direction = (GetForward() * move.y + GetRight() * move.x).normalized;
        Vector3 horizontalMove = direction * currentSpeed;

        verticalVelocity += characterData.Gravity * Time.deltaTime;
        velocity = new Vector3(horizontalMove.x, verticalVelocity, horizontalMove.z);

        characterController.Move(velocity * Time.deltaTime);


    }


    private Vector3 GetForward()
    {
        Vector3 forward = cinemachineCamera.transform.forward;
        forward.y = 0; // Ignore vertical component
        return forward.normalized;
    }
    private Vector3 GetRight()
    {
        Vector3 right = cinemachineCamera.transform.right;
        right.y = 0; // Ignore vertical component
        return right.normalized;
    }
}
