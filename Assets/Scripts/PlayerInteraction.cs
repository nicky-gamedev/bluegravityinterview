using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Interactable> _interactablesInArea = new List<Interactable>();
    [SerializeField] private PlayerInventoryUIController _inventoryUIController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Interactable interactable in _interactablesInArea)
            {
                interactable.Interact(_player);
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryUIController.ToggleEquipMode(_player);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Interactable interactable))
        {
            interactable.Approach(_player);
            _interactablesInArea.Add(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Interactable interactable))
        {
            _interactablesInArea.Remove(interactable);
        }
    }
}