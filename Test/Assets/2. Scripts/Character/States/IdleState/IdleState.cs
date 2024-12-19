using ButchersGames;
using UnityEngine;

public class IdleState : BaseState
{
    [SerializeField] private BaseState _moveState;
    private bool _is_activated;

    private void Awake()
    {
        OnExited.AddListener(() => UIManager.Instance.StartUI.Disable());
        OnExited.AddListener(() => UIManager.Instance.GameUI.Enable());
    }

    public override BaseState StateUpdate()
    {

        if (_is_activated)
            return _moveState;

        return this;
    }


    private void OnMouseDown()
    {
        _is_activated = true;
    }
}
