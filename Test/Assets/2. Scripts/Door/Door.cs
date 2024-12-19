using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Door : MonoBehaviour
{
    [SerializeField] private int _stage = 1;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.enabled = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Stager stager))
            return;

        if (stager.CurrentStageIndex + 1 >= _stage)
        {
            Open();
            return;
        }

        other.GetComponent<Player>().Win();

    }
}
