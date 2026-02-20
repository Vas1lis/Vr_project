using UnityEngine;

public class HoldPointSway : MonoBehaviour
{
    public float swayAmount = 0.03f;
    public float swaySpeed = 6f;

    Vector3 startLocalPos;

    void Start()
    {
        startLocalPos = transform.localPosition;
    }

    void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        Vector3 target = startLocalPos + new Vector3(-mx, -my, 0f) * swayAmount;
        transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * swaySpeed);
    }
}