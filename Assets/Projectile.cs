using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public int damage = 10;

    [HideInInspector]
    public Vector3 direction;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Collider projectileCollider =
                GetComponent<Collider>();

            Collider[] playerColliders =
                player.GetComponentsInChildren<Collider>();

            foreach (Collider playerCollider in playerColliders)
            {
                if (projectileCollider != null &&
                    playerCollider != null)
                {
                    Physics.IgnoreCollision(
                        projectileCollider,
                        playerCollider
                    );
                }
            }
        }

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position +=
            direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(
            "Projétil acertou: " +
            other.gameObject.name
        );

        EnemyHealth enemy =
            other.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);

            Debug.Log(
                "Inimigo recebeu " +
                damage +
                " de dano."
            );

            Destroy(gameObject);
        }
    }
}