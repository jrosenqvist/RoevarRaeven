using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(GameState))]
public class Damage : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public int flashes;
    public float flashFrequency;
    Color originalColor;    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;        
    }

    void PlayerApplyDamage()
    {        
        StartCoroutine("FlashSprite");
        if (GameState.DecHealth() <= 0) {
            PlayerDeath();
        }
    }

    void HealthPickup() {
        Debug.Log("Health up");
        GameState.IncHealth();
    }

    void PlayerDeath() {
        Debug.Log("Dead!");        
        GameState.ResetLevel();
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
}
