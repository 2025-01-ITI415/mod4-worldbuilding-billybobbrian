using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public int totalCollectibles = 3; // Set this to however many are in your scene
    private int collected = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectable"))
        {
            collected++;
            Destroy(other.gameObject); // Remove the collected item
            Debug.Log("Collected: " + collected);

            if (collected >= totalCollectibles)
            {
                WinGame();
            }
        }
    }

    void WinGame()
    {
        Debug.Log("You collected all items! You win!");
        // Add more win logic here like a UI panel or scene transition
    }
}

