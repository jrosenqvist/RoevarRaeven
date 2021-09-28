using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public float timeToLive = 10f;
    public float speed;
    int direction;    
    void Start()
    {
        var player = GameObject.Find("Player");
        Destroy(gameObject, timeToLive);
        direction = player.GetComponent<SpriteRenderer>().flipX == true ? -1 : 1;        
    }

    // Update is called once per frame
    void Update()
    {        
        //transform.Translate()
        transform.Translate(direction * Time.deltaTime * speed, 0, 0);
    }

    void SelfDestruct() {
        Destroy(gameObject, 0.05f);
    }
}
