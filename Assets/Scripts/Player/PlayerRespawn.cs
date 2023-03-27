using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerRespawn : MonoBehaviour
{
    Animator anim;
    public GameObject[] health;
     int life;
    void Start()
    {
        anim = GetComponent<Animator>();
        life = health.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckLife()
    {
        if (life < 1)
        {
            Destroy(health[0].gameObject);
            anim.SetTrigger("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (life < 2)
        {
            Destroy(health[1].gameObject);
            anim.SetTrigger("Hit");
        }
        else if (life < 3)
        {
            Destroy(health[2].gameObject);
            anim.SetTrigger("Hit");
        }
    }
    public void PlayerDamage()
    {
        
        life--;
        CheckLife();
    }
    public void SpikeDamage()
    {
        life--;
        life--;
        life--;
        SpikeDamageLife();
        //Invoke("HitTime", 1f);
    }
    void HitTime()
    {
        
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void SpikeDamageLife()
    {
        anim.SetTrigger("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Destroy(health[0].gameObject);
        Destroy(health[1].gameObject);
        Destroy(health[2].gameObject);
        

    }
}

