using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private void OnEnable()
    {
        InputManager.Instance.actions.Player.Jump.performed += OnJumpPerformed;
    }
    private void OnDisable()
    {
        InputManager.Instance.actions.Player.Jump.performed -= OnJumpPerformed;
    }
    private void OnJumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump action performed");
            // Add your jump logic here
        }
    }
    private void Update()
    {
        // You can also check for other input actions here if needed
        if (InputManager.Instance.actions.Player.Move.ReadValue<Vector2>() != Vector2.zero)
        {
            Debug.Log("Player is moving");
            // Add your movement logic here
        }
    }
}
