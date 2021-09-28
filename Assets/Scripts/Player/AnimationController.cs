using UnityEngine;

[RequireComponent(typeof(Controller2D))]
[RequireComponent(typeof(Player))]
public class AnimationController : MonoBehaviour
{
    Animator anim;
    Controller2D controller;
    Player player;
    SpriteRenderer sprite;
    bool onGround;
    Vector2 velocity;
    float lastPos;
    float velocityX;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<Controller2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();            
        lastPos = transform.position.x;
    }

    void Update()
    {
        onGround = controller.collisions.below;        
        velocity = player.velocity;        
        velocityX = transform.position.x - lastPos;
        lastPos = transform.position.x;
        UpdateAnimation();
    }
    void UpdateAnimation()
    {
        if (player.directionalInput.x != 0)
            sprite.flipX = player.directionalInput.x < 0;

        if (onGround)
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", false);

            if (Mathf.Abs(velocityX)  > 0.01) anim.SetBool("Run", true);
            //if (velocity.x != 0) anim.SetBool("Run", true);
            else anim.SetBool("Run", false);
        }
        else
        {
            anim.SetBool("Run", false);

            if (velocity.y > 0) anim.SetBool("Jumping", true);
            else
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Falling", true);
            }
        }

    }
}
