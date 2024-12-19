using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SideRotator : MonoBehaviour
{
    [SerializeField] private float _rotate_time = .2f;

    [SerializeField] private Vector3 _rotate_axis = Vector3.up;
    [SerializeField] private float rotationTime = .5f;
    [SerializeField] private float _rotation_degrees = 90;

    [SerializeField] private UnityEvent _on_ended = new();

    private bool _isRotating = false;
    private float _currentRotationTime = 0f;
    private Quaternion _startRotation;
    private Quaternion _targetRotation;


    public void Rotate()
    {
        if (_isRotating)
            return;
        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        _isRotating = true;
        _currentRotationTime = 0f;
        _startRotation = transform.rotation;
        _targetRotation = transform.rotation * Quaternion.Euler(_rotate_axis * _rotation_degrees);

        while (_currentRotationTime < rotationTime)
        {
            _currentRotationTime += Time.deltaTime;
            float t = Mathf.Clamp01(_currentRotationTime / rotationTime);
            transform.rotation = Quaternion.Lerp(_startRotation, _targetRotation, t);
            yield return null;
        }

        _on_ended?.Invoke();
        transform.localRotation = _startRotation * Quaternion.Euler(_rotate_axis * _rotation_degrees);
        _isRotating = false;

    }
}
