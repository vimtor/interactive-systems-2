using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private Text _text;
    
    void Start()
    {
        _text = GetComponent<Text>();
        
        EventManager.ScoreUpdated.AddListener(HandleScoreUpdated);
    }

    private void HandleScoreUpdated(int score)
    {
        _text.text = $"Score: {score}";
    }
}
