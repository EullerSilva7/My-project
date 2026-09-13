using UnityEngine;
using UnityEngine.UI;

public class MagicHUD : MonoBehaviour
{
    [Header("Ícones das Magias")]
    public Image fireIcon;
    public Image lightningIcon;
    public Image rootsIcon;
    public Image barrierIcon;

    [Header("Cores")]
    public Color normalColor = Color.white;
    public Color selectedColor = Color.yellow;

    [Header("Tamanho")]
    public float normalScale = 1f;
    public float selectedScale = 1.2f;


    private void Start()
    {
        // Fogo começa selecionado
        SelectMagic(1);
    }


    public void SelectMagic(int magic)
    {
        // Volta todos os ícones para o estado normal
        SetNormal(fireIcon);
        SetNormal(lightningIcon);
        SetNormal(rootsIcon);
        SetNormal(barrierIcon);


        // Destaca somente a magia selecionada
        switch (magic)
        {
            case 1:
                SetSelected(fireIcon);
                break;

            case 2:
                SetSelected(lightningIcon);
                break;

            case 3:
                SetSelected(rootsIcon);
                break;

            case 4:
                SetSelected(barrierIcon);
                break;
        }
    }


    private void SetNormal(Image icon)
    {
        if (icon == null)
            return;

        icon.color = normalColor;
        icon.transform.localScale = Vector3.one * normalScale;
    }


    private void SetSelected(Image icon)
    {
        if (icon == null)
            return;

        icon.color = selectedColor;
        icon.transform.localScale = Vector3.one * selectedScale;
    }
}