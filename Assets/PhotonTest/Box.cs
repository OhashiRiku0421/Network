using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Box : NetworkBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PhysxBall")
        {
            
        }
    }
}
