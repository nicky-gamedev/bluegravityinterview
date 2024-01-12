using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private List<Interactable> _interactablesInArea = new List<Interactable>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Interactable interactable in _interactablesInArea)
            {
                interactable.Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Interactable interactable))
        {
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