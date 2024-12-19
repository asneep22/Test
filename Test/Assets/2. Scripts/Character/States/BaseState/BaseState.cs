using UnityEngine;
using UnityEngine.Events;

public class BaseState : MonoBehaviour
{
    private Player _player;

    [SerializeField] private UnityEvent _on_entered = new();
    [SerializeField] private UnityEvent _on_exited = new();

    public UnityEvent OnEntered
    {
        get => _on_entered;
    }

    public UnityEvent OnExited
    {
        get => _on_exited;
    }



    public Player Player
    {
        get
        {
            return _player;
        }
        set
        {
            _player = _player == null ? value : _player;
        }
    }

    public virtual BaseState StateUpdate()
    {
        throw new System.NotImplementedException();
    }
}
