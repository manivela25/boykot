using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    Rigidbody pyhsic;
    public int Speed;
    void Start()
    {
        pyhsic = GetComponent<Rigidbody>();

        pyhsic.angularVelocity = Random.insideUnitSphere*Speed;
    }

}
