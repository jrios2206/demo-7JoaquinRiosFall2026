using UnityEngine;
using UnityEngine.InputSystem;

public class batController : MonoBehaviour
{
    private InputAction _playerMove;
    private InputAction _playerLook;
    private CharacterController _controller;
    public float mouseSensitivity = 0.1f;
    public float playerMoveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerMove = InputSystem.actions.FindAction("Move");
        _playerLook = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = _playerMove.ReadValue<Vector2>(); //x and y wsad, getting values.
        Vector2 lookValue = _playerLook.ReadValue<Vector2>(); // x and y  mouse, getting values.
        Vector3 movement = transform.forward * moveValue.y + transform.right * moveValue.x;
        transform.Rotate(0,lookValue.x * mouseSensitivity,0);
        if (Keyboard.current.spaceKey.isPressed)
        {
            movement += Vector3.up;
        }

        if (Keyboard.current.leftCtrlKey.isPressed)
        {
            movement += Vector3.down;
        }
        
        _controller.Move(movement * (playerMoveSpeed * Time.deltaTime));

    }
}
