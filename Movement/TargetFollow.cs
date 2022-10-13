using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;  // rotation speed
    [SerializeField] private float _moveSpeed;      // move speed
    [SerializeField] private Transform _target;     // target to look and follow
    
    private Vector3 _relativePos;                   // direction to look at
    Quaternion _rotation;                           // the supplied rotation value

    // using fixed update for collision detection
    void FixedUpdate()
    {
        Rotation();
        Movement();
    }
    private void Rotation()
    {
        // distance between the objects
        _relativePos = _target.position - transform.position;
        // the second argument, upwards, defaults to Vector3.up
        _rotation = Quaternion.LookRotation(_relativePos, Vector3.up);
        // smoothing the rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, _rotationSpeed * Time.deltaTime);
    }
    private void Movement()
    {
        // simple movement
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
    }
}
