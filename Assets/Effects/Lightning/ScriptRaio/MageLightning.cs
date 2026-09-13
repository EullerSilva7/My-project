using UnityEngine;

public class MageLightning : MonoBehaviour
{
    [Header("Configuração")]
    public Camera playerCamera;
    public Transform firePoint;

    [Header("Raio")]
    public float range = 15f;
    public int damage = 25;

    [Header("Efeitos")]
    public GameObject lightningEffect;
    public GameObject impactEffect;

    [Header("Tempo")]
    public float effectDuration = 0.25f;

    [Header("Posição do raio")]
    public float lightningHeight = 0.5f;

    void Awake()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    public void CastLightning()
    {
        if (playerCamera == null)
        {
            Debug.LogError(
                "Main Camera não encontrada!"
            );

            return;
        }

        if (firePoint == null)
        {
            Debug.LogError(
                "FirePoint não configurado!"
            );

            return;
        }

        // Direção do centro da câmera
        Vector3 direction =
            playerCamera.transform.forward.normalized;

        Debug.Log(
            "Raio lançado na direção: " +
            direction
        );

        // Raycast
        Ray ray = new Ray(
            playerCamera.transform.position,
            direction
        );

        RaycastHit hit;

        if (Physics.Raycast(
            ray,
            out hit,
            range))
        {
            Debug.Log(
                "Raio acertou: " +
                hit.collider.gameObject.name
            );

            // Procura o EnemyHealth
            EnemyHealth enemy =
                hit.collider.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);

                Debug.Log(
                    "Raio causou " +
                    damage +
                    " de dano!"
                );
            }

            // Efeito de impacto
            if (impactEffect != null)
            {
                GameObject impact =
                    Instantiate(
                        impactEffect,
                        hit.point,
                        Quaternion.identity
                    );

                Destroy(
                    impact,
                    effectDuration
                );
            }
        }
        else
        {
            Debug.Log(
                "Raio não acertou nada."
            );
        }

        // Efeito visual do raio
        if (lightningEffect != null)
        {
            Vector3 spawnPosition =
                firePoint.position;

            spawnPosition.y += lightningHeight;

            GameObject effect =
                Instantiate(
                    lightningEffect,
                    spawnPosition,
                    Quaternion.identity
                );

            Destroy(
                effect,
                effectDuration
            );
        }
    }
}