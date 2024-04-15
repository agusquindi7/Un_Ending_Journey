using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsaacCamera : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _currentPosY;
    private Vector3 _velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, _currentPosY, transform.position.z), ref _velocity, _speed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        _currentPosY = _newRoom.position.y;
    }
}
