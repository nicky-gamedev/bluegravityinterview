using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryUIController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private RectTransform contentInventory;
    [SerializeField] private GameObject _itemViewerPrefab;

    public void Initialize(Player player, bool sellingMode)
    {
        gameObject.SetActive(true);
        _player = player;
        UpdateInventory(sellingMode);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void UpdateInventory(bool sellingMode)
    {
        foreach (Transform transform in contentInventory)
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
            ItemViewer view = Instantiate(_itemViewerPrefab, contentInventory).GetComponent<ItemViewer>();
            view.Initialize(item, () => { EquipItem(item); }, "Equip");
        }
    }

    public void PopulateInventoryForSelling()
    {
        foreach (Item item in _player.Inventory.items)
        {
            ItemViewer view = Instantiate(_itemViewerPrefab, contentInventory).GetComponent<ItemViewer>();
            view.Initialize(item, () => { OnSellClick(item); }, "Sell");
        }
    }

    public void EquipItem(Item item)
    {
        
    }
    
    public void OnSellClick(Item item)
    {
        ShopManager.GetInstance().Sell(item, _player.Inventory);
        UpdateInventory(true);
    }
}
