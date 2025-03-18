using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform pointPrefab;
    [SerializeField][Range(10, 100)] private int resolution = 10;
    [SerializeField] [Range(0,1)] private int function = 0;

    private Transform[] points;

    private void Awake()
    {
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;
        points = new Transform[resolution];
        for (int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            position.y = (function == 0) ? FunctionLibrary.Wave(position.x, 0f) : FunctionLibrary.MultiWave(position.x, 0f);
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    private void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Vector3 position = points[i].localPosition;
            position.y = (function == 0) ? FunctionLibrary.Wave(position.x, 0f) : FunctionLibrary.MultiWave(position.x, 0f);
            points[i].localPosition = position;
        }
    }
}
