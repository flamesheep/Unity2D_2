using UnityEngine;

public class Strawberry : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerContorller rubyEat = collision.GetComponent<PlayerContorller>();
        rubyEat.ChangeHealth(1);
        Destroy(gameObject);
    }
}
