using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBox : MonoBehaviour
{
    public Rigidbody Box;
    public GameObject Boxthing;
    public float speed;
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0, 0, 1*speed));
    }
}
