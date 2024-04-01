using System.Collections;
using UnityEngine;

public class PoliceSounds : MonoBehaviour
{
    private Transform player; // Reference to the player's transform
    public AudioSource policeCarAudio; // Reference to the AudioSource for the police car sounds
    public GameManager gameManager;
    public float maxVolumeDistance = 100f; // Maximum distance at which the police car sounds are at maximum volume

    private IEnumerator Start()
    {
        // Wait for 1 second before attempting to assign the player reference
        yield return new WaitForSeconds(0.00001f);

        // Attempt to assign the player reference
        AssignPlayerReference();
    }

    private void AssignPlayerReference()
    {
        GameObject spawnedCar = gameManager.spawnedCar;
        if (spawnedCar != null)
        {
            player = spawnedCar.transform;
        }
        else
        {
            Debug.LogError("Failed to assign player reference: spawned car is null.");
        }
    }

    private void Update()
    {
        // Calculate the distance between the police car and the player if the player reference is not null
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            float volume = Mathf.Clamp01(1f - (distanceToPlayer / maxVolumeDistance)); // Inverse Lerp
            policeCarAudio.volume = volume;
        }
    }
}

