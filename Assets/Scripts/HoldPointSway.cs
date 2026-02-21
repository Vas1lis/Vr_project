using UnityEngine;

public class HoldPointSway : MonoBehaviour
{
    public float swayAmount = 0.03f; // πόσο κουνιέται
    public float swaySpeed = 6f; // πόσο γρήγορα ακολουθεί

    Vector3 startLocalPos; // αρχική θέση

    void Start()
    {
        startLocalPos = transform.localPosition; // αποθηκεύουμε την αρχική θέση
    }

    void Update()
    {
        float mx = Input.GetAxis("Mouse X"); // κίνηση ποντικιού Χ
        float my = Input.GetAxis("Mouse Y"); // κίνηση ποντικιού Υ

        Vector3 target = startLocalPos + new Vector3(-mx, -my, 0f) * swayAmount;

        // ομαλή μετακίνηση προς τον στόχο
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            target,
            Time.deltaTime * swaySpeed
        );
    }
}