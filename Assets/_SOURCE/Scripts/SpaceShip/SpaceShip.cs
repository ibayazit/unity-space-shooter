using System;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction = InputManager.Instance.GamePlayMoveInput;
        Vector3 moveTo = new(direction.x, direction.y, 0);
        transform.position += speed * Time.deltaTime * moveTo;
    }
}
