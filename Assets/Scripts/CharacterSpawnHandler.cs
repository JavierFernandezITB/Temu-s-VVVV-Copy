using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSpawnHandler : MonoBehaviour
{
    private GameManagerScript _gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        if (!(FindObjectsOfType<CharacterSpawnHandler>().Count() > 1))
        {
            DontDestroyOnLoad(transform);
        }
        else
        { 
            Destroy(transform.gameObject);
        }

        _gameManagerScript = GameObject.Find("/GameManagerService").GetComponent<GameManagerScript>();
    }

    private void Update()
    {
        if (_gameManagerScript.isSwitchingLevel)
        {
            try
            {
                Debug.Log("Spawn handle");
                if (_gameManagerScript.isPreviousLevel)
                    transform.position = GameObject.Find("/ExitTomb").transform.position;
                else
                    transform.position = GameObject.Find("/GoBackSign").transform.position;
                _gameManagerScript.isSwitchingLevel = false;
            }
            catch { }
        }
    }
}
