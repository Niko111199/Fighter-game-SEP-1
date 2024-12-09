using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
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
    }

    private void OnEnable()
    {
        forwardAction.Enable();
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        forwardAction.Disable();
        jumpAction.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

