using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private LayerMask attackLayer;
    [SerializeField] private float radius = 1f;
    [SerializeField] private float damage = 2f;
    private bool haveAttacked;


    // Update is called once per frame
    void Update()
    {
        if (!haveAttacked)
        {
            detectcoillision();
        }
    }

    void detectcoillision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, attackLayer);

        if (haveAttacked == false)
        {
            if (hit.Length > 0)
            {
                print("hit made");
                haveAttacked = true;
            }
        }
        
    }

    
}

