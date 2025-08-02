using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private CharacterData characterData;

    private Vector2 move;

    public void OnMove(InputValue inputValue) 
    {
        move = inputValue.Get<Vector2>();
    }

    private void Update()
    {
        Vector3 direction = (GetForward() * move.y + GetRight() * move.x).normalized;
        characterController.Move(direction * characterData.MoveSpeed * Time.deltaTime);

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
