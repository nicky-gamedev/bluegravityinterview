using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory
{
    public int cash { get; private set; }
    public List<Item> items { get; private set; } = new List<Item>();

    public UnityEvent onBalanceChange = new();

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
        onBalanceChange?.Invoke();
    }

    public void SubtractCash(int amount)
    {
        cash -= amount;
        onBalanceChange?.Invoke();
    }

    public bool CanBuy(int amount)
    {
        return cash >= amount;
    }
}
