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
        // Μόνο αν είναι γεμάτος ο κουβάς δίνουμε πόντο στο Quest
        if (IsFull)
        {
            IsFull = false;
            if (waterVisual != null) waterVisual.SetActive(false);

            // ΕΔΩ ΕΙΝΑΙ Η ΣΩΣΤΗ ΘΕΣΗ (Μέσα στις αγκύλες της Empty)
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddBucket();
            }
        }
    }
}