using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))] // βάζει audio source αυτόματα
public class SimpleFPSController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 9f; // ταχύτητα με shift
    public float mouseSensitivity = 200f;
    public float gravity = -9.81f;

    [Header("References")]
    public Transform cameraHolder; // το holder της κάμερας

    [Header("Footstep Sounds")]
    public AudioClip[] footstepSounds; // ήχοι βημάτων
    public float baseStepInterval = 0.5f; // βασικό διάστημα βήματος
    private float stepTimer;
    private AudioSource audioSource;

    private CharacterController controller;
    private float yVelocity;
    private float xRotation = 0f;

    // --- ΜΕΤΑΒΛΗΤΕΣ ΓΙΑ ΤΟ ΜΕΝΟΥ (ESC) ---
    [Header("UI Menu")]
    public GameObject quitMenuPanel; // Εδώ θα βάλουμε το Panel του μενού
    private bool isMenuOpen = false; // Ελέγχει αν το μενού είναι ανοιχτό

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked; // κλειδώνει το mouse
        Cursor.visible = false; // κρύβει το ποντίκι
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen) 
                ResumeGame(); 
            else 
                OpenMenu();
        }

        // Αν το μενού είναι ανοιχτό, σταματάμε κίνηση και κάμερα
        if (isMenuOpen) return;

        Move();
        Look();
    }
    
    public void OpenMenu()
    {
        isMenuOpen = true;
        quitMenuPanel.SetActive(true); 
        

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame() 
    {
        isMenuOpen = false;
        quitMenuPanel.SetActive(false); 
        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame() 
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        Vector3 move = transform.right * x + transform.forward * z;
        
        if (controller.isGrounded && yVelocity < 0)
            yVelocity = -2f;

        yVelocity += gravity * Time.deltaTime;

        Vector3 finalMovement = move * currentSpeed;
        finalMovement.y = yVelocity;

        controller.Move(finalMovement * Time.deltaTime);
        
        HandleFootsteps(x, z, currentSpeed);
    }

    void HandleFootsteps(float x, float z, float currentSpeed)
    {
        if (controller.isGrounded && (Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f))
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstepSound();
                
                stepTimer = baseStepInterval * (walkSpeed / currentSpeed);
            }
        }
        else
        {
            stepTimer = 0f; 
        }
    }

    void PlayFootstepSound()
    {
        // random για να μην είναι ίδιο συνέχεια
        if (footstepSounds.Length <= 0) return;
        int randomIndex = Random.Range(0, footstepSounds.Length);
        audioSource.PlayOneShot(footstepSounds[randomIndex]);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}