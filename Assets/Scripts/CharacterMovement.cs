using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb2d;
    private bool moveRight = false;
    private bool moveLeft = false;
    private bool isGravitySwitched = false;
    private Animator characterAnimator;
    private SpriteRenderer characterSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponent<Animator>();
        characterSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveRight = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && rb2d.velocity.y == 0)
        {
            isGravitySwitched = !isGravitySwitched;
        }
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        if (moveRight || moveLeft)
            characterAnimator.SetBool("isWalking", true);
        else
            characterAnimator.SetBool("isWalking", false);
        if (moveRight)
        {
            characterSprite.flipX = false;
            rb2d.velocity = new Vector2(1 * speed, rb2d.velocity.y);
        }
        else if (moveLeft)
        {
            characterSprite.flipX = true;
            rb2d.velocity = new Vector2(-1 * speed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (isGravitySwitched)
        {
            characterSprite.flipY = !characterSprite.flipY;
            rb2d.velocity = new Vector2(0, rb2d.gravityScale * 10);
            rb2d.gravityScale = -rb2d.gravityScale;
            isGravitySwitched = false;
        }
    }
}