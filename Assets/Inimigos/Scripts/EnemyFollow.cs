using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;

    public float speed = 2.5f;
    public float stopDistance = 1.5f;

    private bool isRooted = false;

    void Update()
    {
        // Se estiver preso pelas raízes, não se movimenta
        if (isRooted)
            return;

        if (player == null)
            return;

        float distance = Vector3.Distance(
            transform.position,
            player.position
        );

        if (distance > stopDistance)
        {
            Vector3 direction =
                (player.position - transform.position).normalized;

            // Impede o inimigo de subir ou descer
            direction.y = 0;

            // Movimento
            transform.position +=
                direction * speed * Time.deltaTime;

            // Faz o inimigo olhar para o Player
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation =
                    Quaternion.LookRotation(direction);

                transform.rotation =
                    Quaternion.Slerp(
                        transform.rotation,
                        targetRotation,
                        10f * Time.deltaTime
                    );
            }
        }
    }

    // Ativa ou desativa o efeito das raízes
    public void SetRooted(bool rooted)
    {
        isRooted = rooted;

        if (rooted)
        {
            Debug.Log("Inimigo está PRESO pelas raízes!");
        }
        else
        {
            Debug.Log("Inimigo está LIVRE!");
        }
    }
}