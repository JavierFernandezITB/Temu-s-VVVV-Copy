using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTombScript : MonoBehaviour
{
    public int currentLevel;
    private bool isPlayerTouchingTomb = false;
    private TMP_Text PressEUI;

    // Start is called before the first frame update
    void Start()
    {
        PressEUI = GameObject.Find("/UICanvas/PressEText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerTouchingTomb && Input.GetKeyDown(KeyCode.E))
        {
            Debug.LogWarning("Next level!");
            SceneManager.LoadScene((currentLevel + 1).ToString());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerTouchingTomb = true;
            PressEUI.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerTouchingTomb = false;
            try
            {
                PressEUI.enabled = false;
            }
            catch { }
        }
    }
}
