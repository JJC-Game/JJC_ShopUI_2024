using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJC_ShopUI : MonoBehaviour
{
    private void Awake()
    {
        S = this;
    }
    static private JJC_ShopUI _S;
    static private JJC_ShopUI S
    {
        get
        {
            if (_S == null)
            {
                return null;
            }
            return _S;
        }
        set
        {
            if (_S != null)
            {
                Debug.LogError("_Sは既に設定されています.");
            }
            _S = value;
        }
    }

    private ItemFixDataManager _itemFixDataManager;
    static public ItemFixDataManager itemFixDataManager
    {
        get
        {
            if (S != null)
            {
                if (S._itemFixDataManager == null)
                {
                    S._itemFixDataManager = GameObject.Find("GameManager").GetComponent<ItemFixDataManager>();
                }
                return S._itemFixDataManager;
            }
            return null;
        }
    }

    private Menu _menu;
    static public Menu menu
    {
        get
        {
            if (S != null)
            {
                if (S._menu == null)
                {
                    S._menu = GameObject.Find("Menu").GetComponent<Menu>();
                }
                return S._menu;
            }
            return null;
        }
    }

    private Cursor _cursor;
    static public Cursor cursor
    {
        get
        {
            if (S != null)
            {
                if (S._cursor == null)
                {
                    S._cursor = GameObject.Find("Cursor").GetComponent<Cursor>();
                }
                return S._cursor;
            }
            return null;
        }
    }
}
