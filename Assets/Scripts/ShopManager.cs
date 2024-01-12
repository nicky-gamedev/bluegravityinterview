using UnityEngine;

public class ShopManager 
{
    public void Buy(Item item, PlayerInventory inventory)
    {
        if (!inventory.CanBuy(item.price)) return;
        inventory.AddItem(item);
        inventory.SubtractCash(item.price);
    }

    public void Sell(Item item, PlayerInventory inventory)
    {
        inventory.DeleteItem(item);
        inventory.AddCash(item.price);
    }
}