using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{

    private SpriteRenderer mySpriteRenderer;
    private int health = 4;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Potion") && PlayerPrefs.GetInt("Health") < 4)
        {
            health = (PlayerPrefs.GetInt("Health") + 1);
            PlayerPrefs.SetInt("Health", health);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

}
