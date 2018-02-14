using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        InitState();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        
        _stateList[_stateType].Update();
        UpdateChangeState();
    }

    void UpdateInput()
    {
        if (InputManger.instance.IsMouseDown())
        {
            Vector3 mousePosition;

            mousePosition = InputManger.instance.GetCursorPosition();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100.0f, 1 << LayerMask.NameToLayer("Ground")))
            {
                _targetPosition = hitInfo.point;
                _stateList[_stateType].UpdateInput();

            }

        }
    }
    //State
    public enum eState
    {
        IDLE,
        MOVE,
    }

   

    eState _stateType = eState.IDLE;
    eState _nextStateType = eState.IDLE;

    Dictionary<eState,State> _stateList = new Dictionary<eState, State>();

    void InitState()
    {
        State idleState = new IdleState();
        State moveState = new MoveState();

        idleState.Init(this);
        moveState.Init(this);

        _stateList.Add(eState.IDLE, idleState);
        _stateList.Add(eState.MOVE, moveState);
    }


    public void ChangeState(eState stateType)
    {
        _nextStateType = stateType;
    }
    
    void UpdateChangeState()
    {
        if (_stateType != _nextStateType)
        {
            _stateType = _nextStateType;
            _stateList[_stateType].Start();

        }
    }

    //Move
    Vector3 _targetPosition = Vector3.zero;

    public Vector3 GetTargetPosition()
    {
        return _targetPosition;
    }

    public bool isGrounded()
    {
        return gameObject.GetComponent<CharacterController>().isGrounded;
    }

    public Vector3 Getposition()
    {
        return transform.position;
    }

    public void Move(Vector3 velocity)
    {
        gameObject.GetComponent<CharacterController>().Move(velocity);
    }
}
