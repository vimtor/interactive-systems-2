using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent<int> LivesUpdated = new UnityEvent<int>();
    public static UnityEvent<int> ScoreUpdated = new UnityEvent<int>();
    public static UnityEvent SheepHaystacked = new UnityEvent();
    public static UnityEvent PlayerHitted = new UnityEvent();
    public static UnityEvent<int> GameFinished = new UnityEvent<int>();
}