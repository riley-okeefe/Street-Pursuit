using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayerScript : MonoBehaviour
{
    public GameObject playerObj;
    public static int playerHealth = 100;
    public static float dmgCooldown;
    public static Boolean isAlive = true;
    private CarControl carControl;

    // Start is called before the first frame update
    void Start()
    {
        // Set player health
        playerHealth = 100;
        carControl = playerObj.GetComponent<CarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth == 0)
        {
            isAlive = false;
            Debug.Log("Player is dead.");
        } else
        {
            Debug.Log(playerHealth);
        }
    }

   
}
