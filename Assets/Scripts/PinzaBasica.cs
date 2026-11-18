using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class PinzaBasica : MonoBehaviour
{
    [SerializeField] private Transform dedoIzquierdo;
    [SerializeField] private Transform dedoDerecho;

    private void Update()
    {
#if ENABLE_INPUT_SYSTEM
        bool cerrar = Keyboard.current != null
                      && Keyboard.current.spaceKey.isPressed;
#else
        bool cerrar = Input.GetKey(KeyCode.Space);
#endif

        float distancia = 0.30f;

        if (cerrar)
        {
            distancia = 0.15f;
        }

        dedoIzquierdo.localPosition = new Vector3(-distancia, 0f, 0f);
        dedoDerecho.localPosition = new Vector3(distancia, 0f, 0f);
    }

}