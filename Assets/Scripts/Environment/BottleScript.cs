using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : MonoBehaviour
{
    private SpringJoint2D _springJoint2D;

    private void Awake()
    {
        _springJoint2D = GetComponent<SpringJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.name)
        {
            case "Knife":
                _springJoint2D.enabled = false;
                break;
            case "BonFire":
                col.gameObject.GetComponent<PointEffector2D>().enabled = true;
                Destroy(gameObject);
                break;
        }
    }
}
