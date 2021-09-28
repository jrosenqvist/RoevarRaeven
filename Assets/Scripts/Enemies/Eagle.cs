using UnityEngine;

public class Eagle : Enemy
{    
    Vector2 movement;
    public float oscillationAmplitude;
    public float oscillationFrequency;
    public float movementSpeed;
    public float initialY;        
    private bool goingUp;
    public int health;
    public float detectionDistance;
    GameObject player;
    bool active;
    void Start()
    {
        player = GameObject.Find("Player");
        active = false;
        goingUp = true;
        initialY = transform.position.y;
    }
    
    void Update()
    {
        var distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        if (distanceToPlayer < detectionDistance) active = true;
        if (active)
        {
            UpdatePosition();
            Destroy(gameObject, 30f);
        }
    }

    void OnDisable() {
        enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void UpdatePosition() {
        movement.x = -movementSpeed;        
        float position = transform.position.y;

        if (goingUp) {
            if (position + oscillationFrequency < oscillationAmplitude + initialY)
                movement.y = oscillationFrequency;
            else {
                goingUp = false;
                movement.y = -oscillationFrequency;
            }
        } else {
            if (position - oscillationFrequency > initialY - oscillationAmplitude)
                movement.y = -oscillationFrequency;
            else {
                goingUp = true;
                movement.y = oscillationFrequency;
            }
        }
        
        transform.Translate(movement * Time.deltaTime * 60);
    }

    void DecreaseHealth() {
        if (--health <= 0)
            BroadcastMessage("KillMe");
    }
}
