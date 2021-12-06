using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PotionThrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject potion;
    private bool testcooldown = true;
    private float cooldown;
    private float animationcooldown;

    public Animator animator;
    public Animator cooldownanimator;
    public PlayableDirector playableDirector;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && testcooldown == true && playableDirector.state != PlayState.Playing)
        {
            animator.SetBool("IsThrowing", true);
            ThrowPotion();
            testcooldown = false;
            cooldown = Time.time + 1;
            animationcooldown = Time.time + 0.2f;
            cooldownanimator.SetBool("Fill", true);
        }
        if (cooldown <= Time.time)
        {
            testcooldown = true;
            cooldownanimator.SetBool("Fill", false);
        }
        if (animationcooldown <= Time.time)
        {
            animator.SetBool("IsThrowing", false);
        }
    }

    void ThrowPotion(){
        Instantiate(potion, firePoint.position, firePoint.rotation);
    }
}
