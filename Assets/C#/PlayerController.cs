using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public NodeControl Node;
    private Vector2 refVelocity;
    public float tiempoMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.SnoothDamp(transform.position,Node.transform.position,ref resVelocity,tiempoMove);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Node")
        {
            Node = collision.gameObject.GetComponent<NodeControl>.GetNextNode();
        }
    }
}
