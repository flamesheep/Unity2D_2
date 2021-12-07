using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bulletDis;

    public ParticleSystem hitEffect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletDis = transform.position.magnitude;
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RobotGo robotGo = collision.gameObject.GetComponent<RobotGo>();
        if (robotGo != null)
        {
            robotGo.Fix();
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    void Update()
    {
        if (transform.position.magnitude > 100)
        {
            Destroy(gameObject);
        }
    }
}
