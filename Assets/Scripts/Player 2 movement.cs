using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 3f;

    private InputAction forwardAction;
    private InputAction jumpAction;
    private Rigidbody rb;
    private bool isGrounded;

    private void Awake()
    {
        forwardAction = actions.FindActionMap("Player 2").FindAction("Walk");
        jumpAction = actions.FindActionMap("Player 2").FindAction("Jump");

        // Add a Rigidbody if not present
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
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetTrigger("Jump");
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
        if (collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }
}
