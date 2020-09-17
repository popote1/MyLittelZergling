using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZerglingHolder : MonoBehaviour
{
    [Header("StartStats")]
    [Range(1, 100)] public int PV=100;
    [Range(1, 100)] public int Food=50;
    [Range(1, 100)] public int Power=75;
    private Zergling _zergling;
    void Start()
    {
        _zergling = new Zergling(PV, Food, Power);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
