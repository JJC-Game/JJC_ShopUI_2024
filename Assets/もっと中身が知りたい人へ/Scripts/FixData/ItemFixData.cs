using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemFixData
{
    public int _id;                     // アイテムのID.
    public string _name;                // アイテムの名前.
    public string _description;         // アイテムの説明文.
    public string _iconPath;            // アイテムのアイコン画像があるパス.
    public Sprite _iconSprite;          // アイコン画像.
    public int _value;                  // アイテムの価格.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(string name, string desc)
    {
        _name = name;
        _description = desc;
    }
}
