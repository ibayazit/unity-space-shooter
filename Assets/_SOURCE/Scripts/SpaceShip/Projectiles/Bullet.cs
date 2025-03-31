using UnityEngine;

public class Bullet : CustomObjectPool<Bullet>
{
    private float speed = 5f;

    private void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * Vector3.up;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Block")){
            Release(this);
        }
    }
}
