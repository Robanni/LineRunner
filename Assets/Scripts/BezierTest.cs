using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BezierTest : MonoBehaviour
{
    [SerializeField] private List<Transform> _pointsList;

    private Bezier _bezier = new Bezier();

    [Range(0,1),SerializeField] private float t;

    private void Start()
    {
        
    }
    private void Update()
    {
        
        transform.position = _bezier.GetPointOnBezierCurve(_pointsList, t);
        transform.rotation = Quaternion.LookRotation ( _bezier.GetPointOnDerivativeBezierCurve(_pointsList, t));
    }
    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;

        Vector3 preveousVector = _pointsList[0].position;
        for(int i = 0; i < sigmentsNumber; i++)
        {
            float parametr = (float)i / sigmentsNumber;
            Vector3 point = _bezier.GetPointOnBezierCurve(_pointsList, parametr);
            Gizmos.DrawLine(preveousVector, point);
            preveousVector = point;
        }

    }
}
