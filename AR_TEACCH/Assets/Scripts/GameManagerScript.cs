using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int objectCorrect = 0;
    public int totalObjects = 0;
    void Start()
    {
        totalObjects = GameObject.FindGameObjectsWithTag("PecaPuzzle").Length;
    }

    public void IncrementObjectCorrect()
    {
        objectCorrect++;
        CheckWin();
    }

    public void DecrementObjectCorrect()
    {
        objectCorrect--;
    }

    public void CheckWin()
    {
        if (objectCorrect == totalObjects)
        {
            Debug.Log("Venceu");
        }
    }

    void Update()
    {

    }
}
