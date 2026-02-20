using UnityEngine;

public class CarryBucket : MonoBehaviour
{
    public bool IsFull = false; // Ο διακόπτης που έλειπε!
    public GameObject waterVisual;

    void Start()
    {
        IsFull = false;
        if (waterVisual != null) waterVisual.SetActive(false);
    }

    public void Fill()
    {
        IsFull = true; // Τώρα το σύστημα ΞΕΡΕΙ ότι γέμισε
        if (waterVisual != null) waterVisual.SetActive(true);
    }

    public void Empty()
    {
        IsFull = false; // Τώρα το σύστημα ΞΕΡΕΙ ότι άδειασε
        if (waterVisual != null) waterVisual.SetActive(false);
    }
}