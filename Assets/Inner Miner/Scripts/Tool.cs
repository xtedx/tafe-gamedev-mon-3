using System;
using UnityEngine;

namespace Inner_Miner.Scripts
{
    public class Tool : MonoBehaviour
    {
        public int power;
        public int level;
        public Material material;

        public int basePower = 1;
        public int startLevel = 0;

        void Start()
        {
            init(0);
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
            power = basePower + (power * level);
            material = MaterialList.Instance.Materials[level];
        }
    }
}