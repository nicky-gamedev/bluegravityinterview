using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    public int cash { get; private set; }
    private List<Item> items;

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void DeleteItem(Item item)
    {
        Item removed = items.Find(i => i.name == item.name);
        items.Remove(removed);
    }

    public void AddCash(int amount)
    {
        cash += amount;
    }

    public void SubtractCash(int amount)
    {
        cash -= amount;
    }

    public bool CanBuy(int amount)
    {
        return cash >= amount;
    }
}
