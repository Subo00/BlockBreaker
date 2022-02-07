using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    //configure parameters
    [SerializeField] private AudioClip[] _breakSounds;
    [SerializeField] private GameObject  _breakVFX;
    [SerializeField] private int _maxHits = 1;
    [SerializeField] private int _scoreToAdd = 5;
    [SerializeField] Sprite[] hitSprits;
    
    //cached reference
    Level level;
    ObjectPooler objectPooler;

    //State variables
    [SerializeField] private int _timesHit = 0;
    private void Awake()
    {
        level = FindObjectOfType<Level>();
        if(tag == "Breakable")
        level.CountBreakableBlocks();

        objectPooler = FindObjectOfType<ObjectPooler>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HitHandle();
        }
    }

    private void HitHandle()
    {
        _timesHit++;
        if (_timesHit >= _maxHits)
            DestroyBlock();
        else
            ShowNextHitSprite();
    }

    private void ShowNextHitSprite()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprits[_timesHit-1];
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(_breakSounds[UnityEngine.Random.Range(0,_breakSounds.Length)], 
                                    Camera.main.transform.position, 1f);
        level.BlockDestroyed();

        for(int i = 0; i < _scoreToAdd; i++)
        {
            objectPooler.SpawnFromPool("Gold", transform.position, transform.rotation);
        }
        TriggerBreakVFX(); 
        Destroy(gameObject);
    }

    private void TriggerBreakVFX()
    {
        GameObject sparkles = Instantiate(_breakVFX, transform.position, transform.rotation);
        Destroy(sparkles,2f);
    }
}
