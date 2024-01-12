using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{
    private PlayerInventory _inventory;
    [SerializeField] private ItemDatabase _itemDB;
    [SerializeField] private ItemViewer _itemViewerPrefab;
    [SerializeField] private RectTransform contentInventory;
    [SerializeField] private RectTransform contentStore;

    private bool hasCreatedShop = false;
    
    public void Initialize(Player player)
    {
        gameObject.SetActive(true);
        _inventory = player.Inventory;
        PopulateInventory();
        PopulateStore();
    }

    public void PopulateInventory()
    {
        foreach (Item item in _inventory.items)
        {
            ItemViewer view = Instantiate(_itemViewerPrefab.gameObject, contentInventory).GetComponent<ItemViewer>();
            view.Initialize(item, () => { OnSellClick(item);});
        }
    }

    private void PopulateStore()
    {
        if(hasCreatedShop) return;
        foreach (Item item in _inventory.items)
        {
            ItemViewer view = Instantiate(_itemViewerPrefab.gameObject, contentStore).GetComponent<ItemViewer>();
            view.Initialize(item, () => { OnBuyClick(item);});
        }

        hasCreatedShop = true;
    }

    public void OnSellClick(Item item)
    {
        ShopManager.GetInstance().Sell(item, _inventory);
    }

    public void OnBuyClick(Item item)
    {
        ShopManager.GetInstance().TryBuy(item, _inventory);
    }

    public void Close()
    {
        foreach (Transform transform in contentInventory)
        {
            Destroy(transform.gameObject);
        }
        gameObject.SetActive(false);
    }
}
