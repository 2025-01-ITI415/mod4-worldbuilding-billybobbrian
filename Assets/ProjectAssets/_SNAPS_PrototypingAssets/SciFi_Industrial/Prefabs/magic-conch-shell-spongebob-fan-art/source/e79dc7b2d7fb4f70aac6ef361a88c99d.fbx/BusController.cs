using UnityEngine;

public class BusController : MonoBehaviour
{
    public ItemCollectorUI uiManager;
    public GameObject busObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && uiManager.allItemsCollected)
        {
            Debug.Log("Player reached the bus! Game won!");
            uiManager.ShowWinScreen();
        }
    }
}