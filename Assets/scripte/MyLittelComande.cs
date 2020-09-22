using System.Collections;
using System.Collections.Generic;
using scripte;
using UnityEngine;

public class MyLittelComande : MonoBehaviour
{
    [Header("Actoin Manger")] 
    public int FoodGaine = 20;
    public int PowerCost = 10;
    public GameObject Marine;
    public List<AudioClip> SonManger;

    [Header("ActionSleep")]
    public int PowerGaine = 30;
    public AudioClip BurowSound;
    public AudioClip UnberowSond;

    [Header("Clean")]
    public float MaxCadavre = 5;
    public AudioClip CleanSound;
    public GameObject Zerging1;
    
    private Zergling _zergling1;
    private int _nombreCadavre = 0;
    public List<GameObject> _cadavre;
    private AudioSource _soundEffcetSource;
    
    void Start()
    {
        _zergling1=Zerging1.GetComponent<ZerglingHolder>()._zergling;
        _soundEffcetSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_cadavre.Count >= MaxCadavre)
        {
            Debug.Log("T'es Mort");
        }
    }

    public void UIManger()
    {
        if (!Zerging1.GetComponent<ZerglingHolder>().IsSleeping&&!Zerging1.GetComponent<ZerglingHolder>().IsDead) 
        {
            _zergling1.Food += FoodGaine;
            _zergling1.Power -= PowerCost;
            _soundEffcetSource.clip =SonManger[Mathf.RoundToInt(Random.Range(0, SonManger.Count - 1))];
            _soundEffcetSource.Play();
            Vector2 MarinPos = new Vector2(Random.Range(-1, 5), Random.Range(-1, 3));
            _cadavre.Add(Instantiate(Marine, MarinPos, Quaternion.identity));
            Zerging1.GetComponent<ZerglingHolder>().Attack(MarinPos);
            Debug.Log("Mange");
        }
    }

    public void UISleep()
    {
        if (!Zerging1.GetComponent<ZerglingHolder>().IsSleeping&&!Zerging1.GetComponent<ZerglingHolder>().IsDead)
        {
            _soundEffcetSource.clip = BurowSound;
            _soundEffcetSource.Play();
            Zerging1.GetComponent<ZerglingHolder>().IsSleeping = true;
            Zerging1.GetComponent<ZerglingHolder>().AnimBurow();
            _zergling1.Power += PowerGaine;
            Debug.Log("Sleep");
        }
    }

    public void UIClean()
    {
        foreach (GameObject cadavre in _cadavre)
        {
            Destroy(cadavre.gameObject);   
        }
        _soundEffcetSource.clip = CleanSound;
        _soundEffcetSource.Play();
        Debug.Log("clean");

    }
}
