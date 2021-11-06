
public class FiniteStateMachine
{
    public State CurrentState { get; private set; }

    /**
     * Set the initial state when the game starts
     */
    public void Initialize(State startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(State newState)
    {
        CurrentState.Exit();
        Debug.Log(CurrentState + " -> " + newState);
        CurrentState = newState;
        CurrentState.Enter();
    }
}
