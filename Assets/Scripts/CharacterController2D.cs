using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 9;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 70;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    float jumpHeight = 4;

    private BoxCollider2D boxCollider;

    private Vector2 velocity;

    /// <summary>
    /// Set to true when the character intersects a collider beneath
    /// them in the previous frame.
    /// </summary>
    private bool grounded;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public Rigidbody2D pfPotion;
    public float potionspeed = 100;

    public void Fire()
    {
        Rigidbody2D potion = Instantiate(pfPotion, transform.position, transform.rotation); //spawn potion
        //Rigidbody2D potion = Instantiate(pfPotion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        potion.GetComponent<Rigidbody2D>().AddForce(transform.right * potionspeed); //this does not appear to be doing anything
    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        // Use GetAxisRaw to ensure our input is either 0, 1 or -1.
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Determine JUMP (spacebar) ONLY if player is on the ground
        if (grounded)
        {
            velocity.y = 0;
                        
            if (Input.GetButtonDown("Jump"))
            {
                // Calculate jump height.
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        // Movement taking into account of air-movements
        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;
        // Movement using left arror/'A' and right arrow/'D'
        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        //Calculate velocity in term of time
        velocity.y += Physics2D.gravity.y * Time.deltaTime;
        transform.Translate(velocity * Time.deltaTime);
        // Reset to player being on the air.
        grounded = false;

        // Detect a wall collision based on the directions of the player heading to
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        //Collision check before character moves into area.  IF anything in there, it'll be a collision
        foreach (Collider2D hit in hits)
        {
            // Ignore our own collider.
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                // If we intersect an object beneath us, set grounded to true. 
                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                {
                    grounded = true;
                }
            }
        }
    }
}