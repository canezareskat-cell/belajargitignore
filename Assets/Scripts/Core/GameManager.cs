using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetState(GameState.Playing);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Playing)
            {
                PauseGame();
            }
            else if (currentState == GameState.Paused)
            {
                ResumeGame();
            }
        }
    }

    public void SetState(GameState newState)
    {
        currentState = newState;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        SetState(GameState.Paused);
        Debug.Log("Paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        SetState(GameState.Playing);
        Debug.Log("Resume");
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        SetState(GameState.GameOver);
        Debug.Log("Game Over");
    }
}