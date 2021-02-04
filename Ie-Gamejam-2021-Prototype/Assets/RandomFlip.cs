using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlip : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;

    void Start()
    {
        if (Random.Range(0, 2) == 1)
        {
            renderer.flipX = true;
        }
    }
}
