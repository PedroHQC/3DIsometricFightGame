using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerInputActions inputActions;

    public Vector2 movementVector;
    void Awake()
    {
        inputActions = new();
    }
    void OnEnable()
    {
        inputActions.PlayerMovementActions.Movement.performed += GetMovementVector;
        inputActions.PlayerMovementActions.Movement.canceled += GetMovementVector;
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
        inputActions.PlayerMovementActions.Movement.performed -= GetMovementVector;
        inputActions.PlayerMovementActions.Movement.canceled -= GetMovementVector;
    }

    private void GetMovementVector(InputAction.CallbackContext cntx)
    {
        movementVector = cntx.ReadValue<Vector2>();
    }


}
