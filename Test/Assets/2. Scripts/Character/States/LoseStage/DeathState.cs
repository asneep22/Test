public class DeathState : BaseState
{
    private void Awake()
    {
        OnEntered.AddListener(() => UIManager.Instance.LoseUI.Enable());
    }

    public override BaseState StateUpdate()
    {
        return this;
    }
}
