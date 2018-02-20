using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    void Start()
    {
        InitState();
    }

    public virtual void UpdateCharacter()
    {
        _stateList[_stateType].Update();
        UpdateChangeState();
    }

    void Update()
    {
        UpdateCharacter();
    }

    //State
    public enum eState
    {
        IDLE,
        MOVE,
    }
    
    protected eState _stateType = eState.IDLE;
    eState _nextStateType = eState.IDLE;

    protected Dictionary<eState, State> _stateList = new Dictionary<eState, State>();

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
    protected Vector3 _targetPosition = Vector3.zero;

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


    public void Rotate(Vector3 direction)
    {
        Quaternion characterTargetRay = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, characterTargetRay, 360.0f * Time.deltaTime);
    }

    public Quaternion getRotate()
    {
        return transform.rotation;
    }


    public GameObject characterVisual;


    public void SetAnimationTrigger(string Trigger)
    {
        characterVisual.GetComponent<Animator>().SetTrigger(Trigger);
    }

}
