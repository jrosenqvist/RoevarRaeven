using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss : MonoBehaviour
{
    public PolygonCollider2D outerCollider;
    public BoxCollider2D innerCollider;
    private float fadeTimer;
    public float fadeInTime;
    public float movementSpeed;
    GameObject player;
    private SpriteRenderer spriteRenderer;
    private State state;
    private int direction;
    public int health;
    private bool invincible;
    private float stateChangeTimer;
    public AudioSource plingSound;
    public AudioSource explosionSound;
    public Sprite spriteNormal;
    public Sprite spriteRain;
    public Sprite spriteShoot;
    private Vector2 targetPosition;
    public GameObject rainSpawner;
    private float shootCountdown;
    private bool setToShoot;
    public GameObject bossShot;    
    private bool dead;    
    public GameObject levelExit;
    public GameObject bossMusic;

    private void Start()
    {
        dead = false;        
        stateChangeTimer = Random.Range(10, 21);
        invincible = true;
        player = GameObject.Find("Player");
        state = State.Normal;
        direction = -1;
        fadeTimer = fadeInTime;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (fadeTimer > 0)
        {
            fadeTimer -= Time.deltaTime;
            if (!dead)
                spriteRenderer.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(0, 0, 0, 0), fadeTimer / fadeInTime);            
             else if (dead) {
                spriteRenderer.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(1, 1, 1, 1), fadeTimer / (fadeInTime * 2));                
            }
        }
        else
        {
            if (dead) return;                

            stateChangeTimer -= Time.deltaTime;
            if (stateChangeTimer < 0)
            {
                stateChangeTimer = Random.Range(15, 25);
                switch (state)
                {
                    case State.Normal:
                        state = State.Rain;
                        rainSpawner.SetActive(true);
                        spriteRenderer.sprite = spriteRain;
                        targetPosition = transform.position;
                        targetPosition.y += 5;
                        stateChangeTimer = 10f;
                        break;
                    case State.Rain:
                        state = State.Shoot;
                        spriteRenderer.sprite = spriteNormal;
                        shootCountdown = Random.Range(4, 10);
                        setToShoot = false;
                        break;
                    case State.Shoot:
                        state = State.Normal;
                        spriteRenderer.sprite = spriteNormal;
                        break;
                }
            }            

            if (state != State.Rain)
                spriteRenderer.flipX = player.transform.position.x - transform.position.x > 0 ? true : false;

            switch (state)
            {
                case State.Normal:
                    NormalRoutine(); break;
                case State.Rain:
                    RainRoutine(); break;
                case State.Shoot:
                    ShootRoutine(); break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerMissile"))
        {
            if (innerCollider.bounds.Intersects(other.bounds) && !invincible)
            {
                BroadcastMessage("EnemyApplyDamage", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                plingSound.Play();
            }
        }
        if (other.CompareTag("Player") && fadeTimer <= 0 && !dead)
        {
            other.BroadcastMessage("PlayerApplyDamage");
        }
    }

    void DecreaseHealth()
    {
        if (!dead)
        {
            health--;
            if (health <= 0)
            {                
                dead = true;
                fadeTimer = fadeInTime * 2;
                Destroy(gameObject, fadeInTime * 2);
                InvokeRepeating("PlayExplosion", 0, 0.5f);
                Invoke("ShowExit", fadeInTime * 1.9f);
                BroadcastMessage("EnemyApplyDamage", SendMessageOptions.DontRequireReceiver);                
            }
        }
    }

    void PlayExplosion() {
        explosionSound.Play();
        bossMusic.GetComponent<AudioSource>().Stop();
    }

    void ShowExit() {
        levelExit.SetActive(true);
    }

    private void FollowPlayer()
    {
        invincible = false;
        Vector2 playerPosition = player.transform.position;

        float distance = Vector2.Distance(playerPosition, transform.position);
        float distanceX = playerPosition.x - transform.position.x;
        float distanceY = playerPosition.y - transform.position.y + 1.5f;

        targetPosition = new Vector2(distanceX / distance, distanceY / distance);
        Vector2 movement = new Vector2(direction, 0);

        transform.Translate(targetPosition * Time.deltaTime * movementSpeed);
    }

    private void NormalRoutine()
    {
        FollowPlayer();
    }

    private void RainRoutine()
    {
        invincible = true;

        float distance = Vector2.Distance(targetPosition, transform.position);
        float distanceY = targetPosition.y - transform.position.y;
        if (targetPosition.y > transform.position.y)
        {
            targetPosition = new Vector2(0, distanceY / distance);
            transform.Translate(targetPosition * Time.deltaTime * movementSpeed);
        }
    }

    private void ShootRoutine()
    {
        shootCountdown -= Time.deltaTime;

        if (shootCountdown < 0)
        {
            if (setToShoot)
            {
                Instantiate(bossShot, transform.position, transform.rotation);
                setToShoot = false;
                shootCountdown = Random.Range(4, 10);
                spriteRenderer.sprite = spriteNormal;
            }
            else
            {
                spriteRenderer.sprite = spriteShoot;
                setToShoot = true;
                shootCountdown = 1;
            }

        }
        else
        {
            FollowPlayer();
        }
    }

    enum State
    {
        Normal,
        Rain,
        Shoot
    }
}
