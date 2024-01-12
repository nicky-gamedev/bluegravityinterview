using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Animator[] _animators;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int PlayerXAxis = Animator.StringToHash("PlayerXAxis");
    private static readonly int PlayerYAxis = Animator.StringToHash("PlayerYAxis");

    private void LateUpdate()
    {
        foreach (Animator anim in _animators)
        {
            anim.SetBool(IsWalking, _player.Movement.IsPlayerWalking);
            if (_player.Movement.IsPlayerWalking)
            {
                anim.SetFloat(PlayerXAxis, _player.Movement.Direction.x);
                anim.SetFloat(PlayerYAxis, _player.Movement.Direction.y);
            }
        }
    }
}
