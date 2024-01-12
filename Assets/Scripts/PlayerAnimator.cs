using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Animator[] _animators;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int PlayerXAxis = Animator.StringToHash("PlayerXAxis");
    private static readonly int PlayerYAxis = Animator.StringToHash("PlayerYAxis");

    private void LateUpdate()
    {
        foreach (Animator anim in _animators)
        {
            anim.SetBool(IsWalking, _playerMovement.IsPlayerWalking);
            if (_playerMovement.IsPlayerWalking)
            {
                anim.SetFloat(PlayerXAxis, _playerMovement.MovementDirection.x);
                anim.SetFloat(PlayerYAxis, _playerMovement.MovementDirection.y);
            }
        }
    }
}
