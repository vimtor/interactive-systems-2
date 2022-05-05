using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;
    private bool _playing;

    void Start()
    {
        EventManager.LivesUpdated.Invoke(lives);
        
        EventManager.PlayerHitted.AddListener(HandlePlayerHitted);
        EventManager.SheepHaystacked.AddListener(HandleSheepHaystacked);
    }

    private void HandlePlayerHitted()
    {
        lives -= 1;
        EventManager.LivesUpdated.Invoke(lives);

        if (lives == 0)
        {
            EventManager.PlayerHitted.RemoveAllListeners();
            EventManager.SheepHaystacked.RemoveAllListeners();
            EventManager.GameFinished.Invoke(score);
        }
    }
    
    private void HandleSheepHaystacked()
    {
        score += 1;
        EventManager.ScoreUpdated.Invoke(score);
    }
}
