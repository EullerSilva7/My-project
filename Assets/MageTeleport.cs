using UnityEngine;

public class MageTeleport : MonoBehaviour
{
    public Camera playerCamera;
    public CharacterController controller;

    public float teleportDistance = 8f;
    public LayerMask obstacleLayer;

    void Start()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>();
        }

        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Teleport();
        }
    }

    void Teleport()
    {
        Vector3 direction = playerCamera.transform.forward;

        // Mantém o teleporte no mesmo nível do chão
        direction.y = 0f;
        direction.Normalize();

        Vector3 targetPosition = transform.position + direction * teleportDistance;

        // Verifica se existe uma parede/obstáculo no caminho
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, teleportDistance, obstacleLayer))
        {
            targetPosition = hit.point - direction * 1f;
        }

        controller.enabled = false;
        transform.position = targetPosition;
        controller.enabled = true;
    }
}