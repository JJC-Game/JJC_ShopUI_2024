using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public int menuNum;
    public GameObject menuItemPrefab;

    private void Awake()
    {
        menuItemPrefab = Resources.Load<GameObject>("Prefabs/MenuItem");
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < JJC_ShopUI.itemFixDataManager.GetFixDataNum(); i++)
        {
            ItemFixData itemFixData = JJC_ShopUI.itemFixDataManager.GetFixData(i);
            GameObject instanceObj = Instantiate(menuItemPrefab);
            instanceObj.transform.SetParent(this.transform);
            instanceObj.GetComponent<MenuItem>().SetItemData(itemFixData);
        }

        // LayoutGroupの座標計算をこのフレーム内に終わらせる.
        LayoutGroup layoutGroup = this.GetComponent<LayoutGroup>();
        layoutGroup.CalculateLayoutInputHorizontal();
        layoutGroup.CalculateLayoutInputVertical();
        layoutGroup.SetLayoutHorizontal();
        layoutGroup.SetLayoutVertical();

        JJC_ShopUI.cursor.SetCurrentIndex(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMenuItemNum()
    {
        return transform.childCount;
    }

    public Vector2 GetCursorPosition(int index)
    {
        Vector3 diffVec = new Vector3(0.0f, 0.0f, 0.0f);
        RectTransform rectTrans = transform.GetChild(index).transform as RectTransform;

        Vector3 screenCenter = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f);
        Vector2 pos = transform.GetChild(index).transform.position + diffVec - screenCenter;
        return pos;
    }
}
