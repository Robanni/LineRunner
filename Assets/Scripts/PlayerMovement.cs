using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _pointsList;

    [Range(0, 1), SerializeField] private float speed = 0.05f;

    [Range(0,1),SerializeField] private float t;

    private Bezier _bezier = new Bezier();

    private void FixedUpdate()
    {

        MovePlayer();
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

    private void MovePlayer()
    {
        if(Input.touchCount != 0 && t <= 1) t += speed;

        transform.position = _bezier.GetPointOnBezierCurve(_pointsList, t);
        transform.rotation = Quaternion.LookRotation(_bezier.GetPointOnDerivativeBezierCurve(_pointsList, t));
    }
}
