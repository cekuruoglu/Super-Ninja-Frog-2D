using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public GameObject levelTrans;
    public static LevelManager Instance;
    public Text totalFruits;
    public Text pickedFruits;
    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        totalFruits.text = transform.childCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        pickedFruits.text = transform.childCount.ToString();
    }
public void LevelCleaned()
    {
        if (transform.childCount == 1)
        {
            FindObjectOfType<End>();


        }
            
    }
 
}

