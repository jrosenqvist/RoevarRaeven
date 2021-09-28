using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRainSpawner : MonoBehaviour
{
    public FireRain rain;
    private Vector2 initialPos;
    public float time;
    public int fireballs;
    public float moveDistance;    
    public float timeBetweenBalls;
    private float distanceBetweenBalls;
    private float countdown;
    private bool goBack;

    void Start()
    {
        initialPos = transform.position;
        timeBetweenBalls = time / fireballs;
        countdown = timeBetweenBalls;
        distanceBetweenBalls = moveDistance / fireballs;
    }

    void Update()
    {
        countdown -= Time.deltaTime;        

        if (transform.position.x > initialPos.x + moveDistance)
        {
            transform.position = initialPos;            
            countdown = timeBetweenBalls;
            gameObject.SetActive(false);
        }

        if (countdown <= 0)
        {
            transform.position = new Vector2(transform.position.x + distanceBetweenBalls, transform.position.y);
            Instantiate(rain, transform.position, transform.rotation);
            countdown = timeBetweenBalls;
        }


    }
}

