using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZerglingStat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

public class Zergling
{
    
    private int _health;
    public int Health
    {
        get => _health ;
        set
        {
            _health = Mathf.Clamp(value,0,100);
        }
    }

    private int _food;
    public int Food
    {
        get => _food;
        set => _food = Mathf.Clamp(value,0,100);
    }

    private int _power;

    public int Power
    {
        get => _power;
        set => _power= Mathf.Clamp(value,0,100);
    }

    private int _exostStat;

    public int ExostStat
    {
        get => _exostStat;
        set => _exostStat = value;
    }

    public Zergling(int health, int Food, int Power)
    {
        _health = health;
        _food = Food;
        _power = Power;
    }
}
