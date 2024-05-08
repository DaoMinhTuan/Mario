using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    private PlayerMove movement;

    public Sprite idle;
    public Sprite jump;
    public Sprite slide;
    public AnimatedSprite run;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMove>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
        run.enabled = false;//tat hoat anh chay
    }
    private void LateUpdate()
    {
        run.enabled = movement.running;
        if (movement.jumping) {
            spriteRenderer.sprite = jump;
        }else if (movement.sliding) {
            spriteRenderer.sprite = slide;
        }else if(!movement.running)
        {
            spriteRenderer.sprite = idle;
        }
    }
}
