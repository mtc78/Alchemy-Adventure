using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LukePotionThrow : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public Transform firePoint;
    public GameObject potion;
    private bool testcooldown = true;
    private float cooldown;
    private float animationcooldown;
    private bool ready = false;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (playableDirector.state != PlayState.Playing)
        {
            ready = true;
        }
        if (testcooldown == true && ready == true && animator.GetBool("IsDead") == false)
        {
            animator.SetBool("IsThrowing", true);
            ThrowPotion();
            testcooldown = false;
            cooldown = Time.time + 3;
            animationcooldown = Time.time + 1;
        }
        if (cooldown <= Time.time)
        {
            testcooldown = true;
        }
        if (animationcooldown <= Time.time)
        {
            animator.SetBool("IsThrowing", false);
        }
    }

    void ThrowPotion()
    {
        Instantiate(potion, firePoint.position, firePoint.rotation);
    }
}
