using System.Collections.Generic;
using UnityEngine;

public class GridLineDisplay : MonoBehaviour
{
    private void Start()
    {
        List<Vector3> points = new List<Vector3>();
        Vector3 point = new Vector3(-5.0f, 0.0f, -5.0f);
        Vector3 length = new Vector3(10.0f, 0.0f, 0.0f);
        for (int i = 0; i < 11; i++)
        {
            points.Add(point);
            point += length;
            points.Add(point);
            point += new Vector3(0.0f, 0.0f, 1.0f);
            length *= -1;
        }
        point -= new Vector3(0.0f, 0.0f, 1.0f);
        length = new Vector3(0.0f, 0.0f, -10.0f);
        for (int i = 0; i < 11; i++)
        {
            points.Add(point);
            point += length;
            points.Add(point);
            point += new Vector3(-1.0f, 0.0f, 0.0f);
            length *= -1;
        }
        GetComponent<LineRenderer>().SetPositions(points.ToArray());
    }
}