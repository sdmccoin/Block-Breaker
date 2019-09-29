using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    [SerializeField] int timesHit;

    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        timesHit = 0;
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
            DestroyBlock();
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {        
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlocksDestroyed();
        TriggerSparkleVFX();
    }

    private void PlayBlockDestroySFX()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);        
    }
    private void TriggerSparkleVFX()
    {
        GameObject sparkle = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, 1f);
    }
}
