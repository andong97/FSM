using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState :StateTemplate<PlayerCtrl>
{
    public IdleState(int id, PlayerCtrl p) : base(id, p) {

    }

    public override void OnEnter(params object[] arg)
    {
        base.OnEnter(arg);
    }

    public override void OnExit(params object[] arg)
    {
        base.OnExit(arg);
    }
    public override void OnStay(params object[] arg)
    {
        base.OnStay(arg);
    }
}
