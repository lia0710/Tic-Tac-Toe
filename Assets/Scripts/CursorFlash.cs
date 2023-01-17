using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFlash : MonoBehaviour
{
    public Light cursor;
    public float time = 0.05f;
    public bool rising = true;

    void Start()
    {
        cursor = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        if (time < 0)
        {
            if (rising)
            {
                cursor.intensity += 0.1f;
                if (cursor.intensity > 5)
                {
                    rising = false;
                }
            }
            else
            {
                cursor.intensity -= 0.1f;
                if (cursor.intensity < 3)
                {
                    rising = true;
                }
            }

            time = 0.05f;
        }
    }
}
