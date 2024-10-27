using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused;

    private void Update()
    {
        if (isGamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void WinGame()
    {
        Debug.Log("Win Game");
        // Transition Animation to Win Screen
    }

    public void LoseGame()
    {
        Debug.Log("Lose Game");
        // Transition Animation to Lose Screen
    }
}
