using UnityEngine;

public class MageRootsController : MonoBehaviour
{
    public float duration = 3f;
    public float rootRadius = 1.5f;

    private void Start()
    {
        // Procura imediatamente inimigos que já estejam dentro das raízes
        CheckForEnemies();

        // Destrói as raízes depois da duração
        Destroy(gameObject, duration);
    }

    private void CheckForEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(
            transform.position,
            rootRadius
        );

        foreach (Collider collider in colliders)
        {
            EnemyFollow enemy = collider.GetComponent<EnemyFollow>();

            if (enemy != null)
            {
                enemy.SetRooted(true);

                Debug.Log("Inimigo preso pelas raízes!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyFollow enemy = other.GetComponent<EnemyFollow>();

        if (enemy != null)
        {
            enemy.SetRooted(true);

            Debug.Log("Inimigo entrou nas raízes e foi preso!");
        }
    }

    private void OnDestroy()
    {
        // Procura inimigos próximos antes das raízes desaparecerem
        Collider[] colliders = Physics.OverlapSphere(
            transform.position,
            rootRadius
        );

        foreach (Collider collider in colliders)
        {
            EnemyFollow enemy = collider.GetComponent<EnemyFollow>();

            if (enemy != null)
            {
                enemy.SetRooted(false);

                Debug.Log("Inimigo liberado das raízes!");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(
            transform.position,
            rootRadius
        );
    }
}