using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{
    private PlayerInventory _inventory;
    [SerializeField] private ItemDatabase _itemDB;
    [SerializeField] private GameObject _itemViewerPrefab;
    [SerializeField] private PlayerInventoryUIController _playerInventoryUI;
    [SerializeField] private RectTransform contentInventory;
    [SerializeField] private RectTransform contentStore;

    private bool hasCreatedShop = false;
    
    public void Initialize(Player player)
    {
        gameObject.SetActive(true);
        _inventory = player.Inventory;
        _playerInventoryUI.Initialize(player, true);
        PopulateStore();
    }

    private void PopulateStore()
    {
        if(hasCreatedShop) return;
        foreach (Item item in _itemDB.items)
        {
            ItemViewer view = Instantiate(_itemViewerPrefab.gameObject, contentStore).GetComponent<ItemViewer>();
            view.Initialize(item, () => { OnBuyClick(item);}, "Buy");
        }

        hasCreatedShop = true;
    }



    public void OnBuyClick(Item item)
    {
        if (ShopManager.GetInstance().TryBuy(item, _inventory))
        {
            _playerInventoryUI.UpdateInventory(true);
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
        _playerInventoryUI.Close();
    }
}
