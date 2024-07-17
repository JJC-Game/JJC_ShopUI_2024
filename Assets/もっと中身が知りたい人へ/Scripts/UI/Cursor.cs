using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
    }

    public void SetCurrentIndex(int index)
    {
        RectTransform rectTrans = transform as RectTransform;
        rectTrans.anchoredPosition = JJC_ShopUI.menu.GetCursorPosition(index);
        currentIndex = index;
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public void SetCursorTwinkRate(float rate)
    {

    }

    public void SetCursorColor(float r, float g, float b, float a = 1.0f)
    {
        Image image = GetComponent<Image>();
        image.color = new Color(r, g, b, a);
    }
}
