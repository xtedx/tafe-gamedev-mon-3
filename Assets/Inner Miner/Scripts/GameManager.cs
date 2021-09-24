using TeddyToolKit.Core;
using UnityEngine;

namespace Inner_Miner.Scripts
{
    /// <summary>
    /// the brain of the game, controls most aspects like score keeping, and game logic
    /// </summary>
    public class GameManager : MonoSingleton<GameManager>
    {
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
    }
}