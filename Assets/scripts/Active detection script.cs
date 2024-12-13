using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Activedetectionscript : MonoBehaviour
{
    [SerializeField] private GameObject leftArm;
    [SerializeField] private GameObject rightArm;
    [SerializeField] private GameObject leftLeg;
    [SerializeField] private GameObject rightLeg;

    void LeftArmON()
    {
        leftArm.SetActive(true);
    }

    void LeftArmOFF()
    {
        if (leftArm.activeInHierarchy)
        {
            leftArm.SetActive(false);
        }
    }
    void RightArmON()
    {
        rightArm.SetActive(true);
    }

    void RightArmOFF()
    {
        if (rightArm.activeInHierarchy)
        {
            rightArm.SetActive(false);
        }
    }

    void LeftLegOn()
    {
        leftLeg.SetActive(true);
    }

    void LeftLegOff()
    {
        if (leftLeg.activeInHierarchy)
        {
            leftLeg.SetActive(false);
        }
    }

    void RightLegOn()
    {
        rightLeg.SetActive(true);
    }

    void RightLegOff()
    {
        if (rightLeg.activeInHierarchy)
        {
            rightLeg.SetActive(false);
        }
    }

}
