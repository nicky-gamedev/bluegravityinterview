using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(order = 0, fileName = "ItemDatabase", menuName = "Custom")]
public class ItemDatabase : ScriptableObject
{
    public List<Item> items;
}

[Serializable]
public struct Item
{
    public Sprite icon;
    public int price;
    public string name;
    public AnimatorController associatedController;
}