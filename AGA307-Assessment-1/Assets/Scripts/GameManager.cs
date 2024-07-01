using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Gamestate gameState;
    public Difficulty difficulty;


    int scoreMultiplier = 1;
    public int score = 0;

    void Start()
    {
        gameState = Gamestate.start;
        difficulty = Difficulty.Easy;

        GameEvents.EnemyHit += OnEnemyHit;


        SetUp();
    }

    private void OnDestroy()
    {
        GameEvents.EnemyHit -= OnEnemyHit;

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

    void OnEnemyHit(Enemy e)
    {
        AddScore(10);
    }



    void Update()
    {
        
    }
    public void AddScore(int scoreAdd)
    {
        score += scoreAdd * scoreMultiplier;
    }
}
