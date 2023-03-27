using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Audio;
public class MainMenuManagers : MonoBehaviour
{
    public GameObject panel;
    public AudioSource clip;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void buttonSound()
    {
        clip.Play();
    }
    
    public void Settings()
    {
        panel.GetComponent<Animator>().SetTrigger("pop");
    }
    public void StartGame()
    {
        Invoke("WaitTime", 0.5f);
    }
    public void WaitTime()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
   
}



