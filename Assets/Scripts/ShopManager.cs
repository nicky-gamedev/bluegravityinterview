using UnityEngine;

public class ShopManager 
{
    public ShopManager()
    {
        
    }
    
    private static ShopManager _instance;
    
    public static ShopManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ShopManager();
        }
        return _instance;
    }
    
    public bool TryBuy(Item item, PlayerInventory inventory)
    {
        if (!inventory.CanBuy(item.price)) return false;
        inventory.AddItem(item);
        inventory.SubtractCash(item.price);
        return true;
    }

    public void Sell(Item item, PlayerInventory inventory)
    {
        inventory.DeleteItem(item);
        inventory.AddCash(item.price);
    }
}