using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 Direction { get; private set; }
    public bool IsPlayerWalking => Direction.magnitude != 0;

    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D rb2d;

    private void Update()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rb2d.velocity = Direction * Time.deltaTime * _speed;
    }
}