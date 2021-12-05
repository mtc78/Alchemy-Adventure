using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    private SpriteRenderer mySpriteRenderer;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] positions;

    private int index;

    public int health;

    public Text textbox;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Potion"))
        {
            health -= 1;
            if (health == 0)
            {
                Destroy(gameObject);
            }
            if (health == 0 && SceneManager.GetActiveScene().name == "Level3Real")
            {
                Debug.Log("Reached textbox enable");
                textbox.enabled = true;
                image.enabled = true;
                Destroy(gameObject);
            }
        }
    }

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                mySpriteRenderer.flipX = true;
                index = 0;
            }
            else
            {
                mySpriteRenderer.flipX = false;
                index++;
            }
        }
    }
}
