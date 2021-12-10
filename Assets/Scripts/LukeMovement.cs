using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

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

    public Animator animator;

    private bool dead = false;

    BoxCollider2D lukecollider;

    public Text textbox;
    public Image image;


    public GameObject arena1;
    public GameObject arena2;

    // Start is called before the first frame update
    void Start()
    {
        lukecollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Potion"))
        {
            health -= 1;
            if (health == 0)
            {
                Destroy(lukecollider);
                animator.SetBool("IsDead", true);
                dead = true;
                textbox.enabled = true;
                image.enabled = true;
                Destroy(arena1);
                Destroy(arena2);
                Destroy(textbox, 4);
                Destroy(image, 4);
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
        if (dead == false)
        {
            Debug.Log(dead);
            transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
        }
       
        if (transform.position == positions[index] && dead == false)
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
