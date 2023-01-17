using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    public GameObject cursor;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("up") && cursor.gameObject.transform.position.y < 0.1f)
        {
            cursor.gameObject.transform.position += new Vector3(0, 3.4f, 0);
        }
        if (Input.GetKeyUp("down") && cursor.gameObject.transform.position.y > -0.1f)
        {
            cursor.gameObject.transform.position += new Vector3(0, -3.4f, 0);
        }
        if (Input.GetKeyUp("left") && cursor.gameObject.transform.position.x > -0.1f)
        {
            cursor.gameObject.transform.position += new Vector3(-3.5f, 0, 0);
        }
        if (Input.GetKeyUp("right") && cursor.gameObject.transform.position.x < 0.1f)
        {
            cursor.gameObject.transform.position += new Vector3(3.5f, 0, 0);
        }
    }
}
