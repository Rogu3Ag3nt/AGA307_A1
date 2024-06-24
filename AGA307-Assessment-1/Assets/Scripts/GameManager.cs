using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Gamestate gameState;
    public Difficulty difficulty;
    int scoreMultiplier = 1;


    void Start()
    {
        gameState = Gamestate.start;
        difficulty = Difficulty.Easy;


        SetUp();
    }

    void SetUp()
    {
        switch(difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplier = 1;
                break;
            case Difficulty.Medium:    
                scoreMultiplier = 2; 
                break;
            case Difficulty.Hard: 
                scoreMultiplier = 3;  
                break;
            default: scoreMultiplier = 1; 
                break;
        }
    }
    void Update()
    {
        
    }
}
