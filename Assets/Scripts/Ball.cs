using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour
{
    public Vector2 Direction;
    public float Speed;

    private void Update()
    {
        if (Game.IsPaused)
            return;

        transform.position += new Vector3(Direction.x, Direction.y).normalized * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contactCount < 0)
            return;
        Direction = Vector3.Reflect(Direction, collision.contacts[0].normal);
    }
}
