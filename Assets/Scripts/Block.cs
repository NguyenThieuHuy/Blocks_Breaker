using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    //Cached Ref
    Level level;
    GameState gameState;
    private void Start()
    {
        gameState = FindObjectOfType<GameState>();
        level = FindObjectOfType<Level>();
        level.countBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BreakBlock();
    }

    private void BreakBlock()
    {
        gameState.addToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.01f);
        Destroy(gameObject, 0.1f);
        level.destroyBreakableBlocks();
    }
}