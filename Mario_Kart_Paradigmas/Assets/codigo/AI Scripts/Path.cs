using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Color lineColor;
    private List<Transform> nodes = new List<Transform>();

    void OnDrawGizmosSelected()
    {
        Vector3 prevNode = Vector3.zero;
        Gizmos.color = lineColor;
        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != transform)
            {
                nodes.Add(pathTransform[i]);
            }
        }

        // Draw lines between nodes
        for (int i = 0; i < nodes.Count - 1; i++)
        {
            Vector3 currentNode = nodes[i].position;
            if (i > 0)
            {
                prevNode = nodes[i - 1].position;
            }
            else if(i == 0 && nodes.Count > 1) 
            {
                prevNode = nodes[nodes.Count - 1].position;
            }
            Gizmos.DrawLine(currentNode, prevNode);
            Gizmos.DrawSphere(currentNode, 0.3f);
        }


    }
}
