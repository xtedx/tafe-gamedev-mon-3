using System;
using System.Collections;
using System.Collections.Generic;
using Inner_Miner.Scripts;
using TeddyToolKit.Test.PointClick;
using UnityEngine;
using GameManager = Inner_Miner.Scripts.GameManager;

/// <summary>
/// Represents a block in the game that can be destroyed
/// </summary>
public class Block : MonoBehaviour
{
    public int hp;
    public int level;
    public Material material;
    public ParticleSystem poof;
    public string blockName;

    public int baseHp = 5;
    public int startLevel = 0;
    public bool isTreasure;
    public int treasureBaseValue = 100;
    public int treasureValue;
    
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
        hp = baseHp + (baseHp * level);
        //if treasure, then set the value
        if (isTreasure)
        {
            treasureValue = treasureBaseValue + (treasureBaseValue * level);
        }
        //use mod 16 to make sure the colours get repeated and not out of bound
        material = MaterialList.Instance.Materials[level%16];
        GetComponent<Renderer>().material = material;
        gameObject.SetActive(true);

        poof = MaterialList.Instance.poof;
    }

    /// <summary>
    ///dig the block and reduce the hp by 1
    /// </summary>
    /// <returns>the remaining hp</returns>
    public int dig(int power)
    {
        var score = 0;
        if (hp > power)
        {
            hp -= power;
            score = power;
        }
        else
        {
            //add the remaining hp and treasure as the score; 
            score = hp + treasureValue;
            hp = 0;
            vanish();
        }

        GameManager.Instance.addScore(score);
        return hp;
    }

    /// <summary>
    /// make the block vanisha
    /// </summary>
    public void vanish()
    {
        poof.transform.position = transform.position;
        poof.Stop();
        poof.Play();
        gameObject.SetActive(false);
        //must remove selection after destroyed to avoid score bug
        SelectionManager.Instance.selectedObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
