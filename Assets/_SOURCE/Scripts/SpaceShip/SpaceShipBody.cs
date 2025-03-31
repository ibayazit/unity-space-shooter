using UnityEngine;

public class SpaceShipBody : MonoBehaviour, IDamageable
{
    public int Health { get; set; } = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Die();
        }
    }

    public void Damage(int damageAmount)
    {
        // noop
    }

    public void Die()
    {
        Debug.Log("You Died");
    }
}
