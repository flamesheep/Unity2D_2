using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    private Vector2 lookDirection;
    private Vector2 rubyPosition;
    private Vector2 rubyMove;

    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator rubyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rubyAnimator = GetComponent<Animator>();
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
    }
}
