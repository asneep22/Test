using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BaseState _current_state;
    [SerializeField] private BaseState _death_state;
    [SerializeField] private BaseState _win_state;

    private void Update()
    {
        BaseState state = _current_state.StateUpdate();

        if (state != _current_state)
            ChangeState(state);
    }

    private void ChangeState(BaseState new_state)
    {
        _current_state.OnExited?.Invoke();
        _current_state = new_state;
        _current_state.OnEntered?.Invoke();
    }

    public void Death()
    {
        ChangeState(_death_state);
    }

    public void Win()
    {
        ChangeState(_win_state);
    }
}
