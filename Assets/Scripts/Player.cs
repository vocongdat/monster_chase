using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private bool isGround;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeybroad();
        AnimationPlayer();
        
    }

    void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeybroad ()
    {

        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;

    }

    void AnimationPlayer()
    {
        

        switch (movementX)
        {
            case -1:
                anim.SetBool(WALK_ANIMATION, true);
                sr.flipX = true;
                break;
            case 1:
                anim.SetBool(WALK_ANIMATION, true);
                sr.flipX = false;
                break;
            default :
                anim.SetBool(WALK_ANIMATION, false);
                break;
        }

    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGround)  
        {
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

}