using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 movementSpeed = new Vector3(0,0,20);
    public Space space;
  
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }
}
