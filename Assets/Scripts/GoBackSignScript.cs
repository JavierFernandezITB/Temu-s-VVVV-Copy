using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackSignScript : MonoBehaviour
{
    private int currentLevel;
    private bool isPlayerTouchingSign = false;
    private TMP_Text PressEUI;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = GameObject.Find("/ExitTomb").GetComponent<ExitTombScript>().currentLevel;
        PressEUI = GameObject.Find("/UICanvas/PressEText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerTouchingSign && Input.GetKeyDown(KeyCode.E))
        {
            Debug.LogWarning("Previous level!");
            SceneManager.LoadScene((currentLevel - 1).ToString());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerTouchingSign = true;
            PressEUI.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerTouchingSign = false;
            try
            {
                PressEUI.enabled = false;
            }
            catch { }
        }
    }
}
