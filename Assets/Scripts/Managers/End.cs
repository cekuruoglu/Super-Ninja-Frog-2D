using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour
{
    public GameObject canvas;
    public GameObject levelTrans;
    Level_Select selection;
    private void Start()
    {
        selection = GetComponent<Level_Select>();
    }
    void ChangeLevel()
    {
        if (FindObjectOfType<LevelManager>().transform.childCount == 0)
        {
            SceneManager.LoadScene("LevelSelection");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (FindObjectOfType<LevelManager>().transform.childCount == 0)
        {
            if (collision.CompareTag("Player"))
            {
                GetComponent<Animator>().enabled = enabled;
                StartCoroutine(Waiting1());
                selection.GetLevelIndex();
            }
        }
    }
   
    IEnumerator Waiting1()
    {
        
        yield return new WaitForSeconds(1.5f);
        levelTrans.SetActive(true); ;
        canvas.SetActive(false);
        yield return new WaitForSeconds(2f);
        ChangeLevel();
    }



}
