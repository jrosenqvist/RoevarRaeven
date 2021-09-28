using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : Enemy
{
    Vector2 targetPosition;
    public float speed;
    public float timeToLive = 10f;
    
    void Start()
    {
        var player = GameObject.Find("Player");
        var playerPosition = player.transform.position;
        
        float distance = Vector2.Distance(playerPosition, transform.position);
        float distanceX = playerPosition.x - transform.position.x;
        float distanceY = playerPosition.y - transform.position.y;

        targetPosition = new Vector2(distanceX / distance, distanceY / distance);

        Destroy(gameObject, timeToLive);
    }
    
    void Update()
    {
        transform.Translate(targetPosition * Time.deltaTime * speed);    
    }

    void FireballSelfDestruct() {
        Destroy(gameObject, 0.05f);
    }
}
