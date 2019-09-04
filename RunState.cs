using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState:StateTemplate<PlayerCtrl>
{

    public RunState(int id, PlayerCtrl p) : base(id,p) {

    }

    public override void OnEnter(params object[] arg)
    {
        base.OnEnter(arg);
    }
    public override void OnStay(params object[] arg)
    {
        base.OnStay(arg);
    }

    public override void OnExit(params object[] arg)
    {
        base.OnExit(arg);
    }
}
