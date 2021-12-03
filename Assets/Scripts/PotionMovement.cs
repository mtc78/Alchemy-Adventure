using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMovement : MonoBehaviour
{
    public float speedRight = 20f;
    public float speedUp = 5f;
    public Rigidbody2D rb;
    public float potionTime;

    // Start is called before the first frame update
    void Start()
    {
        potionTime = Time.timeSinceLevelLoad;
        rb.velocity = new Vector2(transform.right.x * speedRight, transform.up.y * speedUp);
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad - potionTime > 3)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }
}
