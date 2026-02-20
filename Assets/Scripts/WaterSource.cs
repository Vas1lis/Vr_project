using UnityEngine;

public class WaterSource : MonoBehaviour
{
    [Header("Prompt")]
    public string promptMessage = "Press E to fill";

    private void OnTriggerStay(Collider other)
    {
        // Ψάχνουμε στα παιδιά (εκεί είναι ο PlayerBucket)
        var bucket = other.GetComponentInChildren<CarryBucket>();
        if (bucket == null) return;

        // Αν ο κουβάς σου είναι ΗΔΗ γεμάτος
        if (bucket.IsFull)
        {
            PromptUI.Show("Your bucket is already full!");
        }
        else // Αν είναι άδειος
        {
            PromptUI.Show(promptMessage); // Εμφανίζει το "Press E to fill"

            if (Input.GetKeyDown(KeyCode.E))
            {
                bucket.Fill(); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var bucket = other.GetComponentInChildren<CarryBucket>();
        if (bucket == null) return;

        PromptUI.Hide(); // Κρύβει το μήνυμα όταν φεύγεις
    }
}