using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [Header("Animation Settings")]
    public bool shouldRotate = true;
    public float rotationSpeed = 100f;
    public Vector3 rotationAxis = Vector3.up;

    public bool shouldFloat = true;
    public float floatAmplitude = 0.2f;
    public float floatFrequency = 1f;

    private Vector3 startPosition;
    private float timeOffset;

    void Start()
    {
        // Store original position for floating animation
        startPosition = transform.position;

        // Random offset so items don't all float in sync
        timeOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        // Handle rotation
        if (shouldRotate)
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        }

        // Handle floating
        if (shouldFloat)
        {
            float newY = startPosition.y + (Mathf.Sin(Time.time * floatFrequency + timeOffset) * floatAmplitude);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}