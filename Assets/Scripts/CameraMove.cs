using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject character;
    private float defaultY;
    private float defaultZ;
       

    // Start is called before the first frame update
    void Start()
    {
        defaultY = transform.position.y;
        defaultZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(character.transform.position.x, defaultY, defaultZ);
    }
}
