using UnityEngine;
using TMPro; // Απαραίτητο για το κείμενο UI

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    [Header("Quest Settings")]
    public TMP_Text questText;       // Εδώ θα βάλουμε το UI Κείμενο
    public GameObject fireVFX;       // Εδώ θα βάλουμε το εφέ της φωτιάς
    
    private int bucketsFilled = 0;   // Μετράει πόσοι κουβάδες γέμισαν

    void Awake()
    {
        Instance = this; 
    }

    void Start()
    {
        // Μόλις ξεκινάει το παιχνίδι, η φωτιά είναι ΣΒΗΣΤΗ
        if (fireVFX != null)
        {
            fireVFX.SetActive(false); 
        }
        UpdateQuestText();
    }

    // Αυτή η συνάρτηση θα καλείται κάθε φορά που γεμίζεις έναν κουβά
    public void AddBucket()
    {
        if (bucketsFilled < 4)
        {
            bucketsFilled++; 
            UpdateQuestText(); // Ανανεώνει το κείμενο (π.χ. 1/4, 2/4)

            // Αν φτάσαμε τους 4 κουβάδες, ανάβει η φωτιά αυτόματα!
            if (bucketsFilled >= 4)
            {
                CompleteQuest();
            }
        }
    }

    void UpdateQuestText()
    {
        if (questText != null && bucketsFilled < 4)
        {
            questText.text = "Quest: Fill the buckets at the houses with water (" + bucketsFilled + "/4)";
        }
    }

    void CompleteQuest()
    {
        // 1. Εμφανίζει (ανάβει) τη φωτιά
        if (fireVFX != null)
        {
            fireVFX.SetActive(true); 
        }
        
        // 2. Αλλάζει το μήνυμα επιτυχίας
        if (questText != null)
        {
            questText.text = "Quest Completed: The village fire is lit!";
            questText.color = Color.green; // Το κάνει πράσινο για επιβράβευση
        }
    }
}