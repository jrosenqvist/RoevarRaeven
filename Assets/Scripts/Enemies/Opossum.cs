using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Enemy
{
    public int health;
    public int speed;
    public float detectionDistance;
    bool active;
    GameObject player;
    float oldPosX;
    void Start()
    {
        active = false;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        oldPosX = transform.position.x;
        var distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        if (distanceToPlayer < detectionDistance) active = true;
        
        if (active)
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            
            // Destroy if stuck
            if (transform.position.x - oldPosX > 0) Destroy(gameObject, 0.01f);
            
            // Always remove object after certain time anyway
            Destroy(gameObject, 30f);            
        }

        
    }

    void OnDisable()
    {
        enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }

    void DecreaseHealth() {
        if (--health <= 0)
            BroadcastMessage("KillMe");
    }

}
