using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    private Text _text;
    
    void Start()
    {
        _text = GetComponent<Text>();
        
        EventManager.LivesUpdated.AddListener(HandleLivesUpdated);
    }

    private void HandleLivesUpdated(int lives)
    {
        _text.text = $"Lives: {lives}";
    }
}
