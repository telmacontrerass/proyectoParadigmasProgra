using UnityEngine;
using UnityEngine.InputSystem;

public class ArmsPanMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Space movementSpace = Space.Self;

    [Header("Keys")]
    [SerializeField] private Key leftKey = Key.LeftArrow;
    [SerializeField] private Key rightKey = Key.RightArrow;
    [SerializeField] private Key upKey = Key.UpArrow;
    [SerializeField] private Key downKey = Key.DownArrow;

    private void Update()
    {
        Vector2 direction = ReadDirection();
        Move(direction);
    }

    
    private Vector2 ReadDirection()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return Vector2.zero;

        Vector2 direction = Vector2.zero;
        if (keyboard[rightKey].isPressed) direction.x += 1f;
        if (keyboard[leftKey].isPressed) direction.x -= 1f;
        if (keyboard[upKey].isPressed) direction.y += 1f;
        if (keyboard[downKey].isPressed) direction.y -= 1f;
        return direction;
    }

    private void Move(Vector2 direction)
    {
        if (direction == Vector2.zero) return;

        Vector3 movement = new Vector3(direction.x, direction.y, 0f).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime, movementSpace);
    }
}
