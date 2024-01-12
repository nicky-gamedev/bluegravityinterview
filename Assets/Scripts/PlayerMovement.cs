using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 Direction { get; private set; }
    public bool IsPlayerWalking => Direction.magnitude != 0;

    [SerializeField] private float _speed;


    private void Update()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(Direction * Time.deltaTime * _speed);
    }
}