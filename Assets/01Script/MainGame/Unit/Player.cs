using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public override void Init()
    {
        _speed = 6.0f;
        base.Init();
        _characterType = eCharacterType.PLAYER;
    }

    public override void UpdateCharacter()
    {
        UpdateInput();
        base.UpdateCharacter();
    }

    void UpdateInput()
    {
        if (InputManger.instance.IsMouseDown())
        {
            Vector3 mousePosition;

            mousePosition = InputManger.instance.GetCursorPosition();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            RaycastHit hitInfo;
            LayerMask layerMask = (1 << LayerMask.NameToLayer("Ground")) | (1 << LayerMask.NameToLayer("Character"));

            if (Physics.Raycast(ray, out hitInfo, 100.0f, layerMask))
            {
                if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    _targetPosition = hitInfo.point;
                    
                    _stateList[_stateType].UpdateInput();
                }
                else if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Character"))
                {
                    HitArea hitArea = hitInfo.collider.gameObject.GetComponent<HitArea>();
                    Character character = hitArea.getCharacter();

                    switch (character.getCharacterType())
                    {
                        case eCharacterType.MONSTER:
                            //_targetPosition = hitInfo.collider.gameObject.transform.position;
                            _targetObject = hitInfo.collider.gameObject;
                            ChangeState(eState.CHASE);
                            break;

                    }

                }
            }
        }

        if (InputManger.instance.IsAttackButtonDown())
        {
            ChangeState(eState.Attack);
        }

    }

}
