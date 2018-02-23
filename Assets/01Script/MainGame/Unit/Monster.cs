using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    public override void Init()
    {
        base.Init();
        _characterType = eCharacterType.MONSTER;
        _waitMaxTime = 2.0f;
    }

    override protected void InitState()
    {
        base.InitState();
        StateInit(eState.IDLE, new WargIdleState());
    }
}
