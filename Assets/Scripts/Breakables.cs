using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    AudioSource source;
    private SpriteRenderer mySpriteRenderer;
    private int health = 4;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Potion"))
        {
            source.Play();
            Destroy(gameObject, 0.4f);
        }
        if (other.CompareTag("Potion") && PlayerPrefs.GetInt("Health") < 4)
        {
            health = (PlayerPrefs.GetInt("Health") + 1);
            PlayerPrefs.SetInt("Health", health);
            PlayerPrefs.Save();
            source.Play();
            Destroy(gameObject, 0.2f);
        }
    }

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

}
