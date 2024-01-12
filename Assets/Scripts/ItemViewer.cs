using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Button _button;
    
    public void Initialize(Item item, UnityAction onClick)
    {
        _icon.sprite = item.icon;
        _name.text = item.name;
        _price.text = item.price.ToString();
        _button.onClick.AddListener(onClick);
    }
}
