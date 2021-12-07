using UnityEngine;

public class RobotGo : MonoBehaviour
{
    public int speed = 5;
    private Rigidbody2D rb;
    public bool isVertical;
    public int direction = 1;

    public float walkTime = 3;
    private float timer;

    public Animator robotAnimator;

    public bool broken = true;

    public ParticleSystem smokeEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = walkTime;
        robotAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            return;
        }

        timer = timer - Time.deltaTime;

        if (timer <= 0)
        {
            direction = -direction;
            timer = walkTime;
        }

        Vector2 robotPosition = transform.position;

        if (isVertical)
        {
            robotPosition.y = robotPosition.y + speed * Time.deltaTime * direction;
        }
        else 
        {
            robotPosition.x = robotPosition.x + speed * Time.deltaTime * direction;
        }
        rb.MovePosition(robotPosition);
        PlayMoveAnimation();
        
    }

    private void PlayMoveAnimation()
    {
        if (isVertical)
        {
            robotAnimator.SetFloat("MoveX", 0);
            robotAnimator.SetFloat("MoveY", direction);
        }
        else
        {
            robotAnimator.SetFloat("MoveX", direction);
            robotAnimator.SetFloat("MoveY", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerContorller playerContorller = collision.gameObject.GetComponent<PlayerContorller>();
        if (playerContorller != null)
        {
            playerContorller.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rb.simulated = false;

        robotAnimator.SetTrigger("Fixed");

        smokeEffect.Stop();
    }
}
