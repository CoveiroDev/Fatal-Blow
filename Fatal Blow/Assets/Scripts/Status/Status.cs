using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Timeline;

public class Status : MonoBehaviour
{
    [Header("HideInInspector")]
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Animator anim;
    [HideInInspector] public HudManager hudManager;
    [HideInInspector] public GameManager gameManager;
    [HideInInspector] private Damage[] damages;
    [HideInInspector] public Status opponent;

    [Header("Status")]
    [SerializeField] public string Name;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int currentHealth;
    [SerializeField] public int lifeAmount = 1;
    [SerializeField] public bool isDead;

    [Header("Combat")]
    [SerializeField] public int currentAttack;
    [HideInInspector] private float damagePercentage = 0.1f;
    [HideInInspector] private float damagePercentageTimer;
    [SerializeField]
    public enum TipoDeAtaque
    {
        DanoDireita,
        DanoEsquerda,
        DanoCima,
        DanoBaixo,
        DanoFrenteCritico,
        DanoCimaCritico,
        DanoBaixoCritico,
        Agarrar
    }
    [SerializeField] public TipoDeAtaque tipoAtaque;

    [Header("Animation")]
    [SerializeField] public bool isDefending;
    [SerializeField] public bool isGrabAttack;
    [SerializeField] public bool shouldMirror;
    [SerializeField] public bool rootMotion;
    [SerializeField] public bool isDoingCombo;
    [SerializeField] public bool isDoingBasicAttack;
    [SerializeField] public bool isTakingDamage;
    [SerializeField] public float horizontalSpeed;
    [SerializeField] public float verticalSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        damages = GetComponentsInChildren<Damage>();
        gameManager = FindObjectOfType<GameManager>();
        hudManager = FindObjectOfType<HudManager>();
        anim = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    private void FindOpponent()
    {
        Status[] allStatuses = FindObjectsOfType<Status>();

        foreach (Status status in allStatuses)
        {
            if (status != this)
            {
                opponent = status;
                break;
            }
        }
        if (opponent == null)
        {
            Debug.LogWarning("No opponent found.");
        }
    }
    void Start()
    {
        DeactivateDamage();
        FindOpponent();
    }
    void Update()
    {
        isDefending = anim.GetBool("isDefending");
        isGrabAttack = anim.GetBool("isGrabAttack");
        isTakingDamage = anim.GetBool("isTakingDamage");
        isDoingBasicAttack = anim.GetBool("isDoingBasicAttack");
        isDoingCombo = anim.GetBool("isDoingCombo");
        rb.isKinematic = anim.GetBool("isKinematic");
        anim.SetFloat("Horizontal", horizontalSpeed);
        anim.SetFloat("Vertical", verticalSpeed);
        anim.SetBool("Mirror", shouldMirror);

        rootMotion = anim.GetBool("RootMotion");
        anim.applyRootMotion = anim.GetBool("RootMotion");

        if (damagePercentageTimer <= 0)
        {
            currentAttack = 0;
            damagePercentageTimer = 0;
            damagePercentage = 0.01f;
        }
        else
        {
            damagePercentageTimer -= Time.deltaTime * 1;
        }

    }
    public void ResetStatus()
    {
        currentAttack = 0;
        currentHealth = maxHealth;
        hudManager.ChangeHealthSlide();
        if (isDead)
        {
            anim.CrossFade("Resurrection", 0.1f);
            isDead = false;
        }
    }
    private void Death()
    {
        if (isDead == false)
            isDead = true;

        horizontalSpeed = 0;
        verticalSpeed = 0;

        DeactivateDamage();
        lifeAmount -= 1;
        anim.CrossFade("Death", 0.1f);
        gameManager.StartCoroutine(gameManager.EndFight(gameObject.GetComponent<Status>()));

        if (GetComponent<PlayerManager>())
            gameManager.opponentWins++;

        if (GetComponent<EnemyManager>())
            gameManager.playerWins++;

    }
    public void TakeDamage(Status status)
    {
        if (isDead)
            return;

        DeactivateDamage();
        status.DeactivateDamage();

        damagePercentageTimer = 1f;

        if (damagePercentage <= 0.15f && !isDefending)
            damagePercentage = damagePercentage + 0.01f;

        if (!isDead && !opponent.isDead)
        {
            if (!isGrabAttack && opponent.isGrabAttack)
            {
                anim.Play("DefenderDano_0" + currentAttack);
                opponent.anim.Play("DefenderDano_0" + currentAttack);
            }
            else if (isGrabAttack && !opponent.isGrabAttack)
            {
                anim.Play("DefenderDano_0" + currentAttack);
                opponent.anim.Play("DefenderDano_0" + currentAttack);
            }
            else
            {
                EnemyManager enemyManager = GetComponent<EnemyManager>();

                if (enemyManager)
                {
                    int randomValue = Random.Range(0, 2);
                    switch (randomValue)
                    {
                        case 1:
                            if (status.tipoAtaque == TipoDeAtaque.Agarrar && !isGrabAttack && !opponent.isGrabAttack)
                            {
                                Agarrar();
                            }
                            else
                            {
                                if (enemyManager.cantFight == false)
                                {
                                    damagePercentage = 0.01f;
                                    int damageDefended = Mathf.RoundToInt(maxHealth * 0.01f);
                                    currentHealth -= damageDefended;
                                    anim.Play("DefenderDano_0" + currentAttack);
                                }
                                else
                                {
                                    int damageRecieved1 = Mathf.RoundToInt(maxHealth * damagePercentage);
                                    currentHealth -= damageRecieved1;
                                    if (status.tipoAtaque == TipoDeAtaque.Agarrar && !isGrabAttack && !opponent.isGrabAttack)
                                    {
                                        Agarrar();
                                    }
                                    if (status.tipoAtaque == TipoDeAtaque.DanoCima)
                                    {
                                        anim.Play("TomarDanoCima_0" + currentAttack);
                                    }
                                    if (status.tipoAtaque == TipoDeAtaque.DanoBaixo)
                                    {
                                        anim.Play("TomarDanoBaixo_0" + currentAttack);
                                    }
                                    if (status.tipoAtaque == TipoDeAtaque.DanoDireita)
                                    {
                                        anim.Play("TomarDanoDireita_0" + currentAttack);
                                    }
                                    if (status.tipoAtaque == TipoDeAtaque.DanoEsquerda)
                                    {
                                        anim.Play("TomarDanoEsquerda_0" + currentAttack);
                                    }

                                    //Critico

                                    if (status.tipoAtaque == TipoDeAtaque.DanoCimaCritico)
                                    {
                                        anim.Play("TomarDanoCimaCritico_0" + currentAttack);
                                    }
                                    if (status.tipoAtaque == TipoDeAtaque.DanoBaixoCritico)
                                    {
                                        anim.Play("TomarDanoBaixoCritico_0" + currentAttack);
                                    }
                                    if (status.tipoAtaque == TipoDeAtaque.DanoFrenteCritico)
                                    {
                                        anim.Play("TomarDanoFrenteCritico_0" + currentAttack);
                                    }
                                    break;
                                }
                            }
                            break;
                        default:
                            int damageRecieved = Mathf.RoundToInt(maxHealth * damagePercentage);
                            currentHealth -= damageRecieved;
                            if (status.tipoAtaque == TipoDeAtaque.Agarrar && !isGrabAttack && !opponent.isGrabAttack)
                            {
                                Agarrar();
                            }
                            if (status.tipoAtaque == TipoDeAtaque.DanoCima)
                            {
                                anim.Play("TomarDanoCima_0" + currentAttack);
                            }
                            if (status.tipoAtaque == TipoDeAtaque.DanoBaixo)
                            {
                                anim.Play("TomarDanoBaixo_0" + currentAttack);
                            }
                            if (status.tipoAtaque == TipoDeAtaque.DanoDireita)
                            {
                                anim.Play("TomarDanoDireita_0" + currentAttack);
                            }
                            if (status.tipoAtaque == TipoDeAtaque.DanoEsquerda)
                            {
                                anim.Play("TomarDanoEsquerda_0" + currentAttack);
                            }

                            //Critico

                            if (status.tipoAtaque == TipoDeAtaque.DanoCimaCritico)
                            {
                                anim.Play("TomarDanoCimaCritico_0" + currentAttack);
                            }
                            if (status.tipoAtaque == TipoDeAtaque.DanoBaixoCritico)
                            {
                                anim.Play("TomarDanoBaixoCritico_0" + currentAttack);
                            }
                            if (status.tipoAtaque == TipoDeAtaque.DanoFrenteCritico)
                            {
                                anim.Play("TomarDanoFrenteCritico_0" + currentAttack);
                            }
                            break;
                    }
                }
                PlayerManager playerManager = GetComponent<PlayerManager>();
                if (playerManager)
                {
                    if (isDefending)
                    {
                        if (status.tipoAtaque == TipoDeAtaque.Agarrar && !isGrabAttack && !opponent.isGrabAttack)
                        {
                            Agarrar();
                        }else
                        {
                            damagePercentage = 0.01f;
                            int damagePerTick = Mathf.RoundToInt(maxHealth * 0.01f);
                            currentHealth -= damagePerTick;
                            anim.Play("DefenderDano_0" + currentAttack);
                        }
                    }
                    else
                    {
                        if (status.tipoAtaque == TipoDeAtaque.Agarrar && !isGrabAttack && !opponent.isGrabAttack)
                        {
                            Agarrar();
                        }

                        if (status.tipoAtaque == TipoDeAtaque.DanoCima)
                        {
                            anim.Play("TomarDanoCima_0" + currentAttack);
                        }
                        if (status.tipoAtaque == TipoDeAtaque.DanoBaixo)
                        {
                            anim.Play("TomarDanoBaixo_0" + currentAttack);
                        }
                        if (status.tipoAtaque == TipoDeAtaque.DanoDireita)
                        {
                            anim.Play("TomarDanoDireita_0" + currentAttack);
                        }
                        if (status.tipoAtaque == TipoDeAtaque.DanoEsquerda)
                        {
                            anim.Play("TomarDanoEsquerda_0" + currentAttack);
                        }

                        //Critico

                        if (status.tipoAtaque == TipoDeAtaque.DanoCimaCritico)
                        {
                            anim.Play("TomarDanoCimaCritico_0" + currentAttack);
                        }
                        if (status.tipoAtaque == TipoDeAtaque.DanoBaixoCritico)
                        {
                            anim.Play("TomarDanoBaixoCritico_0" + currentAttack);
                        }
                        if (status.tipoAtaque == TipoDeAtaque.DanoFrenteCritico)
                        {
                            anim.Play("TomarDanoFrenteCritico_0" + currentAttack);
                        }
                        int damagePerTick = Mathf.RoundToInt(maxHealth * damagePercentage);
                        currentHealth -= damagePerTick;
                    }
                }
            }
        }
        hudManager.ChangeHealthSlide();

        if (currentHealth <= 0)
            currentHealth = 0;

        if (currentHealth == 0)
        {
            isDead = true;
            Death();
        }
        currentAttack++;
        if (currentAttack >= 2)
            currentAttack = 0;
    }
    private void Agarrar()
    {
        Transform opponentTransform = opponent.transform;
        Vector3 opponentPosition = opponentTransform.position;
        float offset = 0.3f;
        Vector3 destination = opponentPosition + opponentTransform.forward * offset;

        anim.Play("Agarrado_P2");
        opponent.anim.Play("Agarrado_P1");
        transform.position = destination;
    }

