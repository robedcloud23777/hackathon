using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Path line;

    private void Start()
    {
        line.ToggleVisibility(!line.GetComponent<LineRenderer>().enabled);
        if (line != null && points != null)
        {
            line.SetUpLine(points);
        }
    }

    private void Update()
    {
        if (line != null && line.IsPathUpdated())
        {
            line.UpdateLineRenderer();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            line.ToggleVisibility(!line.GetComponent<LineRenderer>().enabled);
        }
    }
}
