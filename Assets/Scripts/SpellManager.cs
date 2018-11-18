using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject zoneprotect;
    [SerializeField]
    public GameObject zonedot;
    [SerializeField]
    public GameObject zoneslow;
    [SerializeField]
    public GameObject zonepush;
    [SerializeField]
    public GameObject mineprotect;
    [SerializeField]
    public GameObject minedot;
    [SerializeField]
    public GameObject mineslow;
    [SerializeField]
    public GameObject minepush;
    [SerializeField]
    public GameObject ripple;
    [SerializeField]
    public GameObject aoe;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
