using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    System.Action _beginCallBack = null;
    System.Action _preMidiCallBack = null;
    System.Action _afterCallBack = null;
    System.Action _endCallBack = null;
    

    public void play(string triggerName, 
        System.Action beginCallBack,
        System.Action preMidiCallBack,
        System.Action afterCallBack,
        System.Action endCallBack)
    {
        gameObject.GetComponent<Animator>().SetTrigger(triggerName);

        _beginCallBack = beginCallBack;
        _preMidiCallBack = preMidiCallBack;
        _afterCallBack = afterCallBack;
        _endCallBack = endCallBack;
    }

    public void onBeginEvent()
    {
       
        if (null != _beginCallBack)
        {
            _beginCallBack();
        }
    }

    public void onPreMidiEvent()
    {
       
        if (null != _preMidiCallBack)
        {
            _preMidiCallBack();
        }
    }

    public void onAfterEvent()
    {
      
        if (null != _afterCallBack)
        {
            _afterCallBack();
        }
    }


    public void OnEndEvent()
    {
       
        if(null !=_endCallBack)
        {
            _endCallBack();
        }
    }

}
