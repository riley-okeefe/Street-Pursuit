using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPit : MonoBehaviour
{
    // if the players car enters the rock pit reset the car back to the starting position
    public Vector3 startPos = new Vector3(139.300003f, 0.665000021f, 10.0579996f);
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            other.transform.parent.position = startPos;
            other.transform.parent.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
