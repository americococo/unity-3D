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


        if(Input.GetMouseButton(0))
        {
            if (eButtonState.UP == _buttonState)
                _buttonState = eButtonState.DOWN;
           else if (eButtonState.DOWN == _buttonState)
                _buttonState = eButtonState.HOLD;
        }
        if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }
    }

    bool _isMouseDown = false;

    enum eButtonState
    {
        DOWN,
        HOLD,
        UP,
    }

    eButtonState _buttonState = eButtonState.UP;

    void MouseDown()
    {
        //_isMouseDown = true;
        _buttonState = eButtonState.DOWN;
    }
    void MouseUp()
    {
        _buttonState = eButtonState.UP;
    }
    public bool IsMouseDown()
    {
        return (eButtonState.DOWN == _buttonState);
    }

    public Vector3 GetCursorPosition()
    {
        Vector3 position = Input.mousePosition;

        return position;
    }

}
