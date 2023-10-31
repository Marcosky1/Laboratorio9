using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public List<NodeControl> listAllAdjacentes;
 

    public NodeControl GetNextNode() 
    {
        int index = Random.Range(0,listAllAdjacentes.Count);
        return listAllAdjacentes[index];
    }
}
