using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoNPCScript : MonoBehaviour
{
    private float startTime;
    public GameObject npc;
    public static Boolean hasLeveledUp = false; // consider having ai script deal with it or something else

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLeveledUp)
        {
            // After 15 seconds the NPC levels up
            if (Time.time - startTime > 15)
            {
                hasLeveledUp = true;
                Debug.Log("15 seconds have passed");
                //npc.transform.GetComponent<Renderer>().material.color = Color.black;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Boolean isOnCooldown = DemoDmgCDScript.IsOnCooldown();
        if (!isOnCooldown)
        {
            DemoPlayerScript.playerHealth -= 5;
            if (DemoPlayerScript.playerHealth <= 0) DemoPlayerScript.isAlive = false;
        }
    }
}
