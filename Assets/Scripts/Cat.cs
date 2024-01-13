using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Cat : Interactable
{
    [SerializeField] private CanvasGroup dialog;
    [SerializeField] private float fadeDuration;

    public override void Interact(Player player)
    {
        
    }

    public override void Approach(Player player)
    {
        dialog.alpha = 1.0f;
        dialog.DOFade(0.0f, fadeDuration).SetEase(Ease.InExpo);
    }
}
