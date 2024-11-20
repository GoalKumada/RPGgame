using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    void Start()
    {
        if (Valuables.posOfTown != Vector3.zero)
        {
            transform.position = Valuables.posOfTown;
        }
    }
}
