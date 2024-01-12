using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 MovementDirection { get; private set; }
    public bool IsPlayerWalking => MovementDirection.magnitude != 0;

    [SerializeField] private float _speed;


    private void Update()
    {
        MovementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(MovementDirection * Time.deltaTime * _speed);
    }
}