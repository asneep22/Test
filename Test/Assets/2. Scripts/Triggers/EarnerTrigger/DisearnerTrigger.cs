using UnityEngine;

public class DisearnerTrigger : BaseTrigger
{
    [SerializeField, Min(0)] private int _disearn_count;
    public override void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Stager stager))
            return;

        stager.Substract(_disearn_count);
        Destroy(gameObject);
    }
}
