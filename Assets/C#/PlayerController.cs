using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public NodeController Node;
    private Vector2 refVelocity;
    public float tiempoMove = 0.5f;
    public float Energy = 100.0f; 
    public float restTime = 5.0f;
    private float restTimer = 0.0f;
    private bool isResting = false;

    void Update()
    {
        if (isResting)
        {
            restTimer += Time.deltaTime;
            if (restTimer >= restTime)
            {
                Energy = 100.0f;
                isResting = false;
            }
        }
        else if (Energy <= 0)
        {
            Rest();
        }
        else
        {
            transform.position = Vector2.SmoothDamp(transform.position, Node.transform.position, ref refVelocity, tiempoMove);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            NodeController nextNode = collision.gameObject.GetComponent<NodeController>().GetNextNode(Energy);
            if (nextNode != null)
            {
                Energy -= nextNode.energyCost;
                Node = nextNode;
            }
        }
    }

    void Rest()
    {
        isResting = true;
        restTimer = 0.0f;
    }
}
