using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    private int hp;
    private SpriteRenderer mySpriteRenderer;
    public Sprite hp1;
    public Sprite hp2;
    public Sprite hp3;
    public Sprite hp4;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        int hp = PlayerPrefs.GetInt("Health");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Health") == 4)
        {
            mySpriteRenderer.sprite = hp1;
        }
        if (PlayerPrefs.GetInt("Health") == 3)
        {
            mySpriteRenderer.sprite = hp2;
        }
        if (PlayerPrefs.GetInt("Health") == 2)
        {
            mySpriteRenderer.sprite = hp3;
        }
        if (PlayerPrefs.GetInt("Health") == 1)
        {
            mySpriteRenderer.sprite = hp4;
        }
        int hp = PlayerPrefs.GetInt("Health");
    }
}
