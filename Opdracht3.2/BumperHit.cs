using UnityEngine;
using System;

public class BumperHit : MonoBehaviour
{
    [SerializeField] private int scoreValue = 100;
    public int maxHits;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public static event Action<string, int> onBumperHit;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {
            onBumperHit?.Invoke(gameObject.tag, scoreValue);
            maxHits--;
            DarkenColor();

            if (maxHits <= 0)
            {
                Destroy(gameObject);
        }
    }
}
private void DarkenColor()
    {
        if (sr != null)
        {
            // Apply a darkening factor, e.g. 90% of previous brightness
            Color c = sr.color;
            sr.color = c * 0.9f; 
        }
    }
}