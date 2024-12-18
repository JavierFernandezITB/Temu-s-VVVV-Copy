using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKillScript : MonoBehaviour
{
    private GameObject spawnPoint;
    private GameManagerScript gameManager;
    private AudioManagerService audioManagerService;
    private GameObject character;
    private Animator animator;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private CharacterMovement characterMovement;
    private BoxCollider2D boxCollider;
    private bool isDead = false;

    void Start()
    {
        gameManager = GameObject.Find("/GameManagerService").GetComponent<GameManagerScript>();
        spawnPoint = gameManager.isPreviousLevel ? GameObject.Find("/ExitDoor") : GameObject.Find("/GoBackSign");
        audioManagerService = GameObject.Find("/AudioManagerService").GetComponent<AudioManagerService>();
        character = GameObject.Find("/Character");
        animator = character.GetComponent<Animator>();
        rb2d = character.GetComponent<Rigidbody2D>();
        spriteRenderer = character.GetComponent<SpriteRenderer>();
        characterMovement = character.GetComponent<CharacterMovement>();
        boxCollider = character.GetComponent<BoxCollider2D>();
    }

    private IEnumerator PlayDeathAnimation()
    {
        characterMovement.SetDeadState(true);
        audioManagerService.deathAudioSource.Play();
        boxCollider.enabled = false;
        rb2d.gravityScale = 0;
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("isDead", false);
        character.transform.position = spawnPoint.transform.position;
        spriteRenderer.flipY = false;
        characterMovement.isGravitySwitched = false;
        rb2d.gravityScale = 1;
        boxCollider.enabled = true;
        characterMovement.SetDeadState(false);
        isDead = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isDead)
        {
            isDead = true;
            StartCoroutine(PlayDeathAnimation());
        }
    }
}
