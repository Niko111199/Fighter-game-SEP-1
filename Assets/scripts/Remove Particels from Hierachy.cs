using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveParticelsfromHierachy : MonoBehaviour
{
    public float time = 2f;

    private void Start()
    {
        Invoke("doDestroy", time);
    }

    private void doDestroy()
    {
        Destroy(gameObject);
    }
}
