using UnityEngine;
using TMPro; // Απαραίτητο για το TextMeshPro

public class PromptUI : MonoBehaviour
{
    // Το 'Instance' επιτρέπει σε όλα τα άλλα scripts να μιλάνε σε αυτό το script χωρίς να το ψάχνουν!
    public static PromptUI Instance; 

    public TextMeshProUGUI promptText;

    private void Awake()
    {
        // Μόλις ξεκινήσει το παιχνίδι, δηλώνει "Εγώ είμαι το μοναδικό PromptUI!"
        Instance = this; 
    }

    private void Start()
    {
        Hide(); // Κρύβουμε το κείμενο στην αρχή
    }

    public static void Show(string message)
    {
        if (Instance != null && Instance.promptText != null)
        {
            Instance.promptText.text = message;
            Instance.promptText.gameObject.SetActive(true);
        }
    }

    public static void Hide()
    {
        if (Instance != null && Instance.promptText != null)
        {
            Instance.promptText.text = "";
            Instance.promptText.gameObject.SetActive(false);
        }
    }
}