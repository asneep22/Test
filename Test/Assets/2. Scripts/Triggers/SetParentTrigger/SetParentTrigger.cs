using UnityEngine;

public class SetParentTrigger : BaseTrigger
{
    [SerializeField] private Transform _new_parent;
    private Transform _other;
    private Transform _prev_parent;

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        _other = other.transform;
        _prev_parent = other.transform.parent;
        other.transform.SetParent(_new_parent);
    }

    public void ResetParent()
    {
        _other.SetParent(_prev_parent);
    }
}
