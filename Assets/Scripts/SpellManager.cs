using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public static SpellManager instance;

    [SerializeField]
    public GameObject spray;
    [SerializeField]
    public GameObject line;
    [SerializeField]
    public GameObject Toss;
    [SerializeField]
    public GameObject zone;
    [SerializeField]
    public GameObject mine;
    [SerializeField]
    public GameObject ripple;
    [SerializeField]
    public GameObject aoe;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }
}
