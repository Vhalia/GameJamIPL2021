using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine finiteStateMachine;
    protected Entity entity;

    //determines when the entity enter this state
    protected float startTime;

    protected string animatorBooleanName;

    public State(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName)
    {
        this.finiteStateMachine = finiteStateMachine;
        this.entity = entity;
        this.animatorBooleanName = animatorBooleanName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.Animator.SetBool(animatorBooleanName, true);
    }

    public virtual void Exit()
    {
        entity.Animator.SetBool(animatorBooleanName, false);

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }


}