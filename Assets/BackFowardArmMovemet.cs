using UnityEngine;
using UnityEngine.InputSystem;

public class ArmsMovement : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float movementVelocity = 2f;     
    [SerializeField] private Vector3 movementAxis = Vector3.forward;

    [Header("Keys")]
    [SerializeField] private Key fowardKey = Key.R;
    [SerializeField] private Key backwardKey = Key.F;

    private void Update()
    {
        float direction = ReadDirection();
        Move(direction);
    }

    // Traduce las teclas pulsadas a -1, 0 o 1
    private float ReadDirection()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return 0f;

        float direction = 0f;
        if (keyboard[fowardKey].isPressed) direction += 1f;
        if (keyboard[backwardKey].isPressed) direction -= 1f;
        return direction;
    }

    private void Move(float direction)
    {
        if (direction == 0f) return;
        transform.Translate(movementAxis * direction * movementVelocity * Time.deltaTime, Space.Self);
    }
}