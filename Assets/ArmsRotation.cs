using UnityEngine;
using UnityEngine.InputSystem;

public class ArmsRotation : MonoBehaviour
{
    [Header("Cofiguration")]
    [SerializeField] private float RotationVelocity = 40f; 
    [SerializeField] private Vector3 ejeRotacion = Vector3.forward;

    [Header("Keys")]
    [SerializeField] private Key leftRotationKey = Key.E;
    [SerializeField] private Key rightRotationKey = Key.Q;

    private void Update()
    {
        float direction = ReadDirection();
        Rotate(direction);
    }

 
    private float ReadDirection()
    {
        Keyboard teclado = Keyboard.current;
        if (teclado == null) return 0f;   

        float direction = 0f;
        if (teclado[leftRotationKey].isPressed) direction -= 1f;
        if (teclado[rightRotationKey].isPressed) direction += 1f;
        return direction;
    }
    private void Rotate(float direction)
    {
        if (direction == 0f) return;
        transform.Rotate(ejeRotacion * direction * RotationVelocity * Time.deltaTime, Space.Self);
    }
}