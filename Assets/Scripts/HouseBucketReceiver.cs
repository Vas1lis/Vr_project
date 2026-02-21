using UnityEngine;

public class HouseBucketReceiver : MonoBehaviour
{
    [Header("Visual")]
    public GameObject filledVisual; // το visual όταν το σπίτι έχει νερό
    public bool isFilled = false; // αν το σπίτι είναι γεμάτο

    private void Start()
    {
        UpdateVisual();
    }

    private void OnTriggerStay(Collider other)
    {
        var bucket = other.GetComponentInChildren<CarryBucket>();
        if (bucket == null) return;

        // αν το σπίτι είναι ήδη γεμάτο
        if (isFilled)
        {
            PromptUI.Show("House bucket is full! Press Q to empty.");

            if (Input.GetKeyDown(KeyCode.Q))
            {
                isFilled = false; // αδειάζει το σπίτι
                UpdateVisual();
            }

            return;
        }

        // αν ο παίκτης δεν έχει νερό
        if (!bucket.IsFull)
        {
            PromptUI.Show("Your bucket is empty! Fetch water.");
            return;
        }
        
        PromptUI.Show("Press E to pour water");

        if (!Input.GetKeyDown(KeyCode.E)) return;

        bucket.Empty(); 
        isFilled = true; // γεμίζει το σπίτι
        UpdateVisual();
    }

    private void OnTriggerExit(Collider other)
    {
        var bucket = other.GetComponentInChildren<CarryBucket>();
        if (bucket == null) return;

        PromptUI.Hide(); // κρύβει το prompt όταν φύγει
    }

    private void UpdateVisual()
    {
        if (filledVisual != null)
            filledVisual.SetActive(isFilled); // δείχνει/κρύβει το visual
    }

}