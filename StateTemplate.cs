public class StateTemplate<T>: StateBase
{
    public T owner;
    public StateTemplate(int id, T o) : base(id) {
        owner = o;
    }
}
