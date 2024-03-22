using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayerScript : MonoBehaviour
{
    public GameObject playerObj, experienceOrb, xpInstance1, xpInstance2, xpInstance3, xpInstance4;
    private int experiencePoints = 0;
    public static int playerHealth;
    public static float dmgCooldown;
    public static Boolean isAlive = true;
    //private float playerSpeed = 5f;
    //private float turnSpeed = 100f;
    //private Vector3 movement, movementRotation;
    private Vector3 xpScale = new Vector3(0.25f, 0.25f, 0.25f);
    private CarControl carControl;

    // Start is called before the first frame update
    void Start()
    {
        // Set player health
        playerHealth = 100;

        // Instantiate experience orbs
        xpInstance1 = Instantiate(experienceOrb);
        xpInstance1.transform.position = new Vector3(131.778564f, 0.560000002f, 305.23999f);
        xpInstance1.transform.localScale = xpScale;
        xpInstance2 = Instantiate(experienceOrb);
        xpInstance2.transform.position = new Vector3(131.778564f, 0.560000002f, 297.970001f);
        xpInstance2.transform.localScale = xpScale;
        xpInstance3 = Instantiate(experienceOrb);
        xpInstance3.transform.position = new Vector3(138.470001f, 0.560000002f, 297.970001f);
        xpInstance3.transform.localScale = xpScale;
        xpInstance4 = Instantiate(experienceOrb);
        xpInstance4.transform.position = new Vector3(138.470001f, 0.560000002f, 306.820007f);
        xpInstance4.transform.localScale = xpScale;

        carControl = playerObj.GetComponent<CarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement controls
        //movement = new Vector3(0, 0, Input.GetAxis("Vertical"));
        // Turn controls
        //movementRotation = new Vector3(0, Input.GetAxis("Horizontal"), 0);

        // If moving forward, rotate player in given direction
        //if (movement.z > 0)
        //{
        //    playerObj.transform.Rotate(movementRotation * turnSpeed * Time.deltaTime);
        //}

        // If moving in backward, reverse rotation
        //if (movement.z < 0)
        //{
        //    movementRotation = -movementRotation;
        //    playerObj.transform.Rotate(movementRotation * turnSpeed * Time.deltaTime);
        //}

        // Move player
        //playerObj.transform.Translate(movement * playerSpeed * Time.deltaTime);

        // Player is dead
        if (!isAlive)
        {
            // Do something
            //Destroy(playerObj);
            Debug.Log("Player Dead!");
            //playerObj.GetComponent<Renderer>().material.color = Color.yellow;
            //playerObj.GetComponent<Renderer>().enabled = false;
        }
        //Debug.Log(experiencePoints);
    }

    private void OnTriggerEnter(Collider other)
    {
        experiencePoints += 50;
        Debug.Log(experiencePoints);

        if (experiencePoints >= 100)
        {
            Debug.Log("Car max speed is now: " + carControl.maxSpeed);
            carControl.maxSpeed += 10;
            //playerSpeed += 5;
            //playerObj.transform.GetComponent<Renderer>().material.color = Color.red;
        }
        // Destroy XP Orb instance
        Destroy(other.gameObject);
    }
}
