using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class UIManager : MonoBehaviour
{
    public AudioSource clip;
    public GameObject pausepanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        pausepanel.SetActive(true);
    }
    public void buttonSound()
    {
        clip.Play();
    }
    public void ResumeGame ()
    {
        Time.timeScale = 1;
        pausepanel.SetActive(false);
    }
    public void  Menu ()

    {
        SceneManager.LoadScene(0);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
