using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{


    public override void UpdateCharacter()
    {
        UpdateInput();
        base.UpdateCharacter();
    }

    void UpdateInput()
    {
        if (InputManger.instance.IsMouseDown() )
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

        if (InputManger.instance.IsAttackButtonDown())
        {
            
            ChangeState(eState.Attack);
        }

    }
 
}
