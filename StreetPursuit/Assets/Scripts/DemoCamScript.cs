using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCamScript : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer = 10f,
        heightOffset = 2.5f;

    private void LateUpdate()
    {
        Vector3 targetPosition = player.position - player.forward * distanceFromPlayer;
        targetPosition.y += heightOffset;
        transform.position = targetPosition;
        transform.LookAt(player);
    }
}
