using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Animator[] _animators;
    [SerializeField] private SpriteRenderer[] _renderers;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int PlayerXAxis = Animator.StringToHash("PlayerXAxis");
    private static readonly int PlayerYAxis = Animator.StringToHash("PlayerYAxis");

    private void LateUpdate()
    {
        foreach (Animator anim in _animators)
        {
            if (anim.runtimeAnimatorController == null) continue;
            anim.SetBool(IsWalking, _player.Movement.IsPlayerWalking);
            if (_player.Movement.IsPlayerWalking)
            {
                anim.SetFloat(PlayerXAxis, _player.Movement.Direction.x);
                anim.SetFloat(PlayerYAxis, _player.Movement.Direction.y);
            }
        }
    }

    public void SwapAnimatorController(Item item)
    {
        _animators[(int)item.type].runtimeAnimatorController = item.associatedController;
        _animators[(int)item.type].SetFloat(PlayerXAxis, _animators[0].GetFloat(PlayerXAxis));
        _animators[(int)item.type].SetFloat(PlayerYAxis, _animators[0].GetFloat(PlayerYAxis));
    }

    public void DeleteAnimator(ItemType type)
    {
        _animators[(int)type].runtimeAnimatorController = null;
        _renderers[(int)type].sprite = null;
    }
}
