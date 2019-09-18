using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathematicalSurfaces : MonoBehaviour
{
    public Transform pointPrefab;
    [Range(1, 100)]
    public int resolution = 10;

    Transform[] points;

    Vector3 scale = Vector3.one / 5;
    Vector3 position;

    static float SineFunction(float x, float t)
    {
        return Mathf.Sin(Mathf.PI * (x + t));
    }

    static float MultiSineFunction(float x, float t)
    {
        float y = Mathf.Sin(Mathf.PI * (x + t));
        y += Mathf.Sin(2f * Mathf.PI * (x + 2 * t)) / 2f;
        y *= 2f / 3f;
        return y;
    }

    void Awake()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0f;
        position.z = 0f;
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            //position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time;

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            //position.y = SineFunction(position.x, t);
            position.y = MultiSineFunction(position.x, t);
            point.localPosition = position;
        }
    }

    void SineFunction()
    {

    }
}
