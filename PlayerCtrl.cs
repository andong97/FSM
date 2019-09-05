using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用来控制StateMachine
/// </summary>
/// 

public enum PlayerState {
    None,
    Run,
    Idle,
    Atatck
}

public class PlayerCtrl : MonoBehaviour
{
    public PlayerState ps = PlayerState.Idle;

    public StateMachine machine;
    // Start is called before the first frame update
    void Start()
    {
        IdleState idle = new IdleState(1, this);
        RunState run = new RunState(2, this);
        AttackState attack = new AttackState(3,this);
        machine = new StateMachine(idle);
        machine.AddState(run);
        machine.AddState(attack);
    }

    // Update is called once per frame
    void Update()
    {
        InputSwitchState();
    }


    /// <summary>
    /// 按键输入改变状态
    /// </summary>
    private void InputSwitchState() {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            ps = PlayerState.Run;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            ps = PlayerState.Atatck;
        }
        else
        {
            ps = PlayerState.Idle;
        }
    }

    /// <summary>
    /// 切换状态
    /// </summary>
    private void UpdateState() {
        switch (ps) {
            case PlayerState.Run:
                machine.TranslateState(2);
                break;
            case PlayerState.Idle:
                machine.TranslateState(1);
                break;
            case PlayerState.Atatck:
                machine.TranslateState(3);
                break;
        }
    }

    /// <summary>
    /// 状态更新
    /// </summary>
    private void LateUpdate()
    {
        //如果当前状态与上一个状态一样，则不需要更新状态
        if (machine.m_prviousState == machine.m_currentState)
        {
            machine.Update();
        }//否则对状态进行更新
        else {
            UpdateState();
        }
    }
}
