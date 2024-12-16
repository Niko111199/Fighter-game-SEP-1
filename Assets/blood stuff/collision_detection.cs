using System;
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

    public SoundManager soundManager;
    private void OnCollisionEnter(Collision collision)
    {
        if (soundManager == null)
        {
            soundManager = SoundManager.instance;
            if (soundManager == null)
            {
                Console.WriteLine("Something bad happened");
            }
        }
       
        if (bloodVFX != null)
        {
            bloodVFX.transform.position = collision.contacts[0].point; 
            bloodVFX.Play();
            soundManager.PlayAudio(AudioType.SFX_02);
        }


    }
    //private static int GetCollisionEvents(ParticleSystem bloodVFX, GameObject Floor)
    //{
    //    int ParticleCollisions = 0;
    //    foreach (ParticleCollisionEvent peepee in collisionEvents)
    //    {

    //    }
        //for (int i = 0; i < ParticleCollisions; i++)
        //{

        //}
    //}
    //private void OnParticleCollision(GameObject other)
    //{

    //    if (stainPrefab != null && bloodVFX != null)
    //    {
                
    //        Instantiate(stainPrefab);
    //    }
    //}
}
