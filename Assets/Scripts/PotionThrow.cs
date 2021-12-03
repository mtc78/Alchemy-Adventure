using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject potion;
    private bool testcooldown = true;
    private float cooldown;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && testcooldown == true)
        {
            ThrowPotion();
            testcooldown = false;
            cooldown = Time.time + 1;
        }
        if (cooldown <= Time.time)
        {
            testcooldown = true;
        }
    }

    void ThrowPotion(){
        Instantiate(potion, firePoint.position, firePoint.rotation);
    }
}
