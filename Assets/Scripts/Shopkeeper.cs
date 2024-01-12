using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : Interactable
{
    public ShopUIController shopUI;
    
    public override void Interact(Player player)
    {
        shopUI.Initialize(player);
    }
}
