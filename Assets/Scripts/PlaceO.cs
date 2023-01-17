using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceO : MonoBehaviour
{
    public GameObject cursor;
    public GameObject O;
    public GameObject X;
    public int scoreo = 0;
    public int scorex = 0;
    GameObject O1;
    GameObject X1;
    Vector3 location;
    Vector3[] positions = new Vector3[9];
    Vector3 p0 = new Vector3(-3.5f, 3.4f, -1);
    Vector3 p1 = new Vector3(0, 3.4f, -1);
    Vector3 p2 = new Vector3(3.5f, 3.4f, -1);
    Vector3 p3 = new Vector3(-3.5f, 0, -1);
    Vector3 p4 = new Vector3(0, 0, -1);
    Vector3 p5 = new Vector3(3.5f, 0, -1);
    Vector3 p6 = new Vector3(-3.5f, -3.4f, -1);
    Vector3 p7 = new Vector3(0, -3.4f, -1);
    Vector3 p8 = new Vector3(3.5f, -3.4f, -1);
    //Vector3[] positions = new Vector3[9];
    int index = 0;
    bool[] placed = { false, false, false, false, false, false, false, false, false };
    bool[] placedOs = { false, false, false, false, false, false, false, false, false };
    bool[] placedXs = { false, false, false, false, false, false, false, false, false };

    void Start()
    {
        positions[0] = p0;
        positions[1] = p1;
        positions[2] = p2;
        positions[3] = p3;
        positions[4] = p4;
        positions[5] = p5;
        positions[6] = p6;
        positions[7] = p7;
        positions[8] = p8;
    }

    // Update is called once per frame
    void Update()
    {
        bool full = true;
        bool win = false;
        location = cursor.gameObject.transform.position;
        if (Input.GetKeyUp("space"))
        {
            index = getIndex(location);
            if (index != -1)
            {
                O1 = GameObject.Instantiate(O);
                O1.transform.position = location;
                //printplaced();
                win = checkWin();
                for (int i = 0; i < 9; i++)
                {
                    if (placed[i] == false)
                    {
                        full = false;
                    }
                }
                if (full || win)
                {
                    if (win)
                    {
                        Scores.instance.UpdateOPoints();
                    }
                    //Application.Quit();
                    //UnityEditor.EditorApplication.isPlaying = false;
                    reset();
                }
                else
                {
                    placeX();
                    win = checkWin();
                    if (win)
                    {
                        Scores.instance.UpdateXPoints();
                        reset();
                    }
                }
            }
        }
    }

    void reset()
    {
        GameObject[] Os;
        Os = GameObject.FindGameObjectsWithTag("O");
        GameObject[] Xs;
        Xs = GameObject.FindGameObjectsWithTag("X");
        for (int i = Os.Length-1; i > 0; i--)
        {
            Destroy(Os[i]);
        }
        for (int j = Xs.Length-1; j > 0; j--)
        {
            Destroy(Xs[j]);
        }
        for (int k = 0; k < 9; k++)
        {
            placed[k] = false;
            placedOs[k] = false;
            placedXs[k] = false;
        }
    }

    void placeX()
    {
        //if you can win, then do it
        if (!checkFinalMove())
        {
            //print("final move");
            //check if player is about to win and stop them
            if (!checkStopPlayer())
            {
                //print("stop player");
                randomX();
                //print("random");
            }
        }
        //build up a line you've started
        //place randomly
    }

    void randomX()
    {
        int random = 0;
        int count = 0;
        int index = 0;
        int[] values = {-1, -1, -1, -1, -1, -1, -1, -1, -1};
        for (int i = 0; i < 9; i++)
        {
            if (!placed[i])
            {
                values[count] = i;
                count++;
            }
        }
        random = Random.Range(0, count);
        index = values[random]; //index now has a number of a space that has not been placed
        X1 = GameObject.Instantiate(X);
        X1.transform.position = positions[index];
        placed[index] = true;
        placedXs[index] = true;
    }

    bool checkFinalMove()
    {
        bool placedX = false;
        if (placed[0] != true && placedX == false)
        {
            if ((placedXs[1] && placedXs[2]) || (placedXs[3] && placedXs[6]) || (placedXs[4] && placedXs[8]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[0];
                placed[0] = true;
                placedXs[0] = true;
                placedX = true;
            }
        }
        if (placed[1] != true && placedX == false)
        {
            if ((placedXs[0] && placedXs[2]) || (placedXs[4] && placedXs[7]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[1];
                placed[1] = true;
                placedXs[1] = true;
                placedX = true;
            }
        }
        if (placed[2] != true && placedX == false)
        {
            if ((placedXs[0] && placedXs[1]) || (placedXs[5] && placedXs[8]) || (placedXs[4] && placedXs[6]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[2];
                placed[2] = true;
                placedXs[2] = true;
                placedX = true;
            }
        }
        if (placed[3] != true && placedX == false)
        {
            if ((placedXs[0] && placedXs[6]) || (placedXs[4] && placedXs[5]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[3];
                placed[3] = true;
                placedXs[3] = true;
                placedX = true;
            }
        }
        if (placed[4] != true && placedX == false)
        {
            if ((placedXs[1] && placedXs[7]) || (placedXs[3] && placedXs[5]) || (placedXs[0] && placedXs[8]) || (placedXs[2] && placedXs[6]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[4];
                placed[4] = true;
                placedXs[4] = true;
                placedX = true;
            }
        }
        if (placed[5] != true && placedX == false)
        {
            if ((placedXs[2] && placedXs[8]) || (placedXs[3] && placedXs[4]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[5];
                placed[5] = true;
                placedXs[5] = true;
                placedX = true;
            }
        }
        if (placed[6] != true && placedX == false)
        {
            if ((placedXs[0] && placedXs[3]) || (placedXs[7] && placedXs[8]) || (placedXs[2] && placedXs[4]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[6];
                placed[6] = true;
                placedXs[6] = true;
                placedX = true;
            }
        }
        if (placed[7] != true && placedX == false)
        {
            if ((placedXs[6] && placedXs[8]) || (placedXs[1] && placedXs[4]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[7];
                placed[7] = true;
                placedXs[7] = true;
                placedX = true;
            }
        }
        if (placed[8] != true && placedX == false)
        {
            if ((placedXs[6] && placedXs[7]) || (placedXs[2] && placedXs[5]) || (placedXs[0] && placedXs[4]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[8];
                placed[8] = true;
                placedXs[8] = true;
                placedX = true;
            }
        }
        return placedX;
    }

    bool checkStopPlayer()
    {
        bool placedX = false;
        if (placed[0] != true && placedX == false)
        {
            if ((placedOs[1] && placedOs[2]) || (placedOs[3] && placedOs[6]) || (placedOs[4] && placedOs[8]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[0];
                placed[0] = true;
                placedXs[0] = true;
                placedX = true;
            }
        }
        if (placed[1] != true && placedX == false)
        {
            if ((placedOs[0] && placedOs[2]) || (placedOs[4] && placedOs[7]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[1];
                placed[1] = true;
                placedXs[1] = true;
                placedX = true;
            }
        }
        if (placed[2] != true && placedX == false)
        {
            if ((placedOs[0] && placedOs[1]) || (placedOs[5] && placedOs[8]) || (placedOs[4] && placedOs[6]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[2];
                placed[2] = true;
                placedXs[2] = true;
                placedX = true;
            }
        }
        if (placed[3] != true && placedX == false)
        {
            if ((placedOs[0] && placedOs[6]) || (placedOs[4] && placedOs[5]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[3];
                placed[3] = true;
                placedXs[3] = true;
                placedX = true;
            }
        }
        if (placed[4] != true && placedX == false)
        {
            if ((placedOs[1] && placedOs[7]) || (placedOs[3] && placedOs[5]) || (placedOs[0] && placedOs[8]) || (placedOs[2] && placedOs[6]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[4];
                placed[4] = true;
                placedXs[4] = true;
                placedX = true;
            }
        }
        if (placed[5] != true && placedX == false)
        {
            if ((placedOs[2] && placedOs[8]) || (placedOs[3] && placedOs[4]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[5];
                placed[5] = true;
                placedXs[5] = true;
                placedX = true;
            }
        }
        if (placed[6] != true && placedX == false)
        {
            if ((placedOs[0] && placedOs[3]) || (placedOs[7] && placedOs[8]) || (placedOs[2] && placedOs[4]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[6];
                placed[6] = true;
                placedXs[6] = true;
                placedX = true;
            }
        }
        if (placed[7] != true && placedX == false)
        {
            if ((placedOs[6] && placedOs[8]) || (placedOs[1] && placedOs[4]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[7];
                placed[7] = true;
                placedXs[7] = true;
                placedX = true;
            }
        }
        if (placed[8] != true && placedX == false)
        {
            if ((placedOs[6] && placedOs[7]) || (placedOs[2] && placedOs[5]) || (placedOs[0] && placedOs[4]))
            {
                X1 = GameObject.Instantiate(X);
                X1.transform.position = positions[8];
                placed[8] = true;
                placedXs[8] = true;
                placedX = true;
            }
        }
        return placedX;
    }

    bool checkWin()
    {
        bool win = false;

        if ((placedOs[0] == true && placedOs[1] == true && placedOs[2] == true) || (placedXs[0] == true && placedXs[1] == true && placedXs[2] == true))
        {
            win = true;
        }
        else if ((placedOs[3] == true && placedOs[4] == true && placedOs[5] == true) || (placedXs[3] == true && placedXs[4] == true && placedXs[5] == true))
        {
            win = true;
        }
        else if ((placedOs[6] == true && placedOs[7] == true && placedOs[8] == true) || (placedXs[6] == true && placedXs[7] == true && placedXs[8] == true))
        {
            win = true;
        }
        else if ((placedOs[0] == true && placedOs[3] == true && placedOs[6] == true) || (placedXs[0] == true && placedXs[3] == true && placedXs[6] == true))
        {
            win = true;
        }
        else if ((placedOs[1] == true && placedOs[4] == true && placedOs[7] == true) || (placedXs[1] == true && placedXs[4] == true && placedXs[7] == true))
        {
            win = true;
        }
        else if ((placedOs[2] == true && placedOs[5] == true && placedOs[8] == true) || (placedXs[2] == true && placedXs[5] == true && placedXs[8] == true))
        {
            win = true;
        }
        else if ((placedOs[0] == true && placedOs[4] == true && placedOs[8] == true) || (placedXs[0] == true && placedXs[4] == true && placedXs[8] == true))
        {
            win = true;
        }
        else if ((placedOs[2] == true && placedOs[4] == true && placedOs[6] == true) || (placedXs[2] == true && placedXs[4] == true && placedXs[6] == true))
        {
            win = true;
        }
        
        return win;
    }

    int getIndex(Vector3 pos)
    {
        int result = -1;
        if (location.x < 0 && location.y > 0 && placed[0] == false)
        {
            placed[0] = true;
            placedOs[0] = true;
            result = 0;
        }
        else if (location.x == 0 && location.y > 0 && placed[1] == false)
        {
            placed[1] = true;
            placedOs[1] = true;
            result = 1;
        }
        else if (location.x > 0 && location.y > 0 && placed[2] == false)
        {
            placed[2] = true;
            placedOs[2] = true;
            result = 2;
        }
        else if (location.x < 0 && location.y == 0 && placed[3] == false)
        {
            placed[3] = true;
            placedOs[3] = true;
            result = 3;
        }
        else if (location.x == 0 && location.y == 0 && placed[4] == false)
        {
            placed[4] = true;
            placedOs[4] = true;
            result = 4;
        }
        else if (location.x > 0 && location.y == 0 && placed[5] == false)
        {
            placed[5] = true;
            placedOs[5] = true;
            result = 5;
        }
        else if (location.x < 0 && location.y < 0 && placed[6] == false)
        {
            placed[6] = true;
            placedOs[6] = true;
            result = 6;
        }
        else if (location.x == 0 && location.y < 0 && placed[7] == false)
        {
            placed[7] = true;
            placedOs[7] = true;
            result = 7;
        }
        else if (location.x > 0 && location.y < 0 && placed[8] == false)
        {
            placed[8] = true;
            placedOs[8] = true;
            result = 8;
        }
        return result;
    }
}
