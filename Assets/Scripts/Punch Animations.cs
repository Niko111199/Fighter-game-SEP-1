using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAnimations : MonoBehaviour
{
    private Animator animaton;

    private void Awake()
    {
         animaton = GetComponent<Animator>();
    }

    public void puch1()
    {
        animaton.SetTrigger("Punch 1");
    }

    public void puch2()
    {
        animaton.SetTrigger("Punch 2");
    }

    public void puch3()
    {
        animaton.SetTrigger("Punch 3");
    }

    public void kick1()
    {
        animaton.SetTrigger("Kick 1");
    }

    public void kick2()
    {
        animaton.SetTrigger("Kick 2");
    }
}
