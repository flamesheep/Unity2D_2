using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    private Vector2 lookDirection;
    private Vector2 rubyPosition;
    private Vector2 rubyMove;

    public float moveSpeed;

    private Rigidbody2D rb;
    private Animator rubyAnimator;
    
    public int maxHp = 5;
    [Range(0, 5)]
    public int currentHp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rubyAnimator = GetComponent<Animator>();

        currentHp = maxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rubyPosition = transform.position;

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rubyMove = new Vector2(moveX, moveY);
                
        if (!Mathf.Approximately(rubyMove.x, 0) || !Mathf.Approximately(rubyMove.y, 0))
        {
            lookDirection = rubyMove;
            lookDirection.Normalize();

        }

        rubyAnimator.SetFloat("Look X", lookDirection.x);
        rubyAnimator.SetFloat("Look Y", lookDirection.y);
        rubyAnimator.SetFloat("Speed", rubyMove.magnitude);

        //transform.position = rubyMove;
        rubyPosition = rubyPosition + moveSpeed * rubyMove * Time.deltaTime;
        rb.MovePosition(rubyPosition);

        if(currentHp == 0)
        {
            Application.LoadLevel("Scnce1");
        }

        
        
    }

    public void ChangeHealth(int amount)
    {
        currentHp = Mathf.Clamp(currentHp + amount, 0, 5);
        print(currentHp);

    }
}
