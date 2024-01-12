using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[Serializable]
public struct Item
{
    public Sprite icon;
    public int price;
    public string name;
    public AnimatorController associatedController;
}