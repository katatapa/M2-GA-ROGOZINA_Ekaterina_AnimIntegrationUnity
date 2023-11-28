using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAnimationHandler : MonoBehaviour
{
    private Animator animator;
    public List<AnimationKeys> keys = new List<AnimationKeys>();
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        foreach(var key in keys)
        {
            if (key.parameterType == TriggerType.Bool)
            {
                animator.SetBool(key.parameterName, Input.GetKey(key.keyCode));
            }
            else
            {
                if(Input.GetKeyDown(key.keyCode)) animator.SetTrigger(key.parameterName);
            }
        }
    }
}
[Serializable]
public struct AnimationKeys
{
    public string parameterName;
    public TriggerType parameterType;
    public KeyCode keyCode;
} 

public enum TriggerType
{
    Bool,
    Trigger
}