using UnityEngine;

public class Strawberry : MonoBehaviour
{
    public GameObject pickEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(pickEffect, gameObject.transform.position,
                Quaternion.identity);

        PlayerContorller rubyEat = collision.GetComponent<PlayerContorller>();
        rubyEat.ChangeHealth(1);
        Destroy(gameObject);

    }
}
