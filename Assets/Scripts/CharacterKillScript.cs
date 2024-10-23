using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKillScript : MonoBehaviour
{
    private GameObject spawnPoint;

    void Start()
    {
        spawnPoint = GameObject.Find("/GoBackSign");
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.tag == "Player")
        { 
            other.transform.position = spawnPoint.transform.position;
            other.transform.GetComponent<SpriteRenderer>().flipY = false;
            other.GetComponent<CharacterMovement>().isGravitySwitched = false;
            other.GetComponent<Rigidbody2D>().gravityScale = 1;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2();
        }
    }
}
