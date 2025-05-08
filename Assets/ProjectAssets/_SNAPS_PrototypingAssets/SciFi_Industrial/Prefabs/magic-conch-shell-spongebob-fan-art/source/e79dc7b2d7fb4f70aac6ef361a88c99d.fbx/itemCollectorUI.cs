using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Required for restarting scene

public class ItemCollectorUI : MonoBehaviour
{
    public TextMeshProUGUI itemCounterText;   // Assign your UI Text in the Inspector
    public GameObject winPanel;               // Assign your Win Panel (with Restart button)
    public int winItemCount = 3;              // Total items needed to win
    public GameObject busPrefab;              // Reference to the bus prefab
    public Transform busSpawnPoint;           // Reference to where the bus will spawn

    private int collectedCount = 0;
    private GameObject spawnedBus;
    public bool allItemsCollected = false;

    private void Start()
    {
        // Hide the win panel at start
        if (winPanel != null)
            winPanel.SetActive(false);
        else
            Debug.LogError("Win Panel is not assigned in ItemCollectorUI!");

        UpdateUIText();
    }

    public void AddItem()
    {
        collectedCount++;
        UpdateUIText();

        if (collectedCount >= winItemCount)
        {
            allItemsCollected = true;
            SpawnBus();  // Bus appears now
        }
    }

    private void UpdateUIText()
    {
        if (itemCounterText != null)
            itemCounterText.text = "Items Collected: " + collectedCount + "/" + winItemCount;
    }

    public void ShowWinScreen()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);

            // Optional: Stop time or player movement here if you want
            // Time.timeScale = 0f;
        }
    }

    // 🆕 Restart function to hook to UI Button
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Method to spawn the bus
    private void SpawnBus()
    {
        Debug.Log("SpawnBus method called - attempting to spawn imported bus model");

        if (busPrefab == null)
        {
            Debug.LogError("Bus Prefab is not assigned! Assign the bus model in the Inspector.");
            return;
        }

        if (busSpawnPoint == null)
        {
            Debug.LogWarning("Bus Spawn Point not found - creating one at (0,0,0). Please adjust this manually!");
            GameObject newSpawnPoint = new GameObject("BusSpawnPoint");
            busSpawnPoint = newSpawnPoint.transform;
        }

        try
        {
            spawnedBus = Instantiate(busPrefab, busSpawnPoint.position, busSpawnPoint.rotation);
            Debug.Log("Bus instantiated successfully.");

            // Create trigger collider as separate object
            GameObject busTrigger = new GameObject("BusTrigger");
            busTrigger.transform.position = busSpawnPoint.position;

            BoxCollider triggerCollider = busTrigger.AddComponent<BoxCollider>();
            triggerCollider.isTrigger = true;
            triggerCollider.size = new Vector3(7f, 4f, 12f);
            triggerCollider.center = new Vector3(0, 1.5f, 0);

            // Attach BusController and connect references
            BusController controller = busTrigger.AddComponent<BusController>();
            controller.uiManager = this;
            controller.busObject = spawnedBus;

            Debug.Log("Bus trigger created and BusController set.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error spawning bus: " + e.Message);
        }
    }
}
