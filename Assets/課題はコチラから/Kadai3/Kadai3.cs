using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kadai3 : MonoBehaviour
{
    private float _twinkTimer;
    private const float TWINK_TIME = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        _twinkTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // これまでの課題で実装したUpdate関数.
        UpdateCursor();
        UpdateTwink();
    }

    void UpdateCursor()
    {
        // キーボード操作に追従して、カーソルが移動する.
        bool isKeyDown = false;
        int newCursorIndex = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // 左矢印を押したらカーソルは左に移動.
            int currentCursorIndex = JJC_ShopUI.cursor.GetCurrentIndex();
            newCursorIndex = currentCursorIndex - 1;
            isKeyDown = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // 右矢印を押したらカーソルは右に移動.
            int currentCursorIndex = JJC_ShopUI.cursor.GetCurrentIndex();
            newCursorIndex = currentCursorIndex + 1;
            isKeyDown = true;
        }

        if (isKeyDown)
        {
            // メニューの中に項目が何個あるか、値を取得する.
            int menuItemNum = JJC_ShopUI.menu.GetMenuItemNum();
            // 剰余の計算を行うことで、カーソル位置の値は一定範囲内に収まる.
            int adjustNewCursorIndex = (newCursorIndex + menuItemNum) % menuItemNum;
            // 新しく計算した位置の情報を、UIに対して渡す.
            JJC_ShopUI.cursor.SetCurrentIndex(adjustNewCursorIndex);
        }
    }

    void UpdateTwink()
    {
        // カーソルを明滅させる.
        _twinkTimer += Time.deltaTime;

        float twinkRate = _twinkTimer / TWINK_TIME;
        float twinkRadian = twinkRate * Mathf.PI * 2;
        float colorRate = Mathf.Cos(twinkRadian);

        JJC_ShopUI.cursor.SetCursorColor(colorRate, 1.0f, 0.0f);

        if (_twinkTimer > TWINK_TIME)
        {
            _twinkTimer = 0.0f;
        }
    }
}
