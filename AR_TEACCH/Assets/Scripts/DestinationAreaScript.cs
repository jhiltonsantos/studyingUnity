using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationAreaScript : MonoBehaviour
{
    public string objectCorrectTag = "PuzzlePiece";
    private void OnTriggerEnter(Collider otherObject)
    {
        DraggableObject draggableObject = otherObject.GetComponent<DraggableObject>();
        if (draggableObject != null && draggableObject.isBeingDragged)
        {
            GameManagerScript gameManager = FindObjectOfType<GameManagerScript>();
            if (gameManager != null)
            {
                gameManager.IncrementObjectCorrect();
            }
        }
    }

}
