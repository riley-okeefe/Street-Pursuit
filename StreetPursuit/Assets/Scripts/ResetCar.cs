using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResetCar : MonoBehaviour
{
    public Vector3 startPos = new Vector3(294.895996f, 0.366578549f, 285.478149f);
    

    // Update is called once per frame
    void Update()
    {
        if (!DemoPlayerScript.isAlive)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //Reset car to start position
            gameObject.transform.position = startPos;
            //make sure car is right side up
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            //reset the velocity
            gameObject.GetComponentInChildren<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;

        }
    }
}
