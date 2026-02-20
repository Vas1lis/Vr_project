using UnityEngine;

public class HouseBucketReceiver : MonoBehaviour
{
    [Header("Visual")]
    public GameObject filledVisual;
    public bool isFilled = false;

    private void Start()
    {
        UpdateVisual();
    }

    private void OnTriggerStay(Collider other)
    {
        var bucket = other.GetComponentInChildren<CarryBucket>();
        if (bucket == null) return;

        // 1. ΑΝ ΤΟ ΣΠΙΤΙ ΕΙΝΑΙ ΓΕΜΑΤΟ -> Πατάμε Q για άδειασμα!
        if (isFilled)
        {
            PromptUI.Show("House bucket is full! Press Q to empty.");
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isFilled = false; // Αδειάζει
                UpdateVisual();
            }
            return; // Σταματάει εδώ
        }

        // 2. Αν το σπίτι είναι άδειο, αλλά ο δικός σου κουβάς είναι άδειος
        if (!bucket.IsFull)
        {
            PromptUI.Show("Your bucket is empty! Fetch water.");
            return;
        }

        // 3. Αν το σπίτι είναι άδειο ΚΑΙ εσύ έχεις νερό -> Πατάς Ε
        PromptUI.Show("Press E to pour water");

        if (!Input.GetKeyDown(KeyCode.E)) return;
        bucket.Empty(); // Αδειάζει ο δικός σου
        isFilled = true; // Γεμίζει του σπιτιού
        UpdateVisual();
    }

    private void OnTriggerExit(Collider other)
    {
        var bucket = other.GetComponentInChildren<CarryBucket>();
        if (bucket == null) return;

        PromptUI.Hide();
    }

    private void UpdateVisual()
    {
        if (filledVisual != null)
            filledVisual.SetActive(isFilled);
    }
}