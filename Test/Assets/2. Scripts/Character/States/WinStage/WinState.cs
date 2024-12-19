
public class WinState : BaseState
{
    private void Awake()
    {
        OnEntered.AddListener(() => UIManager.Instance.WinUI.Enable());
    }

    public override BaseState StateUpdate()
    {
        return this;
    }
}
