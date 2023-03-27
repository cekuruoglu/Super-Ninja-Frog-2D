using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitTime;
    public float WaitTimeToAttack=2f;
    Animator anim;
    public GameObject bulletPref;
    public Transform launchPoint;
    void Start()
    {
        anim = GetComponent<Animator>();
        waitTime = WaitTimeToAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime <= 0)
        {
            waitTime = WaitTimeToAttack;
            anim.Play("Attack");
            Invoke("LaunchBullet", 0.3f);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
    public void LaunchBullet ()
    {

        Instantiate(bulletPref, launchPoint.position, launchPoint.rotation);
    }
}
