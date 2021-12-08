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

    //public GameObject audioplayer;

    AudioSource source;
    SpriteRenderer spriteRenderer;
    PolygonCollider2D potioncollider;

    // Start is called before the first frame update
    void Start()
    {
        //audioplayer = GameObject.Find("potionaudio");
        //audioplayer.SetActive(false);
        potionTime = Time.timeSinceLevelLoad;
        rb.velocity = new Vector2(transform.right.x * speedRight, transform.up.y * speedUp);
        source = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        potioncollider = GetComponent<PolygonCollider2D>();
        cooldown = (Time.time + 1);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad - potionTime > 3)
        {
            Destroy(spriteRenderer);
            Destroy(gameObject);
        }
        if (cooldown <= Time.time)
        {
            //audioplayer.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        if (!source.isPlaying)
        {
            //cooldown = (Time.time + 3);
            //audioplayer.SetActive(true);
            Debug.Log(hitInfo);
            Destroy(spriteRenderer);
            source.Play();
            Destroy(potioncollider);
            Destroy(gameObject, 0.7f);
        }
    }

    void OnBecameInvisible()
    {
        Debug.Log("Became Invisible");
        //enabled = false;
        //Destroy(gameObject);
    }
}
