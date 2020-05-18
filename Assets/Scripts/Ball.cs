using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public Vector2 Direction;
    public float Speed;

    private void Update()
    {
        transform.position += new Vector3(Direction.x, Direction.y) * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEnter");
        if (collision.contactCount < 0)
            return;
        Direction = Vector3.Reflect(Direction, collision.contacts[0].normal);
    }
}
