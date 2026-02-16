using UnityEngine; //Access the system library
using UnityEngine.SceneManagement; // access the library using the scene manager

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    private bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
        Destroy(gameObject); // "gameObject" is for this script, if using "GameObject" it will use Unity's component of "GamObject".
        }
    }

    public void LoadScene (string sceneName)
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(sceneName);
    }
    public void ReloadScene()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void TogglePause()
    {
        if(isPaused)
        ResumeGame();
        else
        PauseGame();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public voidi QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit(); //closes the actual Unity game
        #endif
    }
    
}
