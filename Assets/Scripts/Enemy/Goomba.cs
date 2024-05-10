using UnityEngine;

public class Goomba : MonoBehaviour
{
    public Sprite flatSprite;
    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if(player.starpower)
            {
                Hit();
                scoreManager.DefeatEnemy();
            }
            else if (collision.transform.DotTest(transform, Vector2.down))
            {
                Flatten();
            }
            else
            {
                player.Hit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            Hit();
            scoreManager.DefeatEnemy();
        }
    }
    private void Flatten()
    {
        GetComponent<Collider2D>().enabled = false;//vo hieu hoa va cham
        GetComponent<EntityMovement>().enabled = false;//vo hieu hoa chuyen dong
        GetComponent<AnimatedSprite>().enabled = false;//tat hoat anh
        GetComponent<SpriteRenderer>().sprite = flatSprite;
        Destroy(gameObject, 0.5f);//pha huy sau 0.5s
    }

    private void Hit()
    {
        GetComponent<AnimatedSprite>().enabled = false;//tat hoat anh di chuyen
        GetComponent<DeathAnimation>().enabled = true;// bat dau hoat anh chet
        Destroy(gameObject, 3f);
    }

   
}
