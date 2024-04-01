using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioSource collisionSound; // Reference to the AudioSource component for the collision sound effect


    private void OnCollisionEnter(Collision collision)
    {
        collisionSound.Play();       
    }
}

