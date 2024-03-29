using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] carPrefabs; // Array to store references to car prefabs
    [SerializeField] Vector3 spawnPosition;
    public GameObject spawnedCar;
    public CameraScript mainCamera; // Renamed from 'camera'

    // Start is called before the first frame update
    void Start()
    {
        SpawnCar(spawnPosition);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnCar(Vector3 position)
    {
        string spawnedCarName = PlayerPrefs.GetString("SelectedCar");
        Debug.Log("Retrieved car: " + spawnedCarName);

        // Find the correct prefab based on the name
        foreach (GameObject carPrefab in carPrefabs)
        {
            if (carPrefab.name == spawnedCarName)
            {
                spawnedCar = Instantiate(carPrefab, position, Quaternion.identity);
                Debug.Log("Spawned car: " + spawnedCar);
                return;
            }
        }

        // If the correct prefab is not found
        Debug.LogError("Failed to find car prefab: " + spawnedCarName);
    }
}


