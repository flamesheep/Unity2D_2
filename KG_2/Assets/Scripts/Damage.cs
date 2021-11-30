using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerContorller rubyHurt = collision.GetComponent<PlayerContorller>();
        rubyHurt.ChangeHealth(-1);
    }
      
}
