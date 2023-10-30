using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("HideInInspector")]
    [HideInInspector] PlayerControls playerControls;
    [HideInInspector] private Status status;
    [HideInInspector] private Rigidbody rb;
    [HideInInspector] private Animator anim;

    [Header("Movement")] 
    [HideInInspector] public Vector2 moveDirection;

    [Header("Combo")]
    [SerializeField] private List<string> comboInputs = new List<string>();
    [SerializeField] private ComboList comboList;
    [SerializeField] private float timeToResetCombo;

    private void OnEnable()
    {
        comboList = GetComponent<ComboList>();
        status = GetComponent<Status>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        playerControls = new PlayerControls();
        playerControls.Enable();
    }
    private void CheckComboInput()
    {
        if (playerControls.Combat.Bloqueio.ReadValue<float>() > 0 && !status.isDoingBasicAttack)
        {
            anim.SetBool("isDefending", true);
        }
        else
        {
            anim.SetBool("isDefending", false);
        }

        #region Timer Combos
        if (timeToResetCombo <= 0)
        {
            if (comboInputs.Count > 0)
            {
                comboInputs.Clear();
            }
            timeToResetCombo = 0;
        }
        else
        {
            timeToResetCombo -= Time.deltaTime;
        }
        if (comboInputs.Count > 3)
        {
            comboInputs.Clear();
        }
        #endregion
        #region Input Combos
        if (status.isGrabAttack)
            return;

        if (status.isTakingDamage)
            return;

        if (status.isDoingCombo)
            return;

        if (playerControls.Combat.Agarrar.triggered && !status.isDoingBasicAttack )
        {
            anim.CrossFade("Agarrar", 0.1f);
            comboInputs.Clear();
        }
        if (playerControls.Combat.SocoAlto.triggered)
        {
            comboInputs.Add("SocoAlto");
            timeToResetCombo = 0.25f;

            if (comboList.IsComboValid(comboInputs, out string comboName))
            {
                anim.CrossFade(comboName, 0.1f);
                comboInputs.Clear();
            }
            else if (!status.isDoingBasicAttack)
            {
                anim.CrossFade("SocoAlto", 0.1f);
            }
        }
        if (playerControls.Combat.SocoBaixo.triggered)
        {
            comboInputs.Add("SocoBaixo");
            timeToResetCombo = 0.25f;

            if (comboList.IsComboValid(comboInputs, out string comboName))
            {
                anim.CrossFade(comboName, 0.1f);
            }
            else if (!status.isDoingBasicAttack)
            {
                anim.CrossFade("SocoBaixo", 0.1f);
            }
        }
        if (playerControls.Combat.ChuteAlto.triggered)
        {
            comboInputs.Add("ChuteAlto");
            timeToResetCombo = 0.25f;

            if (comboList.IsComboValid(comboInputs, out string comboName))
            {   
                anim.CrossFade(comboName, 0.1f);
            }
            else if (!status.isDoingBasicAttack)
            {
                anim.CrossFade("ChuteAlto", 0.1f); 
            }
        }
        if (playerControls.Combat.ChuteBaixo.triggered) 
        {
            comboInputs.Add("ChuteBaixo");
            timeToResetCombo = 0.25f;

            if (comboList.IsComboValid(comboInputs, out string comboName))
            {
                anim.CrossFade(comboName, 0.1f);
            }
            else if(!status.isDoingBasicAttack)
            {
                anim.CrossFade("ChuteBaixo", 0.1f);
            }
        }

        if (playerControls.Combat.Cima.triggered)
        {
            comboInputs.Add("Cima");
            timeToResetCombo = 0.25f;

            if (comboList.IsComboValid(comboInputs, out string comboName))
            {
                anim.CrossFade(comboName, 0.1f);
            }
        }
        if (playerControls.Combat.Baixo.triggered)
        {
            comboInputs.Add("Baixo");
            timeToResetCombo = 0.25f;

            if (comboList.IsComboValid(comboInputs, out string comboName))
            {
                anim.CrossFade(comboName, 0.1f);
            }
        }
        if (playerControls.Combat.Esquerda.triggered)
        {
            comboInputs.Add("Esquerda");
            timeToResetCombo = 0.25f;

            if (comboList.IsComboValid(comboInputs, out string comboName))
            {
                anim.CrossFade(comboName, 0.1f);
            }
        }
        if (playerControls.Combat.Direita.triggered)
        {
            comboInputs.Add("Direita");
            timeToResetCombo = 0.25f;

            if (comboList.IsComboValid(comboInputs, out string comboName))
            {
                anim.CrossFade(comboName, 0.1f);
            }
        }
        #endregion
    }
    private void FixedUpdate()
    {
        MovementManager();
        RotateToTarget();
    }
    void Update()
    {
        if (!status.gameManager.canFight)
            return;

        if (status.isDead)
            return;

        if (status.isTakingDamage)
            return;

        CheckComboInput();

    }
    private void MovementManager()
    {

        moveDirection = new Vector3(playerControls.Player.Movement.ReadValue<Vector2>().x, 0f);
        moveDirection.Normalize();

        Vector3 velocity;

        if (!status.isTakingDamage && status.gameManager.canFight && !status.isDoingBasicAttack && !status.isDoingCombo && !status.isDead)
        {
            velocity = new Vector3(moveDirection.x * 2, 0f, 0f);
        }
        else
        {
            velocity = new Vector3(0, 0f, 0f);
        }
        if (!status.rootMotion && !status.isDefending) 
            rb.velocity = velocity;

        #region Animation

        float inputX;
        float forwardDirectionX = Mathf.Sign(transform.forward.x);
        inputX = playerControls.Player.Movement.ReadValue<Vector2>().x;

        if (!status.isTakingDamage && status.gameManager.canFight && !status.isDoingBasicAttack && !status.isDoingCombo && !status.isDead)
            status.horizontalSpeed = Mathf.Lerp(status.horizontalSpeed, inputX * forwardDirectionX, Time.deltaTime * 20f);
        else
            status.horizontalSpeed = Mathf.Lerp(status.horizontalSpeed, 0, Time.deltaTime * 25f);

        anim.SetFloat("Horizontal", status.horizontalSpeed);


        float inputY;
        float forwardDirectionY = Mathf.Sign(transform.forward.y);
        inputY = playerControls.Player.Movement.ReadValue<Vector2>().y;

        if (!status.isTakingDamage && status.gameManager.canFight && !status.isDoingBasicAttack && !status.isDoingCombo && !status.isDead)
            status.verticalSpeed = Mathf.Lerp(status.verticalSpeed, inputY * forwardDirectionY, Time.deltaTime * 20f);
        else
            status.verticalSpeed = Mathf.Lerp(status.verticalSpeed, 0, Time.deltaTime * 25f);

        anim.SetFloat("Vertical", status.verticalSpeed);
        #endregion
    }
    private void RotateToTarget()
    {
        if (status.opponent.transform == null)
            return;

        if (status.isDead)
            return;


        Vector3 directionToOpponent = status.opponent.transform.position - transform.position;
        directionToOpponent.y = 0;
        if (directionToOpponent != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToOpponent);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            #region Animation
            bool shouldMirror = directionToOpponent.x < 0;
            anim.SetBool("Mirror", shouldMirror);
            #endregion
        }
    }
}


