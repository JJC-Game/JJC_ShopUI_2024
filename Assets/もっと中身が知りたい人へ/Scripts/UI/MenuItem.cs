using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuItem : MonoBehaviour
{
    Image itemIcon;
    Text itemNameText;
    Text itemValueText;
    // Start is called before the first frame update
    void Awake()
    {
        itemIcon = transform.Find("ItemIcon").GetComponent<Image>();
        itemNameText = transform.Find("TopRect/ItemNameText").GetComponent<Text>();
        itemValueText = transform.Find("BottomRect/ItemValueText").GetComponent<Text>();
    }

    public void SetItemData(ItemFixData itemFixData)
    {
        itemIcon.sprite = itemFixData._iconSprite;
        itemNameText.text = itemFixData._name;
        itemValueText.text = itemFixData._value.ToString();
    }
}
