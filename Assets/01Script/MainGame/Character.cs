using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        _destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(InputManger.instance.IsMouseDown())
        {
            Vector3 mousePosition;

            mousePosition =InputManger.instance.GetCursorPosition();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100.0f, 1 << LayerMask.NameToLayer("Ground")))
            {
                //이동
                MoveStart(hitInfo.point);
            }
            UpdateMove();
        }

    }
    Vector3 _destination;

    //character Move
    void MoveStart(Vector3 destination)
    {
        //목적지 세팅
        _destination = destination;
    }

    Vector3 _velocity = Vector3.zero;

    void UpdateMove()
    {
        Vector3 direction = (_destination - transform.position).normalized;

        _velocity = direction * 6.0f;

        Vector3 snapGround = Vector3.zero;
        if (gameObject.GetComponent<CharacterController>().isGrounded)
            snapGround = Vector3.down;
        
        //목적지와 현재 위치가 일정 거리 이상이면 이동
        float distance = Vector3.Distance(_destination, transform.position);

        if(0.5f<distance)
        {
            gameObject.GetComponent<CharacterController>().Move(_velocity * Time.deltaTime + snapGround);
        }
        //목적지가까이 왔으면 도착
        //현재속도 보관
        
    }
}
