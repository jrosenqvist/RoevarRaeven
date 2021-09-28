using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public int flashes = 3;
    public float flashFrequency = 0.1f;
    Color originalColor;
    AudioSource hitAudio;
    AudioSource dieAudio;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();        
        originalColor = spriteRenderer.color;

        hitAudio = GameObject.Find("EnemyHit").GetComponent<AudioSource>();
        dieAudio = GameObject.Find("EnemyDie").GetComponent<AudioSource>();
    }
    void EnemyApplyDamage()
    {        
        StartCoroutine("FlashSprite");
        BroadcastMessage("DecreaseHealth");
        hitAudio.Play();
    }

    IEnumerator FlashSprite()
    {
        for (int i = 0; i < flashes; i++)
        {
            yield return new WaitForSeconds(flashFrequency);

            if (i % 2 == 0) spriteRenderer.color = Color.red;
            else spriteRenderer.color = Color.white;
        }

        spriteRenderer.color = originalColor;
    }

    void KillMe() {
        dieAudio.Play();
        BroadcastMessage("OnDisable");
        spriteRenderer.color = Color.red;        
        Destroy(gameObject, 0.3f);
    }
}
