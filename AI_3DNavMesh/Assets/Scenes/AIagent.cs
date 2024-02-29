using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIagent : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    public Transform target;
    
    void Start()
    {
        agent.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if (agent.remainingDistance > 2)
        {

        }

        // Quit game after building
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
