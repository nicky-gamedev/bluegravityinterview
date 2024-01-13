using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInventoryUIController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private RectTransform _contentInventory;
    [SerializeField] private GameObject _itemViewerPrefab;

    private bool _sellingMode;

    public void Initialize(Player player, bool sellingMode)
    {
        gameObject.SetActive(true);
        _player = player;
        UpdateInventory(sellingMode);
        _sellingMode = sellingMode;
    }

    public void ToggleEquipMode(Player player)
    {
        if (!gameObject.activeSelf && !_sellingMode)
        {
            Initialize(player, false);
        }
        else if(!_sellingMode)
        {
            Close();
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
        _sellingMode = false;
    }

    public void UpdateInventory(bool sellingMode)
    {
        foreach (Transform transform in _contentInventory)
        {
            Destroy(transform.gameObject);
        }
        
        if(sellingMode) PopulateInventoryForSelling();
        else PopulateInventoryForEquipment();
    }

    public void PopulateInventoryForEquipment()
    {
        foreach (Item item in _player.Inventory.items)
        {
            ItemViewer view = Instantiate(_itemViewerPrefab, _contentInventory).GetComponent<ItemViewer>();
            view.Initialize(item, () => { EquipItem(item); }, "Equip");
        }
    }

    public void PopulateInventoryForSelling()
    {
        foreach (Item item in _player.Inventory.items)
        {
            ItemViewer view = Instantiate(_itemViewerPrefab, _contentInventory).GetComponent<ItemViewer>();
            view.Initialize(item, () => { OnSellClick(item); }, "Sell");
        }
    }

    public void EquipItem(Item item)
    {
        _player.Animator.SwapAnimatorController(item);
    }
    
    public void OnSellClick(Item item)
    {
        ShopManager.GetInstance().Sell(item, _player.Inventory);
        UpdateInventory(true);
    }
}
