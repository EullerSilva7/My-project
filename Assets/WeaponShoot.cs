using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Camera playerCamera;


    public void Shoot()
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile não configurado!");
            return;
        }


        if (firePoint == null)
        {
            Debug.LogError("FirePoint não configurado!");
            return;
        }


        if (playerCamera == null)
        {
            Debug.LogError("Camera não configurada!");
            return;
        }


        // A magia nasce na ponta do cajado
        Vector3 spawnPosition = firePoint.position;


        GameObject projectileObject = Instantiate(
            projectilePrefab,
            spawnPosition,
            Quaternion.identity
        );


        Projectile projectile = projectileObject.GetComponent<Projectile>();


        if (projectile != null)
        {
            // Direção da câmera
            Vector3 direction = playerCamera.transform.forward.normalized;


            Debug.Log("Direção da magia: " + direction);


            projectile.direction = direction;


            // Faz a magia apontar para onde vai
            projectileObject.transform.rotation =
                Quaternion.LookRotation(direction);
        }
        else
        {
            Debug.LogError("Projectile não possui Projectile.cs!");
        }
    }
}