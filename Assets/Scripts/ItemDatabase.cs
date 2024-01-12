using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 0, fileName = "ItemDatabase", menuName = "Custom/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<Item> items;
}