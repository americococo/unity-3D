﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum eCharacterType
    {
        MONSTER,
        PLAYER,
        NONE,
    }
    protected eCharacterType _characterType = eCharacterType.NONE;






    void Start()
    {
        Init(); 
    }


    virtual public void Init()
    {
        InitAttackInfo();
        DemageInfo();
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
        Attack,
        CHASE,
        PATROL
    }
    
    protected eState _stateType = eState.IDLE;
    eState _nextStateType = eState.IDLE;

    protected Dictionary<eState, State> _stateList = new Dictionary<eState, State>();

    virtual protected void InitState()
    {
        StateInit(eState.Attack, new AttackState());
        StateInit(eState.IDLE, new IdleState());
        StateInit(eState.MOVE, new MoveState());
        StateInit(eState.CHASE, new ChaseState());
        StateInit(eState.PATROL, new PatrolState());
    }

    virtual public void StopChase()
    {

    }
    protected void StateInit(eState estate, State state)
    {
        state.Init(this);
        _stateList.Add(estate, state);
    }

    public void ChangeState(eState stateType)
    {
        _nextStateType = stateType;
    }

    void UpdateChangeState()
    {
        if (_stateType != _nextStateType)
        {
            _stateList[_stateType].Stop();
            _stateType = _nextStateType;
            _stateList[_stateType].Start();

        }
    }



    //idle
    protected float _waitMaxTime = 2.0f;

    public float GetWaitMaxTime()
    {
        return _waitMaxTime;
    }
    

    public void Patrol()
    {
        ChangeState(eState.PATROL);
    }

    //Move

    protected float _speed=3.0f;

    public float getSpeed()
    {
        return _speed;
    }

    virtual public void ArriveDestination()
    {
        ChangeState(Character.eState.IDLE);
    }

    protected bool _IsMoveTargetPosition=false;
    protected Vector3 _targetPosition = Vector3.zero;
    protected GameObject _targetObject;

    public bool IsMoveTargetPosition()
    {
        return _IsMoveTargetPosition;
    }
    public void setMovePosition(bool setTargetPositon)
    {
        _IsMoveTargetPosition = setTargetPositon;
    }

    public GameObject getTarobject()
    {
        return _targetObject;
    }
    public void setTarobject(GameObject gameObject)
    {
        _targetObject = gameObject;
    }

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


    public AnimationPlayer Getanimation()
    {
        return characterVisual.GetComponent<AnimationPlayer>();
    }

    public void SetAnimationTrigger(string Trigger)
    {
        characterVisual.GetComponent<Animator>().SetTrigger(Trigger);
    }


    public eCharacterType getCharacterType()
    {
        return _characterType;
    }

    protected float _attackRange =0.8f;

    public float GetAttackRange()
    {
        return _attackRange;
    }

    AttackArea[] _attackAreas;

    void InitAttackInfo()
    {
        _attackAreas = GetComponentsInChildren<AttackArea>();
    }

    public void AttackStart()
    {
        for(int i=0;i<_attackAreas.Length;i++)
        {
            _attackAreas[i].Enable();
            
        }
    }

    public void AttackEnd()
    {
        for (int i = 0; i < _attackAreas.Length; i++)
        {
            _attackAreas[i].disable();
        }
    }

    virtual public bool IsSearchRange(float distance)
    {
        return true;
    }


    public void DemageInfo()
    {
        HitArea[] _HitAreas=GetComponentsInChildren<HitArea>();

        for(int i =0; i<_HitAreas.Length;i++)
        {
            _HitAreas[i].init(this);
        }

    }


}
