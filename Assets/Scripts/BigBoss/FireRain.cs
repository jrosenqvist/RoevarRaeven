using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRain : Enemy
{
    public float speed;
    
    private void Start() {
        Destroy(gameObject, 10f);
    }
    void Update()
    {
        transform.Translate(new Vector2(0, -1) * Time.deltaTime * speed);
    }

    void FireballSelfDestruct() {
        Destroy(gameObject, 0.05f);
    }
}
