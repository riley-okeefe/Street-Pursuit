using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    public List<GameObject> prefabList; // List of prefabs
    public Camera mainCamera; // Camera
    public float distance = 175f; // Adjust distance from camera
    public float heightOffset = -250f; // Adjust location of prefab height-wise
    public float rotationSpeed = 100f; // Adjust prefab rotation speed
    public GameObject spawnedPrefab; // Spawned prefab
    private GameObject originalPrefab; // Prefab to be cloned

    void Start()
    {
        // Check to make sure prefab list and camera are assigned in unity
        if (prefabList.Count == 0 || mainCamera == null)
        {
            Debug.LogError("Prefab list or camera not assigned!");
            return;
        }      
        // Instantiate the first prefab in the list in front of the camera
        SpawnPrefab();

        PlayerPrefs.SetString("SelectedCar", "Car1");
    }

    void Update()
    {
        // Check for user input to rotate prefab left or right
        float rotationInput = Input.GetAxis("Horizontal");
        RotatePrefab(rotationInput);
    }

    // Function to cycle through prefabs
    public void CyclePrefab(int direction)
    {
        // Ensure there is at least one prefab in the list
        if (prefabList.Count == 0)
            return;

        // Destroy the current spawned prefab
        Destroy(spawnedPrefab);

        // Find the index of the current original prefab in the list
        int currentIndex = prefabList.IndexOf(originalPrefab);

        // Make the previous original prefab visible
        SetPrefabVisibility(originalPrefab, true);

        // Calculate the next index, considering the direction
        int nextIndex = (currentIndex + direction + prefabList.Count) % prefabList.Count;

        // Set the next original prefab from the list
        originalPrefab = prefabList[nextIndex];

        // Instantiate the new prefab
        spawnedPrefab = Instantiate(originalPrefab);

        PlayerPrefs.SetString("SelectedCar", originalPrefab.name);

        // Make the new original prefab invisible
        SetPrefabVisibility(originalPrefab, false);

        // Calculate the position in front of the camera based on distance and height offset
        Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * distance + Vector3.up * heightOffset;

        // Set the position of the spawned prefab
        spawnedPrefab.transform.position = spawnPosition;

        if (originalPrefab == prefabList[1])
        {
            // Modify the Y-axis of the yellow car
            spawnedPrefab.transform.position += Vector3.up * -13;
        }
    }

    // Function to rotate the selected prefab
    void RotatePrefab(float rotationInput)
    {
        // Check if spawnedPrefab is not null before rotating
        if (spawnedPrefab != null)
        {
            // Adjust the spawned prefab's rotation based on the input
            spawnedPrefab.transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
        }
    }

    // Function to spawn the first cloned prefab
    void SpawnPrefab()
    {
        // Instantiate the first prefab in the list
        originalPrefab = prefabList[0];
        spawnedPrefab = Instantiate(originalPrefab);

        // Make the original prefab invisible
        SetPrefabVisibility(originalPrefab, false);

        // Calculate the position in front of the camera based on distance and height offset
        Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * distance + Vector3.up * heightOffset;

        // Set the position of the spawned prefab
        spawnedPrefab.transform.position = spawnPosition;
    }

    // Function to hide a prefab
    void SetPrefabVisibility(GameObject prefab, bool isVisible)
    {
        // Get all Renderer components in the prefab
        Renderer[] renderers = prefab.GetComponentsInChildren<Renderer>(true);

        // Iterate through each Renderer in the array
        foreach (Renderer renderer in renderers)
        {
            // Set the current renderers visibility
            renderer.enabled = isVisible;
        }
    }
}









