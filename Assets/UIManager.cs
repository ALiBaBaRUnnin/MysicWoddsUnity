using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject restartButton; // Reference to the Restart Button

    void Start()
    {
        
        restartButton.SetActive(false);
    }

    public void ShowRestartButton()
    {
        // this shows the button when the player dies
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
