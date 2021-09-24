using System;
using System.Collections;
using System.Collections.Generic;
using Inner_Miner.Scripts;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hp;
    public int level;
    public Material material;
    public ParticleSystem poof;
    public string blockName;

    public int baseHp = 5;
    public int startLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        //init(0);
    }

    /// <summary>
    /// initialise the game block level and material
    /// </summary>
    public void init(int setLevel)
    {
        //precondition:
        if (setLevel < 0)
        {
            throw new Exception("level cannot be negative");
        }
        //blocks start from level 0, with baseHP
        //from level 0: 5, 10, 15, ....
        level = setLevel;
        hp = baseHp + (hp * level);
        //use mod 16 to make sure the colours get repeated and not out of bound
        material = MaterialList.Instance.Materials[level%16];
        GetComponent<Renderer>().material = material;
        gameObject.SetActive(true);
    }

    /// <summary>
    ///dig the block and reduce the hp by 1
    /// </summary>
    public int dig(int power)
    {
        if (hp > power)
        {
            hp -= power;
        }
        else
        {
            hp = 0;
            vanish();
        }

        return hp;
    }

    /// <summary>
    /// make the block vanisha
    /// </summary>
    public void vanish()
    {
        poof.Play();
        gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
