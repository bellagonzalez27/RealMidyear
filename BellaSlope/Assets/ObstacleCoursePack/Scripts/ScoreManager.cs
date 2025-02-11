using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Text ScoreText;
    public Text HighScoreText;
    public float scoreCount;
    public float highScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + scoreCount; 
        HighScoreText.text = "High Score: " + highScoreCount;
        
    }
}
