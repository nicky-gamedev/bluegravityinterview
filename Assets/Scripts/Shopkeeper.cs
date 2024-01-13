using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : Interactable
{
    [SerializeField] private ShopUIController shopUI;
    [SerializeField] private Image dialog;
    [SerializeField] private float fadeDuration;
    
    public override void Interact(Player player)
    {
        shopUI.Initialize(player);
    }

    public override void Approach(Player player)
    {
        dialog.gameObject.SetActive(true);
        dialog.DOFade(0.0f, fadeDuration).onComplete += () =>
        {
            dialog.gameObject.SetActive(false);
        };
    }

}
