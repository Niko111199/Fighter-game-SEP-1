using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    private float offsetx, offsetz;
    void Start()
    {
        transform.LookAt(target);
        offsetx = transform.position.x - target.position.x;
        offsetz = transform.position.z - target.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        //distance = Mathf.Lerp(transform.position.z, target.position.z, 1 * Time.deltaTime);
        transform.position = new Vector3(target.position.x + offsetx,transform.position.y, target.position.z + offsetz); 
    }
}
