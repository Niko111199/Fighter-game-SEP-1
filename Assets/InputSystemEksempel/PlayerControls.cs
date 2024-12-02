using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
public class PlayerControls : MonoBehaviour
{
    [SerializeField]private InputActionAsset actions;  
    
    private InputAction jumpaction;
    private InputAction forwardaction;
    private InputAction turnaction; 
    
    private Rigidbody rb;
    
    private float rotation = 0;
    private float rotationspeed = 20;
    [SerializeField]private float speed = 300;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        jumpaction = actions.FindActionMap("keyboard").FindAction("Jump");
        jumpaction.performed += Jump;
        
        turnaction = actions.FindActionMap("keyboard").FindAction("Turn");
        forwardaction = actions.FindActionMap("keyboard").FindAction("Forward");
        
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        //if(obj.interaction is SlowTapInteraction )
        //{
        print("Jump");
        rb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
        //}

    }


    private void FixedUpdate()
    {
        RotateAndMove();
    }

    private void Update()
    {  
        float forward = forwardaction.ReadValue<float>();
        if (forward != 0)
        {
            float newforward = forward * speed;
            transform.position += (transform.forward * forward) * speed * Time.deltaTime;
        }
        
    }

    private void RotateAndMove()
    {
        float rotation = turnaction.ReadValue<float>();
        //print("rotation: " + rotation);
        if (rotation != 0)
        {
            float newtransform = rotation * rotationspeed * Time.deltaTime;
            //print("rotate: " + newtransform + " rotation: " + rotation + " speed:  " + speed);
            rb.AddTorque(new Vector3(0, newtransform, 0));
        }


    }



    private void OnEnable()
    {
        jumpaction.Enable();
        turnaction.Enable();
        forwardaction.Enable();
    }

    private void OnDisable()
    {
        jumpaction.Disable();
        turnaction.Disable();
        forwardaction.Disable();
    }
}
