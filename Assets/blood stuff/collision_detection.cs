using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_detection : MonoBehaviour
{
    public Rigidbody rb;
    public ParticleSystem bloodVFX;
    public GameObject stainPrefab;
    public GameObject Floor;
    public List<ParticleCollisionEvent> collisionEvents;
    private void OnCollisionEnter(Collision collision)
    {
       
        if (bloodVFX != null)
        {
            bloodVFX.transform.position = collision.contacts[0].point; 
            bloodVFX.Play(); 
        }


    }
    //private static int GetCollisionEvents(ParticleSystem bloodVFX, GameObject Floor)
    //{
    //    int ParticleCollisions = 0;
    //    for (int i = 0; )
    //    {

    //    }
    //    for (int i = 0; i < ParticleCollisions; i++)
    //    {

    //    }
    //}
    private void OnParticleCollision(GameObject other)
    {

        if (stainPrefab != null && bloodVFX != null)
        {

            Instantiate(stainPrefab);
        }
    }
}
