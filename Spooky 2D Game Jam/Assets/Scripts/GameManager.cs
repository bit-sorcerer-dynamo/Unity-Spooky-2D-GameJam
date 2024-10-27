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
        // Transition Animation to Win Screen
    }

    public void LoseGame()
    {
        // Transition Animation to Lose Screen
    }
}
