using Assets.Scripts.Heroes.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nocturne : ExposableMonobehaviour, IHero
{
    [ExposeProperty]
    public float AD { get; set; }
    [ExposeProperty]
    public float HP { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
