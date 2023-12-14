using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;

    private int layersCount;

    void Start()
    {
        layersCount = layers.Length;
    }

    void Update()
    {
        for (int i = 0; i < layersCount; i++)
        {
            layers[i].position = transform.position * coeff[i];
        }
    }
}
