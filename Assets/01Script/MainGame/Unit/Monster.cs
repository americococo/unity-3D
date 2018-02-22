using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    public override void Init()
    {
        base.Init();
        _characterType = eCharacterType.MONSTER;
    }
}
