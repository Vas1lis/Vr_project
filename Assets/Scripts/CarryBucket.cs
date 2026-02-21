using UnityEngine;

public class CarryBucket : MonoBehaviour
{
    public bool IsFull = false;
    public GameObject waterVisual;

    void Start()
    {
        IsFull = false; // ξεκινάει άδειος

        if (waterVisual != null)
        {
            waterVisual.SetActive(false); // κρύβουμε το νερό στην αρχή
        }
    }

    public void Fill()
    {
        if (IsFull) return; // αν είναι ήδη γεμάτος

        IsFull = true;

        if (waterVisual != null)
        {
            waterVisual.SetActive(true); // δείχνουμε το νερό
        }
    }

    public void Empty()
    {
        if (!IsFull) return; // αν είναι άδειος δεν κάνουμε κάτι

        IsFull = false;

        if (waterVisual != null)
        {
            waterVisual.SetActive(false); // κρύβουμε το νερό
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddBucket(); // δίνουμε πόντο στο quest
        }
    }

}