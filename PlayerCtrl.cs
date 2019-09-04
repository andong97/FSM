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
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0) {
            ps = PlayerState.Run;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            ps = PlayerState.Atatck;
        }
        else {
            ps = PlayerState.Idle;
        }
        //切换状态
        UpdateState();
    }

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
    /// 
    /// </summary>
    private void LateUpdate()
    {
        machine.Update();
    }
}
