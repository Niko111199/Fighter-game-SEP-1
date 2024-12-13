using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private string player;
    public enum Combo { NONE, punch1, punch2, punch3, kick1, kick2 };
    private bool ResetTimer;
    private float defualtComboTimer = 0.8f;
    private float currentComobTimer;
    [SerializeField] private Animator animator;
    private Combo CurrentCombo;

    public Combo GetCurrentCombo()
    {
        return CurrentCombo;
    }

    private InputAction punch;
    private InputAction kick;

    public bool isAttacking;
    [SerializeField] float DelayBeforeMoving;


    private void Start()
    {
        currentComobTimer = defualtComboTimer;
        CurrentCombo = Combo.NONE;
    }

    private void Awake()
    {
        punch = actions.FindActionMap(player).FindAction("Punch");
        kick = actions.FindActionMap(player).FindAction("Kick");
    }

    void comboattcks()
    {
        if (punch.triggered)
        {
            if (CurrentCombo == Combo.punch3 || CurrentCombo == Combo.kick1 || CurrentCombo == Combo.kick2)
            {
                return;
            }

            CurrentCombo++;
            ResetTimer = true;
            currentComobTimer = defualtComboTimer;

            if (CurrentCombo == Combo.punch1)
            {
                animator.SetTrigger("Punch 1");
                isAttacking = true;
            }

            if (CurrentCombo == Combo.punch2)
            {
                animator.SetTrigger("Punch 2");
                isAttacking = true;
            }

            if (CurrentCombo == Combo.punch3)
            {
                animator.SetTrigger("Punch 3");
                isAttacking = true;
            }
        }

        if (kick.triggered)
        {
            if (CurrentCombo == Combo.kick2 || CurrentCombo == Combo.punch3)
            {
                return;
            }

            if (CurrentCombo == Combo.NONE || CurrentCombo == Combo.punch1 || CurrentCombo == Combo.punch2)
            {
                CurrentCombo = Combo.kick1;
            }
            else if (CurrentCombo == Combo.kick1)
            {
                CurrentCombo++;
            }

            ResetTimer = true;
            currentComobTimer = defualtComboTimer;

            if (CurrentCombo == Combo.kick1)
            {
                animator.SetTrigger("Kick 1");
                isAttacking = true;
            }

            if (CurrentCombo == Combo.kick2)
            {
                animator.SetTrigger("Kick 2");
                isAttacking = true;
            }

        }
    }

    void resetCombo()
    {
        if (ResetTimer)
        {
            currentComobTimer -= Time.deltaTime;

            if (currentComobTimer <= 0f)
            {
                CurrentCombo = Combo.NONE;

                ResetTimer = false;
                currentComobTimer = defualtComboTimer;

                StartCoroutine(ResetIsAttackingAfterDelay(DelayBeforeMoving));
            }
        }
    }

    private void OnEnable()
    {
        kick.Enable();
        punch.Enable();
    }

    private void OnDisable()
    {
        kick.Disable();
        punch.Enable();
    }

    void Update()
    {
        comboattcks();
        resetCombo();
    }

    private IEnumerator ResetIsAttackingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        isAttacking = false;
    }
}
