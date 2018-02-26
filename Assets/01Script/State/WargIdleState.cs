using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WargIdleState : IdleState
{

    float _durationTime=0.0f;
    const float _patrolTime = 2.0f;

    override public void Update()
    {

        _durationTime += Time.deltaTime;

        if( _character.GetWaitMaxTime() <= _durationTime)
        {
            _durationTime = 0.0f;

            _character.Patrol();
        }

    }


}
