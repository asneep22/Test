using ButchersGames;
using UnityEngine;
using UnityEngine.Events;

public class LevelStartHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _on_handle = new();
    public UnityEvent OnHandle { get => _on_handle; }

    public void Start()
    {
        LevelManager.Default.OnLevelStarted += () => Handle();
    }

    private void Handle()
    {
        OnHandle?.Invoke();
    }
}
