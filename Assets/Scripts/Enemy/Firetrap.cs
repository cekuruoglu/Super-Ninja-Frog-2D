using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float activationDelay;
    [SerializeField] private float activateTime;
    private Animator anim;
    private SpriteRenderer sR;
    private bool triggered;
    private bool active;
        
    void Start()
    {
        anim = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            if (!triggered)
            {
                StartCoroutine(ActivateFireTrap());
            }
            if (active)
            {
                collision.transform.GetComponent<PlayerRespawn>().PlayerDamage();
            }
        }
    }
    private IEnumerator ActivateFireTrap()
    {
        triggered = true;
        yield return new WaitForSeconds(activationDelay);
        active = true;
        anim.SetBool("activated", true);
        yield return new WaitForSeconds(activateTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
