using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private CharacterData characterData;

    private float currentSpeed;

    private Vector2 move;

    private void Awake()
    {
        Initialize(characterData);
    }

    private void Initialize(CharacterData characterData)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

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

    private void Update()
    {
        Vector3 direction = (GetForward() * move.y + GetRight() * move.x).normalized;
        characterController.Move(direction * currentSpeed * Time.deltaTime);

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
