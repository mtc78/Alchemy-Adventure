using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LukeMovement : MonoBehaviour
{

    private SpriteRenderer mySpriteRenderer;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] positions;

    private int index;

    public int health;

    private BoxCollider2D boxCollider;

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
                Transform child = transform.Find("PotionSpawn(1)");
                child.transform.localPosition = new Vector3(1.5f, 2.2f, 0);
                child.Rotate(new Vector3(0, 180, 0));
                
            }
            else
            {
                mySpriteRenderer.flipX = false;
                index++;
                Transform child = transform.Find("PotionSpawn(1)");
                child.transform.localPosition = new Vector3(-1.5f, 2.2f, 0);
                child.Rotate(new Vector3(0, 180, 0));
            }
        }
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);
        foreach (Collider2D hit in hits)
        {
            // Ignore our own collider.
            if (hit == boxCollider || hit.gameObject.name == "LukePotion" || hit.gameObject.name == "LukePotion(Clone)")
                continue;
        }
    }
}
