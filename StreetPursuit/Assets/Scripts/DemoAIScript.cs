using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemoAIScript : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    private Boolean isFaster = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        if (DemoNPCScript.hasLeveledUp)//change for in script timer instead of reliance on npcscript?
        {
            if (!isFaster)
            {
                //agent.velocity *= 1.5f;
                agent.speed *= 2;
                isFaster = true;
            }
        }
    }
}
