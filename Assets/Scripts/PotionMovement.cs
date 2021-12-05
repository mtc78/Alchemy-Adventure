using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMovement : MonoBehaviour
{
    public float speedRight = 20f;
    public float speedUp = 5f;
    public Rigidbody2D rb;
    public float potionTime;
    private float cooldown;

    AudioSource source;
    SpriteRenderer spriteRenderer;

    private bool testcooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        potionTime = Time.timeSinceLevelLoad;
        rb.velocity = new Vector2(transform.right.x * speedRight, transform.up.y * speedUp);
        source = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cooldown = (Time.time + 3);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad - potionTime > 3)
        {
            Debug.Log("Expired");
            Destroy(spriteRenderer);
            Destroy(gameObject);
        }
        if (cooldown <= Time.time)
        {
            Debug.Log("cooldown ended");
            testcooldown = true;
        }
        if (testcooldown == true)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        if (!source.isPlaying)
        {
            Debug.Log("cooldown Activated");
            Destroy(spriteRenderer);
            Debug.Log("luke potion Hit collider");
            source.Play(); 
        }
    }

    void OnBecameInvisible()
    {
        Debug.Log("Became Invisible");
        //enabled = false;
        //Destroy(gameObject);
    }
}
