using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanLogic : MonoBehaviour
{
    //Scaned targets
    private RaycastHit2D[] targets;
    private Transform nearsetTarget;

    //Scan targets within scanRange
    public void Scan(float scanRange, LayerMask targetLayer)
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        SetNearest();
    }

    //Set nearest target
    private void SetNearest()
    {
        nearsetTarget = null;
        float diff = 1000;

        foreach(RaycastHit2D target in targets)
        {
            Vector3 targetPosition = target.transform.position;
            float curDiff = Vector3.Distance(targetPosition, transform.position);

            if (curDiff < diff)
            {
                diff = curDiff;
                nearsetTarget = target.transform;
            }
        }
    }
    
    public Transform GetNearest()
    {
        return nearsetTarget;
    }

}
