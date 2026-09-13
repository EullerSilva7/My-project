using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 5f;
    public float sprintSpeed = 8f;

    [Header("Gravidade")]
    public float gravity = -9.81f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // =========================
        // MOVIMENTO
        // =========================

        Vector2 input = Vector2.zero;

        // Teclado WASD
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed)
                input.y += 1;

            if (Keyboard.current.sKey.isPressed)
                input.y -= 1;

            if (Keyboard.current.aKey.isPressed)
                input.x -= 1;

            if (Keyboard.current.dKey.isPressed)
                input.x += 1;
        }

        // Controle - Analógico esquerdo
        if (Gamepad.current != null)
        {
            Vector2 stick = Gamepad.current.leftStick.ReadValue();

            if (stick.magnitude > input.magnitude)
            {
                input = stick;
            }
        }

        // Evita velocidade maior na diagonal
        if (input.magnitude > 1f)
        {
            input.Normalize();
        }

        Vector3 move = transform.right * input.x +
                       transform.forward * input.y;

        // =========================
        // CORRIDA
        // =========================

        float currentSpeed = speed;

        // Segurar SHIFT ESQUERDO
        if (Keyboard.current != null &&
            Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed = sprintSpeed;
        }

        // =========================
        // MOVIMENTO
        // =========================

        controller.Move(
            move * currentSpeed * Time.deltaTime
        );

        // =========================
        // GRAVIDADE
        // =========================

        Vector3 gravityMove = Vector3.up * gravity;

        controller.Move(
            gravityMove * Time.deltaTime
        );
    }
}