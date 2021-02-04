using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    [Header("Recourses")]
    [SerializeField] private SpriteRenderer instructionSpriteRenderer;
    [SerializeField] private List<Sprite> instructionSprites = new List<Sprite>();

    private int instructionIndex;

    private void Start()
    {
        EventManager.current.waveCompleted += SetNextInstruction;
    }

    private void SetNextInstruction()
    {
        if (instructionIndex >= instructionSprites.Count-1)
        {
            instructionIndex = 0;
        }
        else
        {
            instructionIndex++;
        }

        instructionSpriteRenderer.sprite = instructionSprites[instructionIndex];
    }
}
