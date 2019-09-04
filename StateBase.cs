public class StateBase
{
    public int ID { get; set; }

    public StateMachine machine;

    public StateBase(int id) {
        this.ID = id;
    }
    public virtual void OnEnter(params object[] arg) { }
    public virtual void OnStay(params object[] arg) { }
    public virtual void OnExit(params object[] arg) { }
}
