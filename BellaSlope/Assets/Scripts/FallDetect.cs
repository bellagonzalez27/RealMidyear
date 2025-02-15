using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fall : MonoBehaviour
{
    private GameObject player;
    private int platformsTouching = 0; // Count of platforms the player is touching
    private bool resetTriggered = false;
    private float resetDelay = 3f; // Time to wait before resetting the game
    private float checkTime = 0f; // Timer to track if the player is not touching any platform
    private float maxCheckTime = 3f; // Max time before reset

    void Start()
    {
        player = GameObject.Find("Sphere");

        if (player == null)
        {
            Debug.LogError("Error: GameObject 'Sphere' not found! Ensure it exists in the scene.");
        }
    }

    void Update()
    {
        // If the player is not touching any platform, start counting time
        if (platformsTouching == 0)
        {
            checkTime += Time.deltaTime;
        }
        else
        {
            checkTime = 0f; // Reset the timer if player touches a platform
        }

        // If no platform is touched for more than 'maxCheckTime' seconds, trigger reset
        if (checkTime >= maxCheckTime && !resetTriggered)
        {
            resetTriggered = true;
            StartCoroutine(ResetGameWithDelay());
        }
    }

    // Detect when player is still touching any platform (Platform to Platform 7)
    private void OnCollisionStay(Collision collision)
    {
        if (IsPlatform(collision.gameObject.name))
        {
            platformsTouching++; // Increase the count of platforms being touched
            resetTriggered = false; // Cancel reset if touching a platform
        }
    }

    // Detect when player stops touching a platform
    private void OnCollisionExit(Collision collision)
    {
        if (IsPlatform(collision.gameObject.name))
        {
            platformsTouching--; // Decrease platform count
            if (platformsTouching < 0)
            {
                platformsTouching = 0; // Prevent negative count
            }
        }
    }

    // Helper method to check if the object is a platform (Platform, Platform 2, Platform 3, etc.)
    private bool IsPlatform(string objectName)
    {
        return objectName.StartsWith("Platform"); // Checks if the object name starts with "Platform"
    }

    // Wait before resetting the game
    private IEnumerator ResetGameWithDelay()
    {
        yield return new WaitForSeconds(resetDelay); // Wait before resetting the game
        if (platformsTouching == 0) // Double-check to see if still not touching any platform
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reset the scene
        }
    }
}