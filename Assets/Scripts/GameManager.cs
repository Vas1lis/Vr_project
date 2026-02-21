using UnityEngine;
using TMPro; // Απαραίτητο για το κείμενο UI

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    [Header("Quest Settings")]
    public TMP_Text questText;       // το κείμενο του quest
    public GameObject fireVFX;       // το εφέ φωτιάς

    private int bucketsFilled = 0;   // πόσοι κουβάδες έχουν δοθεί

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (fireVFX != null)
        {
            fireVFX.SetActive(false); // η φωτιά ξεκινάει σβηστή
        }

        UpdateQuestText(); // αρχικό update
    }

    public void AddBucket()
    {
        if (bucketsFilled < 4)
        {
            bucketsFilled++; 
            UpdateQuestText(); // ανανεώνει το ui

            if (bucketsFilled >= 4)
            {
                CompleteQuest(); // μόλις γίνουν 4
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
        if (fireVFX != null)
        {
            fireVFX.SetActive(true); // ανάβει η φωτιά
        }

        if (questText == null) return;
        questText.text = "Quest Completed: The village fire is lit!";
        questText.color = Color.green;
    }
}