using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInventory Inventory;
    public PlayerAnimator Animator;
    public PlayerMovement Movement;
    public PlayerInteraction Interaction;

    private void Awake()
    {
        Inventory = new PlayerInventory();
        Inventory.AddCash(100);
    }
}