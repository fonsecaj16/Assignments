using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    
    public int numberOfPoints;
    Vector3[] positions;
    float radius = 0f;
    float smallRadius = 0.5f;
    public GameObject smallSphere;  
    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector3[numberOfPoints];
        GenerateRandomPoints();
        Vector3 sphereCenter = GenerateSphere();
        CheckIfInside(sphereCenter);
    }

    void GenerateRandomPoints()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            Vector3 pointPosition = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            positions[i] = pointPosition;
            Instantiate(smallSphere, pointPosition, Quaternion.identity);
        }
    }
    Vector3 GenerateSphere()
    {
        float furthestDistance = 0;
        Vector3 point1 = Vector3.zero;
        Vector3 point2 = Vector3.zero;
        foreach(Vector3 point in positions)
        {
            foreach(Vector3 secondPoint in positions)
            {
                if (point == secondPoint) continue;
                float distance = ((secondPoint-new Vector3(smallRadius,smallRadius,smallRadius))- (point + new Vector3(smallRadius, smallRadius, smallRadius))).sqrMagnitude;
                if (distance > furthestDistance)
                {
                    furthestDistance = distance;
                    point1 = point;
                    point2 = secondPoint;
                }
            }
        }
        Debug.Log(point1);
        Debug.Log(point2);
        Vector3 center = point1 + (point2 - point1) / 2;
        furthestDistance = 0;
        Vector3 furthestPointFromCenter = Vector3.zero;
        foreach(Vector3 point in positions)
        {
            float distance = ((center - new Vector3(smallRadius, smallRadius, smallRadius)) - (point + new Vector3(smallRadius, smallRadius, smallRadius))).sqrMagnitude;
            if (distance > furthestDistance)
            {
                furthestDistance = distance;
                furthestPointFromCenter = point;
            }
        }
        Debug.Log("furthestPoint " +furthestPointFromCenter);
        radius = (furthestPointFromCenter - center).magnitude+1f;
        float diameter = radius*2;
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = center;
        sphere.name = "BigSphere";
        sphere.transform.localScale = new Vector3(diameter, diameter, diameter);
        Debug.Log(center);
        return center;

    }

    void CheckIfInside(Vector3 sphereCenter)
    {
        int i = 1;
        foreach(Vector3 point in positions)
        {
            float distanceFromCenters = (point - sphereCenter).magnitude;
            
            Debug.Log("Sphere "+i+" Distance: " + distanceFromCenters);
           
            if (distanceFromCenters>=radius+smallRadius)
            {
                Debug.Log("ERROR");
            }
            i++;
        }
        Debug.Log("Radius: " + radius);
        Debug.Log("Radius+radius: " + (radius + smallRadius));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
