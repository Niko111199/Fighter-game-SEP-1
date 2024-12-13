using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Threading;
using Unity.Collections;
using Unity.VisualScripting;
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
    private InputAction blockAction;
    private Rigidbody rb;
    private bool isGrounded;
    public bool GetIsGrunded()
    {
        return isGrounded;
    }

    [SerializeField] AttackScript attack;
    [SerializeField] Detectionscript leftarm;
    [SerializeField] Detectionscript rightarm;
    [SerializeField] Detectionscript leftleg;
    [SerializeField] Detectionscript rightleg;

    private bool isBlocking;
    public bool GetIsBlocking()
    {
        return isBlocking;
    }

    private bool isJumping;
    public bool GetIsJumping()
    {
        return isJumping;
    }

    private void Awake()
    {
        forwardAction = actions.FindActionMap(player).FindAction("Walk");
        jumpAction = actions.FindActionMap(player).FindAction("Jump");
        blockAction = actions.FindActionMap(player).FindAction("block");

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        float forward = forwardAction.ReadValue<float>();

        if (attack.isAttacking == false && isBlocking == false)
        {
            
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
                isJumping = true;
            }
            else
            {
                isJumping = false;
            }
        }

        if (attack.isAttacking == false)
        {
            if (blockAction.IsPressed())
            {
                animator.SetBool("Block", true);
                isBlocking = true;
                leftarm.SetDamage(0.5f);
                rightarm.SetDamage(0.5f);
                leftleg.SetDamage(0.5f);
                rightleg.SetDamage(0.5f);
            }
            else
            {
                animator.SetBool("Block", false);
                isBlocking = false;
                leftarm.SetDamage(2);
                rightarm.SetDamage(2);
                leftleg.SetDamage(2);
                rightleg.SetDamage(2);
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
        blockAction.Enable();
    }

    private void OnDisable()
    {
        forwardAction.Disable();
        jumpAction.Disable();
        blockAction.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGrounded = true;
        }
    }
}

