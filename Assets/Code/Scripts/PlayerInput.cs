using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
	#region Fields
	private PlayerInputSystem _playerInputSys;
	private InputAction _inputActionMove;
	private InputAction _inputActionMouseLook;
    #endregion


    #region Main Methods
    private void OnEnable()
    {
        _inputActionMove = _playerInputSys.Player.Move;
        _inputActionMouseLook = _playerInputSys.Player.MouseLook;

        _inputActionMove.Enable();
        _inputActionMouseLook.Enable();
    }

    private void Awake()
    {
        _playerInputSys = new PlayerInputSystem();
    }

    private void OnDisable()
    {
        _inputActionMove.Disable();
        _inputActionMouseLook.Disable();
    }
    #endregion


    #region Helper Methods
    internal Vector2 GetMoveDirection()
    {
        Vector2 moveDirection;
        moveDirection = _inputActionMove.ReadValue<Vector2>();
        return moveDirection;
    }

    internal Vector2 GetMouseLook()
    {
        Vector2 mouseLook;
        mouseLook = _inputActionMouseLook.ReadValue<Vector2>();
        return mouseLook;
    }
    #endregion
}

