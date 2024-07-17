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
        // ����܂ł̉ۑ�Ŏ�������Update�֐�.
        UpdateCursor();
        UpdateTwink();
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
            // �V�����v�Z�����ʒu�̏����AUI�ɑ΂��ēn��.
            JJC_ShopUI.cursor.SetCurrentIndex(adjustNewCursorIndex);
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
