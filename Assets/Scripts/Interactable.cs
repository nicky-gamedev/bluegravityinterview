using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact(Player player);

    public abstract void Approach(Player player);
}