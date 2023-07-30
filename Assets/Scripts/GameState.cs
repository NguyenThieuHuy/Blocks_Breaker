using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    //Config Param
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointPerBlock = 97;
    [SerializeField] TextMeshProUGUI ScoreText;
    //State
    [SerializeField] int currentScore;

    //Awake
    private void Awake()
    {
        int gameStateCount = FindObjectsOfType<GameState>().Length;
        if(gameStateCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //Start
    private void Start()
    {
        ScoreText.text = currentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void addToScore()
    {
        currentScore = currentScore+pointPerBlock;
        ScoreText.text = currentScore.ToString();
    }

}
