using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioSource openMenu,closeMenu,backGroundMusic;

    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeSelf)
            {
                ClosePauseMenu();
            }
            else OpenPauseMenu();
        }
    }
    public void OpenPauseMenu()
    {
        backGroundMusic.Stop();
        openMenu.Play();
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void ClosePauseMenu()
    {
        backGroundMusic.Play();
        closeMenu.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
