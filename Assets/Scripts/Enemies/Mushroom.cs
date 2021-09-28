using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    GameObject player;
    public GameObject missile; 
    public float detectionDistance;
    public float fireRate;    
    float timePassed;
    SpriteRenderer spriteRenderer;
    public int health;
    void Start()
    {
        player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }    
    void Update()
    {
        var distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        if (distanceToPlayer < detectionDistance && timePassed > fireRate) 
            FireMissile();

        spriteRenderer.flipX = player.transform.position.x > transform.position.x ? false : true;
        
        timePassed += Time.deltaTime;
    }

    void OnDisable() {
        enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void FireMissile() {
        timePassed = 0;

        Instantiate(missile, transform.position, transform.rotation);
    }

    void DecreaseHealth() {
        if (--health <= 0) {
            BroadcastMessage("KillMe");            
        }
    }
}
