using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishText : MonoBehaviour
{
    private Text _text;
    
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "";
        
        EventManager.GameFinished.AddListener(HandleGameFinished);
    }

    private void HandleGameFinished(int score)
    {
        _text.text = $"Game Finished\nScore: {score}";
    }
}
