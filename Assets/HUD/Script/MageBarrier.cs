using UnityEngine;

public class MageBarrier : MonoBehaviour
{
    public GameObject barrierVisual;

    [Header("Configuração da Barreira")]
    public float barrierDuration = 5f;

    private bool barrierActive = false;

    public void ActivateBarrier()
    {
        // Impede ativar novamente enquanto a barreira já estiver ativa
        if (barrierActive)
        {
            return;
        }

        barrierActive = true;

        barrierVisual.SetActive(true);

        // Desativa a barreira depois do tempo definido
        Invoke(nameof(DeactivateBarrier), barrierDuration);
    }

    public void DeactivateBarrier()
    {
        barrierActive = false;

        barrierVisual.SetActive(false);

        Debug.Log("Barreira Arcana desativada!");
    }
}