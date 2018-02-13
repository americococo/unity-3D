using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManger
{
    private static InputManger _instance = null;
    public static InputManger instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InputManger();
                _instance.Init();
            }
            return _instance;
        }
    }

    void Init()
    {

    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }
    }

    bool _isMouseDown = false;

    void MouseDown()
    {
        _isMouseDown = true;
    }
    void MouseUp()
    {
        _isMouseDown = false;
    }
    public bool IsMouseDown()
    {
        return _isMouseDown;
    }

    public Vector3 GetCursorPosition()
    {
        Vector3 position = Input.mousePosition;

        return position;
    }

}
