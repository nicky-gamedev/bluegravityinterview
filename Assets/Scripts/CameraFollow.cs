using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothTime;
    [SerializeField] private Transform _followTarget;
    [SerializeField] private Vector2 _offset;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 vel = new Vector3();
        Vector3 dest = new Vector3(_followTarget.position.x + _offset.x, _followTarget.position.y + _offset.y, this.transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, dest, ref vel, smoothTime);
    }
}
