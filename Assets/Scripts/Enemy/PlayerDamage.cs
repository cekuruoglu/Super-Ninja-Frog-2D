using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private Collider2D coll;
    private Animator anim;
    private SpriteRenderer sR;
    public GameObject deathEffect;
    public int lifes = 2;
    public float jumpForce = 2f;
    void Start()
    {
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            HealthReduce();
            CheckLife();
        }
    }
    public void HealthReduce()
    {
        lifes--;
        anim.Play("Hit");
    }
    public  void CheckLife ()
    {
        if (lifes == 0)
        {
            deathEffect.SetActive(true);
            sR.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }
    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
