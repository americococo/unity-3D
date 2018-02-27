using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    public override void Init()
    {
        _attackRange = 2.0f;
        _speed = 1.5f;
        base.Init();
        _characterType = eCharacterType.MONSTER;
        _waitMaxTime = 2.0f;
    }

    override protected void InitState()
    {
        base.InitState();
        State wargeState = new WargIdleState();
        wargeState.Init(this);
        _stateList[eState.IDLE] = wargeState;

    }

    public List<WayPoint> _wayPointList;
    int _wayPointIndex;

    public override void ArriveDestination()
    {
        WayPoint wayPoint = _wayPointList[_wayPointIndex];
        _wayPointIndex= (_wayPointIndex +1) % _wayPointList.Count;
        _targetPosition = wayPoint.getPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(LayerMask.NameToLayer("characterCtr") ==other.gameObject.layer)
        {
            Character character = other.GetComponent<Character>();

            if (eCharacterType.PLAYER == character.getCharacterType())
            {
                Debug.Log("Check" + character);
                _targetObject = other.gameObject;
                ChangeState(eState.CHASE);
                Debug.Log(3);
            }
        }
    }
}
