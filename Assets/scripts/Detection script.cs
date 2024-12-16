using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Detectionscript : MonoBehaviour
{
    public LayerMask colloisonLayer;
    [SerializeField] private float radius = 1f;
    [SerializeField] private float damage = 2f;
    [SerializeField] private Animator Enemy;

    public bool ishitting;

    [SerializeField] GameObject hit_VFX;


    void Update()
    {
        DetectCollision();
    }

   public void DetectCollision()
   {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius,colloisonLayer);

        if (hit.Length > 0)
        {
            print("hit on " + hit[0].gameObject.name);

            Health health = hit[0].GetComponent<Health>();

            if (health != null)
            {
                health.DealDamage(damage);
            }

            gameObject.SetActive(false);

            Enemy.SetTrigger("Taking Damage");

            ishitting = true;
        }
        else
        {
            ishitting = false;
        }

        if (ishitting)
        {
            Vector3 hitVFX = hit[0].transform.position;
            hitVFX.y += 1f;

            if (hit[0].transform.forward.x > 0)
            {
                hitVFX.x -= 0.3f;
            }
            else if (hit[0].transform.forward.x < 0)
            {
                hitVFX.x += 0.3f;
            }

            Instantiate(hit_VFX,hitVFX,Quaternion.identity);
            //Går ud fra det er her vi skal have vores hit sfx?

        }
    }

    

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