    public void RecieveDamage()
    {
        int damagePerTick = Mathf.RoundToInt(maxHealth * 0.1f);
        currentHealth -= damagePerTick;
        TakeDamage(opponent);
        if (!isDead)
            anim.Play("TomarDanoFrenteCritico_0" + currentAttack);
    }
    public IEnumerator ActiveDamage(TipoDeAtaque tipoDeAtaque)
    {
        switch (tipoDeAtaque)
        {
            //Especial

            case TipoDeAtaque.Agarrar:
                tipoAtaque = TipoDeAtaque.Agarrar;
                break;

            //Normal

            case TipoDeAtaque.DanoCima:
                tipoAtaque = TipoDeAtaque.DanoCima;
                break;
            case TipoDeAtaque.DanoBaixo:
                tipoAtaque = TipoDeAtaque.DanoBaixo;
                break;
            case TipoDeAtaque.DanoDireita:
                tipoAtaque = TipoDeAtaque.DanoDireita;
                break;
            case TipoDeAtaque.DanoEsquerda:
                tipoAtaque = TipoDeAtaque.DanoEsquerda;
                break;

            //Critico

            case TipoDeAtaque.DanoCimaCritico:
                tipoAtaque = TipoDeAtaque.DanoCimaCritico;
                break;
            case TipoDeAtaque.DanoBaixoCritico:
                tipoAtaque = TipoDeAtaque.DanoBaixoCritico;
                break;
            case TipoDeAtaque.DanoFrenteCritico:
                tipoAtaque = TipoDeAtaque.DanoFrenteCritico;
                break;
        }

        #region AtivarDano
        if (!isTakingDamage)
        {
            foreach (Damage damage in damages)
            {
                damage.gameObject.SetActive(true);
            }
            //yield return new WaitForSeconds(0.05f);
            //foreach (Damage damage in damages)
            //{
            //    damage.gameObject.SetActive(false);
            //}
        }
        else
        {
            DeactivateDamage();
            yield return null;
        }
        #endregion
    }
    public void DeactivateDamage()
    {
        foreach (Damage damage in damages)
        {
            damage.gameObject.SetActive(false);
        }
    }
}
