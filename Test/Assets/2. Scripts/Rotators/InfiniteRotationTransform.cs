using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRotationTransform : MonoBehaviour
{
    public Vector3 rotationSpeed = new(0, 50f, 0);

    void Update() => transform.Rotate(rotationSpeed * Time.deltaTime);
}
