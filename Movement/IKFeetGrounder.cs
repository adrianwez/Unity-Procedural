using UnityEngine;
// a basic script for the Animation Rigging's Target IK
//  to check if the feet is touching the ground
public class IKFeetGrounder : MonoBehaviour
{
    [SerializeField] private Transform _body;
    [SerializeField] private float _feetPading;
    [Tooltip("Distance from the ground to the feet.")]
    [SerializeField] private float _maxDistance;
    [Tooltip("Distance to trigger a step.")]
    [SerializeField] private float _stepDistance;
    [SerializeField] private LayerMask _ground;
    private Vector3 _newPosition;
    
    [SerializeField] private float _gizmoRadius = .1f;
    private void Update()
    {
        Ray _ray = new(_body.position + (_body.right * _feetPading), Vector3.down);
        if(Physics.Raycast(_ray, out RaycastHit _hit, _maxDistance, _ground))
        {
            if(Vector3.Distance(_newPosition, _hit.point) > _stepDistance)
                _newPosition = _hit.point;
        }
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_newPosition, _gizmoRadius);
    }
}