using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class BaseTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _on_entered;
    public UnityEvent OnEntered { get => _on_entered; }


    private BoxCollider _box_collider;

    void Start()
    {
        _box_collider = GetComponent<BoxCollider>();
        _box_collider.isTrigger = true;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        OnEntered?.Invoke();
    }

    private void OnDrawGizmos()
    {
       if (_box_collider == null) 
            _box_collider = GetComponent<BoxCollider>();

        Gizmos.color = new Color(0,1,0,0.5f);
        Matrix4x4 oldMatrix = Gizmos.matrix;
        Gizmos.matrix = transform.localToWorldMatrix;

        Vector3 center = _box_collider.center;
        Vector3 size = _box_collider.size;

        Gizmos.DrawCube(center, size);
        Gizmos.matrix = oldMatrix;
    }
}
