using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [Header("HideInInspector")]
    [HideInInspector] private Animator anim;
    [HideInInspector] private Status status;
    [HideInInspector] private Rigidbody rb;

    [Header("Combo")]
    [SerializeField] private ComboList comboList;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        comboList = GetComponent<ComboList>();
        status = GetComponent<Status>();
        anim = GetComponent<Animator>();

        StartCoroutine(FightOpponent());
    }
    public IEnumerator FightOpponent()
    {
        while (!status.opponent.isDead)
        {
            LookAtOpponent();
            float timeToRestart = 0;
            while (timeToRestart <= 0.1f)
            {
                status.horizontalSpeed = Mathf.Lerp(status.horizontalSpeed, 0, Time.deltaTime * 10f);
                if (!status.isDoingBasicAttack && !status.isDoingCombo && !status.isTakingDamage && !status.isGrabAttack)
                {
                    timeToRestart += Time.deltaTime;
                }
                yield return null;
            }
            if (status.gameManager.canFight && !status.isTakingDamage)
            {
                #region Movement
                Vector3 directionToOpponent = status.opponent.transform.position - transform.position;
                Vector3 movement = -directionToOpponent.normalized * 1 * Time.deltaTime * 1f;
                directionToOpponent.y = 0;
                float distancia = Vector3.Distance(transform.position, status.opponent.transform.position);
                float forwardDirection = Mathf.Sign(transform.forward.x);
                status.shouldMirror = directionToOpponent.x < 0;
                Vector3 velocity = new Vector3(1 * 2, 0f, 0f);
                if (!status.shouldMirror)
                {
                    LookAtOpponent();
                    while (distancia > 2 && !status.isDefending && !status.isDoingBasicAttack && !status.isDoingCombo && !status.shouldMirror && !status.isTakingDamage && !status.rootMotion)
                    {
                        directionToOpponent = status.opponent.transform.position - transform.position;
                        directionToOpponent.y = 0;

                        distancia = Vector3.Distance(transform.position, status.opponent.transform.position);

                        rb.velocity = velocity;
                        status.horizontalSpeed = Mathf.Lerp(status.horizontalSpeed, 1 * forwardDirection, Time.deltaTime * 10f);
                        yield return null;
                    }
                }
                else if (status.shouldMirror)
                {
                    LookAtOpponent();
                    while (distancia > 2 && !status.isDefending && !status.isDoingBasicAttack && !status.isDoingCombo && status.shouldMirror && !status.isTakingDamage && !status.rootMotion)
                    {
                        directionToOpponent = status.opponent.transform.position - transform.position;
                        directionToOpponent.y = 0;

                        distancia = Vector3.Distance(transform.position, status.opponent.transform.position);

                        rb.velocity = -velocity;
                        status.horizontalSpeed = Mathf.Lerp(status.horizontalSpeed, -1 * forwardDirection, Time.deltaTime * 10f);
                        yield return null;
                    }
                }
                #endregion
                #region Combat

                int randomValue;
                while (!status.isDoingBasicAttack && !status.isDoingCombo && !status.isTakingDamage && !status.isDefending && !status.isGrabAttack)
                {
                    distancia = Vector3.Distance(transform.position, status.opponent.transform.position);
                    if (distancia >= 1)
                    {
                        if (comboList.ComboForIA(out string comboName))
                        {
                            anim.CrossFade(comboName, 0.1f);
                        }
                    }
                    else
                    {
                        randomValue = Random.Range(0, 6);
                        switch (randomValue)
                        {
                            case 1:
                                anim.CrossFade("SocoAlto", 0.1f);
                                break;
                            case 2:
                                anim.CrossFade("SocoBaixo", 0.1f);
                                break;
                            case 3:
                                anim.CrossFade("ChuteAlto", 0.1f);
                                break;
                            case 4:
                                anim.CrossFade("ChuteBaixo", 0.1f);
                                break;
                            default:
                                anim.CrossFade("Agarrar", 0.1f);
                                break;
                        }
                    }
                    yield return null;
                }
                #endregion
            }
            yield return null;
        }
    }
    public void LookAtOpponent()
    {
        Vector3 directionToOpponent = status.opponent.transform.position - transform.position;
        directionToOpponent.y = 0;
        if (directionToOpponent != Vector3.zero)
        {
            status.shouldMirror = directionToOpponent.x < 0;
            if (!status.shouldMirror)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
    }
}
