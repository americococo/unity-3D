using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
        Character _character;
    public Character getCharacter()
    {
        return _character;
    }


    public void init(Character character)
    {
        _character = character;
    }
}
