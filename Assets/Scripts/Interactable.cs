using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual void Interact(Player player){}
    
    public virtual void Approach(Player player){}
}