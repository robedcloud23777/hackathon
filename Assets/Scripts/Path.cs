using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;
    private Vector3[] previousPositions;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] points)
    {
        this.points = points;
        previousPositions = new Vector3[points.Length];
        lr.positionCount = points.Length;
        UpdateLineRenderer();
    }

    public void UpdateLineRenderer()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
            previousPositions[i] = points[i].position;
        }
    }

    public void ToggleVisibility(bool isVisible)
    {
        lr.enabled = isVisible;
    }

    public bool IsPathUpdated()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i].position != previousPositions[i])
            {
                return true;
            }
        }
        return false;
    }
}
