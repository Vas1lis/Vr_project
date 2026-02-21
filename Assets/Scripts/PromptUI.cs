using UnityEngine;
using TMPro; 

public class PromptUI : MonoBehaviour
{
    public static PromptUI Instance; 

    public TextMeshProUGUI promptText;

    private void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        Hide(); // ξεκινάει κρυφό
    }

    public static void Show(string message)
    {
        if (Instance == null || Instance.promptText == null) return;
        Instance.promptText.text = message;
        Instance.promptText.gameObject.SetActive(true); // εμφανίζει το prompt
    }

    public static void Hide()
    {
        if (Instance == null || Instance.promptText == null) return;
        Instance.promptText.text = "";
        Instance.promptText.gameObject.SetActive(false); // κρύβει το prompt
    }

}