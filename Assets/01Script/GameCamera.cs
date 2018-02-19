using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

   

    // Update is called once per frame
    void Update()
    {
        if(null != _lookTarget)
        {
            Vector3 startLookPosition = _lookTarget.Getposition() + _offset;
            Vector3 relativePos = Quaternion.Euler(_verticalAngle, horizonalAngle, 0) * new Vector3(0, 0, -_distance);//캐릭터에 대한 상대적 거리
            transform.position = startLookPosition + relativePos;
            
            Vector3 EndlookPosition = _lookTarget.Getposition() + _offset;
            transform.LookAt(EndlookPosition);
        }
    }

    


    public Character _lookTarget=null;
    Vector3 _offset =new Vector3(0,1.5f,0);
    float _verticalAngle = 10.0f;
    float horizonalAngle = 0.0f;
    float _distance =5.0f;

    
}
