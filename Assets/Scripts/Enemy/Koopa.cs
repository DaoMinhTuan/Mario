using UnityEngine;

public class Koopa : MonoBehaviour
{
    public Sprite shellSprite;
    public float shellSpeed = 12f;

    private bool shelled;
    private bool pushed;

    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!shelled && collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.starpower)
            {
                Hit();
                scoreManager.DefeatEnemy();
            }
            else if (collision.transform.DotTest(transform, Vector2.down))
            {
                EnterShell();
            }
            else
            {
                player.Hit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(shelled && other.CompareTag("Player"))
        {
            if(!pushed)
            {
                Vector2 direction = new Vector2(transform.position.x - other.transform.position.x, 0f);
                PushShell(direction);
            }
            else
            {
                Player player = other.GetComponent<Player>();

                if (player.starpower)
                {
                    Hit();
                    scoreManager.DefeatEnemy();
                }
                else
                {
                    player.Hit();
                    scoreManager.DefeatEnemy();
                }
            }
        }else if(!shelled && other.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            Hit();
            scoreManager.DefeatEnemy();
        }
    }

    private void EnterShell()
    {
        shelled = true;
        GetComponent<EntityMovement>().enabled = false;//vo hieu hoa chuyen dong
        GetComponent<AnimatedSprite>().enabled = false;//tat hoat anh
        GetComponent<SpriteRenderer>().sprite = shellSprite;
    }

    private void PushShell(Vector2 direction)
    {
        pushed = true;

        GetComponent<Rigidbody2D>().isKinematic = false;

        EntityMovement movement = GetComponent<EntityMovement>();
        movement.direction = direction.normalized;
        movement.speed = shellSpeed;
        movement.enabled = true;

        gameObject.layer = LayerMask.NameToLayer("Shell");
    }
    private void Hit()
    {
        GetComponent<AnimatedSprite>().enabled = false;//tat hoat anh di chuyen
        GetComponent<DeathAnimation>().enabled = true;// bat dau hoat anh chet
        Destroy(gameObject, 3f);
    }

    private void OnBecameInvisible()
    {
        if (pushed)
        {
            Destroy(gameObject);
        }
    }
}
