using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{
    private PlayerInventory _inventory;
    [SerializeField] private ItemDatabase _itemDB;
    [SerializeField] private GameObject _itemViewerPrefab;
    [SerializeField] private RectTransform contentInventory;
    [SerializeField] private RectTransform contentStore;

    private bool hasCreatedShop = false;
    
    public void Initialize(Player player)
    {
        gameObject.SetActive(true);
        _inventory = player.Inventory;
        UpdateAndPopulateInventory();
        PopulateStore();
    }

    public void UpdateAndPopulateInventory()
    {
        foreach (Transform transform in contentInventory)
        {
            Destroy(transform.gameObject);
        }
        
        foreach (Item item in _inventory.items)
        {
            ItemViewer view = Instantiate(_itemViewerPrefab, contentInventory).GetComponent<ItemViewer>();
            view.Initialize(item, () => { OnSellClick(item);}, "Sell");
        }
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

    public void OnSellClick(Item item)
    {
        ShopManager.GetInstance().Sell(item, _inventory);
        UpdateAndPopulateInventory();
    }

    public void OnBuyClick(Item item)
    {
        if (ShopManager.GetInstance().TryBuy(item, _inventory))
        {
            UpdateAndPopulateInventory();
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
