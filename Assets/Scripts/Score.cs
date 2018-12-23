using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void plus(int points)
    {
        score += points;
        text.text = "Score: " + score;
    }

    public void minus(int points)
    {
        score -= points;
        text.text = "Score: " + score;
    }
}
