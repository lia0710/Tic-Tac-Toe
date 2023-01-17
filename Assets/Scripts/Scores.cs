using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public static Scores instance;

    public TMP_Text oScoretext;
    public TMP_Text xScoretext;

    public int oscore = 0;
    public int xscore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        oScoretext.text = "O" + "\n\n" + oscore.ToString();
        xScoretext.text = "X" + "\n\n" + xscore.ToString();
    }
    
    public void UpdateOPoints()
    {
        oscore++;
        oScoretext.text = "O" + "\n\n" + oscore.ToString();
    }

    public void UpdateXPoints()
    {
        xscore++;
        xScoretext.text = "X" + "\n\n" + xscore.ToString();
    }
}
