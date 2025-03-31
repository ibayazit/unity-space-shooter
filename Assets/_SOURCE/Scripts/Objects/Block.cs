using TMPro;
using UnityEngine;

public class Block : CustomObjectPool<Block>, IDamageable
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private SpriteRenderer blockRenderer;

    [HideInInspector] public int Health { get; set; }

    private float speed = 1f;

    private void Start()
    {
        Health = Random.Range(1, 4);

        UpdateUI();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.isGamePaused)
        {
            UpdateUI();
            Move();
        }
    }

    private void UpdateUI()
    {
        healthText.text = Health.ToString();
        blockRenderer.color = GenerateColorByHealth(Health);
    }

    private void Move()
    {
        transform.position += speed * Time.deltaTime * Vector3.down;
    }

    private Color GenerateColorByHealth(int health)
    {
        if (health > 0 && health <= 5)
        {
            return Color.green;
        }
        if (health > 5 && health <= 10)
        {
            return Color.yellow;
        }

        return Color.red;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Projectile")){
            Damage(1);
        }
    }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;

        if(Health <= 0){
            Die();
        }
    }

    public void Die()
    {
        Release(this);
    }
}
