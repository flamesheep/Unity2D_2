using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rubyPosition = transform.position;
        rubyPosition.x = rubyPosition.x + Input.GetAxis("Horizontal") * moveSpeed;
        rubyPosition.y = rubyPosition.y + Input.GetAxis("Vertical") * moveSpeed;
        //transform.position = rubyMove;
        rb.MovePosition(rubyPosition);
    }
}
