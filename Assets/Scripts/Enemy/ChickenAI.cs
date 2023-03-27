using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChickenAI : MonoBehaviour
{
    private Animator anim;

    private SpriteRenderer sR;

    public float speed = 2f;

    private float waitTime;

    public Transform[] movingSpot;

    public float startWaitingTime = 3f;

    private int i;

    private Vector2 currentPos;
    void Start()
    {
        waitTime = startWaitingTime;
        sR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckWaiting());
        transform.position = Vector2.MoveTowards(transform.position, movingSpot[i].transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movingSpot[i].transform.position) < 0.5f)
        {
            if (waitTime <= 0)
            {
                if (movingSpot[i] != movingSpot[movingSpot.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitTime = startWaitingTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
    IEnumerator CheckWaiting()
    {
        currentPos = transform.position;
        yield return new WaitForSeconds(0.5f);
        if (transform.position.x > currentPos.x)
        {
            sR.flipX = true;
            
        }
        else if (transform.position.x < currentPos.x)
        {
            sR.flipX = false;
            
        }
        else if (transform.position.x == currentPos.x)
        {
            
        }
    }

}
