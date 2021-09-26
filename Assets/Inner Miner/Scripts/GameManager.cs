using System;
using Inner_Miner.Scripts;
using TeddyToolKit.Core;
using TeddyToolKit.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inner_Miner.Scripts
{
    /// <summary>
    /// the brain of the game, controls most aspects like score keeping, and game logic
    /// </summary>
    public class GameManager : MonoSingleton<GameManager>
    {
        public GameObject player;
        public int score;
        private Vector3 playerStartPos = Vector3.zero;

        public TMP_Text txtScore;
        
        private void Start()
        {
            init();
        }

        public void init()
        {
            playerStartPos = new Vector3(-2, 1, 1.4f);
            score = 0;
            //UiManager.Instance.CloseAllMenus();
        }
        
        /// <summary>
        /// decides what to do with the clicked object, is it a cube? a shop? another player?
        /// </summary>
        /// <param name="gameObject"></param>
        public void objectClickAction(GameObject clickedObj)
        {
            //if object is a digable block
            
            Debug.Log($"game manager received the object {clickedObj.name}");
            if (clickedObj.CompareTag("Block"))
            {
                Debug.Log($"hp left {clickedObj.GetComponent<Block>().dig(1)}");
            }
        }

        /// <summary>
        /// reset everything and start a new game
        /// </summary>
        public void newGame()
        {
            Debug.Log("TODO: new game menu click");
            //reset player pos
            player.transform.position = playerStartPos;
            //reset score
            score = 0;
            
            GridManager.Instance.restartGrid();
            UiManager.Instance.CloseAllMenus();
        }

        /// <summary>
        /// add score
        /// </summary>
        /// <param name="value"></param>
        public void addScore(int value)
        {
            score += value;
            txtScore.text = score.ToString();
        }
    }
}