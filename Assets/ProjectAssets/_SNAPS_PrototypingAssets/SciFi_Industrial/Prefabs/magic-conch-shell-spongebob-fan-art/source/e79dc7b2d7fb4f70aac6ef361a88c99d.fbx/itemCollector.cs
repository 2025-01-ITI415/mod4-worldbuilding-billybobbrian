using UnityEngine;
public class ItemCollector : MonoBehaviour
{
    public ItemCollectorUI uiManager;
    private float lastCollectTime = 0f;
    private float collectCooldown = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectable"))
        {
            // Prevent rapid successive collections (fixes double-counting)
            if (Time.time - lastCollectTime < collectCooldown)
                return;

            lastCollectTime = Time.time;

            uiManager.AddItem();
            Destroy(other.gameObject);
        }
    }
}