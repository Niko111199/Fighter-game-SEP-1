using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Detectionscript : MonoBehaviour
{
    public LayerMask colloisonLayer;
    [SerializeField] private float radius = 1f;
    [SerializeField] private float damage;
    [SerializeField] private Animator Enemy;

    public SoundManager soundManager;
    private List<AudioType> hitAudioTypes;

    public bool ishitting;

    [SerializeField] GameObject hit_VFX;

    private void Start()
    {
        if (soundManager == null)
        {
            soundManager = SoundManager.instance;
            if (soundManager == null)
            {
                Console.WriteLine("Something bad happened, DetectionScript");
            }
        }

        hitAudioTypes = new List<AudioType>();

        //Literally for doven til at lave en manuel liste xD i scriptet. Skal dog laves manuelt på SoundManageren, og den kan være finicky, fordi nye elementer ovenover andre eksisterende elementer flytter alle andre elementer længere ned.

        foreach (AudioType type in Enum.GetValues(typeof(AudioType)))
            if (type.ToString().Contains("SFX_Big_Hit") || type.ToString().Contains("SFX_Small_Hit"))
                hitAudioTypes.Add(type);
    }
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
            soundManager.PlayAudio(GetRandomHitAudio());

        }
    }

    private AudioType GetRandomHitAudio()
    {
        //Vi vil have Index, så inklusiv 0 og ekslusiv Count virker.
        int rngIndex = UnityEngine.Random.Range(0, hitAudioTypes.Count);
        return hitAudioTypes[rngIndex];
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
