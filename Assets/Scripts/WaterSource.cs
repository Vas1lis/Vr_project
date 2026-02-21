using UnityEngine;

public class WaterSource : MonoBehaviour
{
    [Header("Prompt")]
    public string promptMessage = "Press E to fill"; // μήνυμα που δείχνει

    private void OnTriggerStay(Collider other)
    {

        var bucket = other.GetComponentInChildren<CarryBucket>();
        if (bucket == null) return;

        if (bucket.IsFull)
        {
            PromptUI.Show("Your bucket is already full!"); // αν είναι γεμάτος
        }
        else
        {
            PromptUI.Show(promptMessage); // δείχνει το βασικό μήνυμα

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

        PromptUI.Hide();
    }

}