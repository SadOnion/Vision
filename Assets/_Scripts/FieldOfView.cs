using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private float distance = .1f;
    private Mesh mesh;
    public Vector3 anchor;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        MakeMesh(distance);
        distance += Time.deltaTime*speed;
        if (distance > 20) Destroy(this);
    }

    private Vector2 GetVectorFromAngle(float angle)
    {
        float radAngle = Mathf.Deg2Rad* angle;
        return new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle));
    }

    private void MakeMesh(float distance)
    {
        
        
        int rayCount = 1500;
        float fov = 360f;
        Vector3 origin = anchor;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = distance;

        Vector3[] verticies = new Vector3[rayCount + 1 + 1 +1];
        Vector2[] uv = new Vector2[verticies.Length];
        int[] triangles = new int[rayCount * 3 + 3];

        verticies[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i < rayCount+1; i++)
        {
            Vector3 vertex; 
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, (Vector3)GetVectorFromAngle(angle), viewDistance);
            if(raycastHit2D.collider == null)
            {
                vertex = origin + (Vector3)GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = raycastHit2D.point;
            }
            verticies[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }


        mesh.vertices = verticies;
        mesh.uv = uv;
        mesh.triangles = triangles;

        

    }
}
