using UnityEngine;
// a script that generates multiple objects in a form of trail
public class TrailEffect : MonoBehaviour
{
    [SerializeField] private int _length;                       // size of segment trail
    [SerializeField] private float _trailSpeed;

    [SerializeField] private LineRenderer _rend;                // trail effect

    [SerializeField] private Transform _targetDirection;        // diretion of each segment
    [SerializeField] private float _targetDistance;             // distance between each segment

    [SerializeField] private float _smoothSpeed;                // well... yeah
    private Vector3[] _segmentsPositions;                       // segments positions
    private Vector3[] _segmentVelocity;                         // smooth speed references
    
    [SerializeField] private float _wiggleSpeed;
    [SerializeField] private float _wiggleMagnitude;
    [SerializeField] private Transform _wiggleDirection;
    private void Start()
    {
        _rend.positionCount = _length;
        _segmentsPositions = new Vector3[_length];
        _segmentVelocity = new Vector3[_length];

    }
    private void Update()
    {
        _wiggleDirection.localRotation = Quaternion.Euler(0,0, Mathf.Sin(Time.time * _wiggleSpeed) * _wiggleMagnitude);
        
        _segmentsPositions[0] = _targetDirection.position;
        for (int i = 1; i < _segmentsPositions.Length; i++)
        {
            _segmentsPositions[i] = Vector3.SmoothDamp(_segmentsPositions[i], _segmentsPositions[i - 1] + _targetDirection.right * _targetDistance, ref _segmentVelocity[i], _smoothSpeed + i / _trailSpeed);
        }
        _rend.SetPositions(_segmentsPositions);
    }
}