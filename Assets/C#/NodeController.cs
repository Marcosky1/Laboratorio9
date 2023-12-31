using System.Collections;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public NodeController headNode;

    public NodeController nextNode;

    public float energyCost = 10.0f;

    public void AddNode(NodeController newNode)
    {
        if (headNode == null)
        {
            headNode = newNode;
        }
        else
        {
            NodeController currentNode = headNode;
            while (currentNode.nextNode != null)
            {
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = newNode;
        }
    }

    public NodeController GetNextNode(float energy)
    {
        NodeController currentNode = headNode;
        NodeController[] reachableNodes = new NodeController[100]; 
        int count = 0;

        while (currentNode != null)
        {
            if (energy >= currentNode.energyCost)
            {
                reachableNodes[count] = currentNode;
                count++;
            }

            currentNode = currentNode.nextNode;
        }

        if (count == 0)
        {
            return this;
        }
        else
        {
            int index = Random.Range(0, count);
            energy -= reachableNodes[index].energyCost;
            return reachableNodes[index];
        }
    }
}


