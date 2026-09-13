using UnityEngine;

public class MageAttackController : MonoBehaviour
{
    [Header("Ataques")]
    public WeaponShoot fireAttack;
    public MageLightning lightningAttack;
    public MageBarrier barrierAttack;
    public WeaponAnimator weaponAnimator;

    [Header("Raízes")]
    public GameObject mageRootsPrefab;
    public Transform rootsSpawnPoint;

    [Header("Câmera")]
    public Camera playerCamera;

    [Header("Configuração das Raízes")]
    public float rootsRange = 20f;

    [Header("HUD")]
    public MagicHUD magicHUD;

    private int selectedAttack = 1;

    void Start()
    {
        // Começa com Fogo selecionado
        if (magicHUD != null)
        {
            magicHUD.SelectMagic(selectedAttack);
        }
    }

    void Update()
    {
        // =========================
        // SELEÇÃO DE ATAQUES
        // =========================

        // FOGO
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedAttack = 1;

            if (magicHUD != null)
            {
                magicHUD.SelectMagic(1);
            }

            Debug.Log("Ataque selecionado: Fogo");
        }

        // RAIO
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedAttack = 2;

            if (magicHUD != null)
            {
                magicHUD.SelectMagic(2);
            }

            Debug.Log("Ataque selecionado: Raio");
        }

        // RAÍZES
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedAttack = 3;

            if (magicHUD != null)
            {
                magicHUD.SelectMagic(3);
            }

            Debug.Log("Ataque selecionado: Raízes");
        }

        // BARREIRA ARCANA
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedAttack = 4;

            if (magicHUD != null)
            {
                magicHUD.SelectMagic(4);
            }

            Debug.Log("Ataque selecionado: Barreira Arcana");
        }


        // =========================
        // USAR ATAQUE
        // =========================

        if (Input.GetMouseButtonDown(0))
        {
            UseSelectedAttack();
        }
    }


    void UseSelectedAttack()
    {
        switch (selectedAttack)
        {
            case 1:
                Fire();
                break;

            case 2:
                Lightning();
                break;

            case 3:
                Roots();
                break;

            case 4:
                Barrier();
                break;
        }
    }


    // =========================
    // FOGO
    // =========================

    void Fire()
    {
        if (weaponAnimator != null)
        {
            weaponAnimator.PlayFireAnimation();
        }

        if (fireAttack != null)
        {
            fireAttack.Shoot();
        }
        else
        {
            Debug.LogWarning("FireAttack não está configurado!");
        }
    }


    // =========================
    // RAIO
    // =========================

    void Lightning()
    {
        if (weaponAnimator != null)
        {
            weaponAnimator.PlayLightningAnimation();
        }

        if (lightningAttack != null)
        {
            lightningAttack.CastLightning();
        }
        else
        {
            Debug.LogWarning("LightningAttack não está configurado!");
        }
    }


    // =========================
    // RAÍZES
    // =========================

    void Roots()
    {
        if (weaponAnimator != null)
        {
            // IMPORTANTE:
            // Aqui usamos a animação própria das raízes.
            weaponAnimator.PlayRootsAnimation();
        }

        Debug.Log("Ataque de raízes ativado!");
    }


    // =========================
    // BARREIRA ARCANA
    // =========================

    void Barrier()
    {
        if (barrierAttack != null)
        {
            barrierAttack.ActivateBarrier();

            Debug.Log("Barreira Arcana ativada!");
        }
        else
        {
            Debug.LogWarning("BarrierAttack não está configurado!");
        }
    }


    // =====================================================
    // CHAMADO PELO ANIMATION EVENT DA ANIMAÇÃO ATTACKROOTS
    // =====================================================

    public void SpawnMageRoots()
    {
        if (mageRootsPrefab == null)
        {
            Debug.LogWarning("MageRoots Prefab não foi configurado!");
            return;
        }

        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        if (playerCamera == null)
        {
            Debug.LogWarning("Main Camera não encontrada!");
            return;
        }


        // Centro da tela
        Vector3 screenCenter = new Vector3(
            Screen.width / 2f,
            Screen.height / 2f,
            0f
        );


        // Cria um raio saindo do centro da câmera
        Ray ray = playerCamera.ScreenPointToRay(screenCenter);

        RaycastHit hit;


        // Procura o chão
        if (Physics.Raycast(ray, out hit, rootsRange))
        {
            // Cria as raízes exatamente onde o raio acertou
            Instantiate(
                mageRootsPrefab,
                hit.point,
                Quaternion.identity
            );

            Debug.Log("MageRoots criado em: " + hit.point);
        }
        else
        {
            Debug.LogWarning("As raízes não encontraram o chão!");
        }
    }
}