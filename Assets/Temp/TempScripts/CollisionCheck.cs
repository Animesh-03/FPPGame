using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Check Working");
    }
}
