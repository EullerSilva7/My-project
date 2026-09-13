using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 30;

    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(
            gameObject.name +
            " recebeu " + damage + " de dano"
        );


        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log(gameObject.name + " morreu!");

        Destroy(gameObject);
    }
}