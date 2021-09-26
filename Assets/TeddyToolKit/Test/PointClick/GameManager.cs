using TeddyToolKit.Core;
using UnityEngine;

namespace TeddyToolKit.Test.PointClick
{
    /// <summary>
    /// the brain of the game, controls most aspects like score keeping, and game logic
    /// </summary>
    public class GameManager : MonoSingleton<GameManager>
    {
        public ParticleSystem _particleSystem;
        
        /// <summary>
        /// decides what to do with the clicked object, is it a cube? a shop? another player?
        /// </summary>
        /// <param name="gameObject"></param>
        public void objectClickAction(GameObject gameObject)
        {
            //if object is a digable block
            Debug.Log($"game manager received the object {gameObject.name}");
            _particleSystem.transform.position = gameObject.transform.position;
            _particleSystem.Stop();
            _particleSystem.Play();
        }
    }
}