using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Threading;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player1 : MonoBehaviour
{
    [SerializeField] private string player;
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 3f;

    private InputAction forwardAction;
    private InputAction jumpAction;
    private InputAction punch;
    private InputAction kick;
    private Rigidbody rb;
    private bool isGrounded;
    private PunchAnimations fight;

    public enum Combo {none, punch1, punch2, punch3, kick1, kick2};
    private bool ResetTimer;
    private float defualtComboTimer = 0.4f;
    private float currentComobTimer;
    private Combo CurrentCombo;

    private void Start()
    {
        currentComobTimer = defualtComboTimer;
        CurrentCombo = Combo.none;
    }

    private void Awake()
    {
        forwardAction = actions.FindActionMap(player).FindAction("Walk");
        jumpAction = actions.FindActionMap(player).FindAction("Jump");
        punch = actions.FindActionMap(player).FindAction("Punch");
        kick = actions.FindActionMap(player).FindAction("Kick");

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        float forward = forwardAction.ReadValue<float>();
        ResetComboState();
        if (forward != 0)
        {
            float newForward = forward * speed;
            transform.position += (transform.forward * forward) * speed * Time.deltaTime;
        }

        animator.SetFloat("Walk", forward);


        if (jumpAction.triggered && isGrounded)
        {
            animator.SetTrigger("Jump");
            isGrounded = false;
        }

        if (punch.triggered)
        {
            CurrentCombo++;
            ResetTimer = true;
            currentComobTimer = defualtComboTimer;

            if (CurrentCombo == Combo.punch1)
            {
                animator.SetTrigger("Punch 1");
            }

            if (CurrentCombo == Combo.punch2)
            {
                animator.SetTrigger("Punch 2");
            }

            if (CurrentCombo == Combo.punch3)
            {
                animator.SetTrigger("Punch 3");
            }
        }

        if (kick.triggered)
        {
            animator.SetTrigger("Kick 1");
        }
    }

    private void ResetComboState()
    {
        if (ResetTimer)
        {
        currentComobTimer -= Time.deltaTime;

            if (currentComobTimer < 0f)
            {
                CurrentCombo = Combo.none;

                ResetTimer = false;
                currentComobTimer = defualtComboTimer;
            }
        }
    }

    public void performJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnEnable()
    {
        forwardAction.Enable();
        jumpAction.Enable();
        kick.Enable();
        punch.Enable();
    }

    private void OnDisable()
    {
        forwardAction.Disable();
        jumpAction.Disable();
        kick.Disable();
        punch.Enable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            print(isGrounded);
            isGrounded = true;
        }
    }
}

