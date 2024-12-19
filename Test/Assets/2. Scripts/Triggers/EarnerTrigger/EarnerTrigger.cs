using UnityEngine;

public class EarnerTrigger : BaseTrigger
{
    [SerializeField, Min(0)] private int _earn_count;

    public override void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Stager stager))
            return;

        stager.Add(_earn_count);
        Destroy(gameObject);
    }
}
