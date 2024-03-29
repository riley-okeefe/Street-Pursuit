using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameManager gameManager;
    public float distanceFromCar = 10f;
    public float heightOffset = 2.5f;

    private void LateUpdate()
    {
        if (gameManager != null && gameManager.spawnedCar != null)
        {
            GameObject spawnedCar = gameManager.spawnedCar;
            Vector3 targetPosition = spawnedCar.transform.position - spawnedCar.transform.forward * distanceFromCar;
            targetPosition.y += heightOffset;
            transform.position = targetPosition;
            transform.LookAt(spawnedCar.transform);
        }
    }
}

