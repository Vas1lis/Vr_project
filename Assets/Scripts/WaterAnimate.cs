using UnityEngine;

public class WaterAnimate : MonoBehaviour
{
    public float speed = 2f;
    public float amount = 0.02f; 

    private Vector3 startPos;

    void Start()
    {
        // Κρατάμε την αρχική θέση του νερού
        startPos = transform.localPosition;
    }

    void Update()
    {
        
        float newY = startPos.y + (Mathf.Sin(Time.time * speed) * amount);
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }
}