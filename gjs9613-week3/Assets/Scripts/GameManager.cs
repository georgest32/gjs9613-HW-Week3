using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public Text text;
    const string DIR_LOGS = "/Logs";
    const string FILE_SCORES = DIR_LOGS + "/highScore.txt";
    const string FILE_ALL_SCORES = DIR_LOGS + "/allScores.csv";
    string FILE_PATH_HIGH_SCORES;
    string FILE_PATH_ALL_SCORES;
    
    public int Score
    {
        get { return score; }
        set
        {
            score = value;

            if (score > HighScore)
            {
                HighScore = score;
            }

            //Don't need to write all scores
            
            // string fileContents = "";
            // if (File.Exists(FILE_PATH_ALL_SCORES))
            // {
            //     fileContents = File.ReadAllText(FILE_PATH_ALL_SCORES);
            // }
            //
            // fileContents += score + ",";
            // File.WriteAllText(FILE_PATH_ALL_SCORES, fileContents);
        }
    }
    
    int highScore = -1;

    public int HighScore
    {
        get
        {
            if (highScore < 0)
            {
                if (File.Exists(FILE_PATH_HIGH_SCORES))
                {
                    string fileContents = File.ReadAllText(FILE_PATH_HIGH_SCORES);
                    highScore = Int32.Parse(fileContents);
                }
                else
                {
                    highScore = 3;
                }
            }

            return highScore;
        }
        set
        {
            Debug.Log("New High Score!");
            highScore = value;
            
            if (!File.Exists(FILE_PATH_HIGH_SCORES))
            {
                Directory.CreateDirectory(Application.dataPath + DIR_LOGS);
            }

            File.WriteAllText(FILE_PATH_HIGH_SCORES, highScore + "");
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        FILE_PATH_HIGH_SCORES = Application.dataPath + FILE_SCORES;
        FILE_PATH_ALL_SCORES  = Application.dataPath + FILE_ALL_SCORES;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "SCORE: " + score +
                    "\nHIGH SCORE: " + HighScore;
    }
}
