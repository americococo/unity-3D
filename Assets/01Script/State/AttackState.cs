using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    override public void Start()
    {
        //_character.SetAnimationTrigger("Attack");
        _character.Getanimation().play("Attack", null,
         () =>
         {
             //Midile1
             //충돌체 킴
             _character.AttackStart();
         },

        () =>
        {
            //Midile2
            //충돌체 끔
            _character.AttackEnd();
        },

        () =>
         {
             //end
             //isCombo = false;
             _character.ChangeState(Character.eState.IDLE);
         });
    }

    public override void Update()
    {

    }

    //public override void UpdateInput()
    //{
    //    //combo Attack 처리
    //}

}
