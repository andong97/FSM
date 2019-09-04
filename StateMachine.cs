using System.Collections;
using System.Collections.Generic;

public class StateMachine 
{
    //用于存储所有的状态
    public Dictionary<int, StateBase> m_machine;
    public StateBase m_prviousState;
    //保存当前状态
    public StateBase m_currentState;

    public StateMachine(StateBase beginState) {
        m_prviousState = null;
        m_currentState = beginState;

        //初始化状态字典
        m_machine = new Dictionary<int, StateBase>();
        AddState(beginState);
        m_currentState.OnEnter();
    }

    /// <summary>
    /// 将不在字典中的状态加到字典中去
    /// </summary>
    /// <param name="state">添加状态</param>
    public void AddState(StateBase state) {
        if (!m_machine.ContainsKey(state.ID)) {
            m_machine.Add(state.ID, state);
            state.machine = this;
        } 
    }

    /// <summary>
    /// 状态切换
    /// </summary>
    /// <param name="id">切换到的状态ID</param>
    public void TranslateState(int id) {
        if (!m_machine.ContainsKey(id)) {
            return;
        }
        //状态的转换
        m_prviousState = m_currentState;
        m_currentState = m_machine[id];
        m_currentState.OnEnter();
    }

    /// <summary>
    /// 保持当前状态
    /// </summary>
    public void Update() {
        if (m_currentState != null) {
            m_currentState.OnStay();
        }
    }
}
