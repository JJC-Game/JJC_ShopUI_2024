using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kadai_Complete : MonoBehaviour
{
    private float _twinkTimer;
    private const float TWINK_TIME = 3.0f;

    private Vector2[] menuItemPositionArray = null;

    // Start is called before the first frame update
    void Start()
    {
        _twinkTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // ����܂ł̉ۑ�Ŏ�������Update�֐�.
        UpdateCursor();
        UpdateTwink();
    }



    void OnCursorMove(int newCursorIndex)
    {
        // �J�[�\�����ړ������Ƃ��ɑ��鏈��.
        int menuItemNum = JJC_ShopUI.menu.GetMenuItemNum();
        if (menuItemPositionArray == null)
        {
            menuItemPositionArray = new Vector2[menuItemNum];

            for (int i = 0; i < menuItemNum; i++)
            {
                menuItemPositionArray[i] = JJC_ShopUI.menu.GetMenuItemPosition(i);
            }
        }

        for (int i = 0; i < menuItemNum; i++)
        {
            if (i == newCursorIndex)
            {
                Vector2 menuItemOffset = new Vector2(0, 50.0f);
                JJC_ShopUI.menu.SetMenuItemPosition(i, menuItemPositionArray[i] + menuItemOffset);
            }
            else
            {
                JJC_ShopUI.menu.SetMenuItemPosition(i, menuItemPositionArray[i]);
            }
        }

        // �V�����v�Z�����ʒu�̏����AUI�ɑ΂��ēn��.
        JJC_ShopUI.cursor.SetCurrentIndex(newCursorIndex);
    }

    void UpdateCursor()
    {
        // �L�[�{�[�h����ɒǏ]���āA�J�[�\�����ړ�����.
        bool isKeyDown = false;
        int newCursorIndex = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // ��������������J�[�\���͍��Ɉړ�.
            int currentCursorIndex = JJC_ShopUI.cursor.GetCurrentIndex();
            newCursorIndex = currentCursorIndex - 1;
            isKeyDown = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // �E������������J�[�\���͉E�Ɉړ�.
            int currentCursorIndex = JJC_ShopUI.cursor.GetCurrentIndex();
            newCursorIndex = currentCursorIndex + 1;
            isKeyDown = true;
        }

        if (isKeyDown)
        {
            // ���j���[�̒��ɍ��ڂ������邩�A�l���擾����.
            int menuItemNum = JJC_ShopUI.menu.GetMenuItemNum();
            // ��]�̌v�Z���s�����ƂŁA�J�[�\���ʒu�̒l�͈��͈͓��Ɏ��܂�.
            int adjustNewCursorIndex = (newCursorIndex + menuItemNum) % menuItemNum;

            // �J�[�\���ړ������Ƃ��ɌĂԊ֐�.
            OnCursorMove(adjustNewCursorIndex);
        }
    }

    void UpdateTwink()
    {
        // �J�[�\���𖾖ł�����.
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
