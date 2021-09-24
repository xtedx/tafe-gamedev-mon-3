﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Cinemachine;
using TeddyToolKit.Core;
using UnityEngine;

namespace Inner_Miner.Scripts
{
    /// <summary>
    /// manages the grid and the blocks
    /// </summary>
    public class GridManager : MonoSingleton<GridManager>
    {
        public Dictionary<Vector3Int, Block> grid;
        public GameObject blockPrefab;
        public int maxX = 8;
        public int maxY = 16;
        public int maxZ = 8;
        public int maxLayer = 2;


        private void Start()
        {
            init();
            generateGrid(maxX, maxY, maxZ);
        }

        //initialise object
        public void init()
        {
            //set capacity for optimisation
            grid = new Dictionary<Vector3Int, Block>(maxX*maxY*maxZ);
        }
        
        /// <summary>
        /// generate grid/map of the blocks
        /// </summary>
        /// <param name="maxX">maximum dimension x</param>
        /// <param name="maxY">maximum dimension y</param>
        /// <param name="maxZ">maximum dimension z</param>
        /// <exception cref="Exception"></exception>
        public void generateGrid(int maxX, int maxY, int maxZ)
        {
            //precondition:
            bool isValid = true;
            if (grid == null) isValid = false;
            if (blockPrefab == null) isValid = false;
            
            if (!isValid) throw new Exception("grid null in generateGrid");
            //start from z, x, then y for depth, stepping maxLayer at a time
            for (var y = 0; y < maxY; y=y+maxLayer)
            {
                for (var layer = 0; layer < maxLayer; layer++)
                { 
                    for (var x = 0; x < maxX; x++)
                    {
                        for (var z = 0; z < maxZ; z++)
                        {
                            /* the layer must be added to yloop, cannot repeat yvector
                             * layer   y   yvector      level
                             *  0  +   0  =   0   /2  =  0
                             *  1  +   0  =   1   /2  =  0
                             *  0  +   2  =   2   /2  =  1
                             *  1  +   2  =   3   /2  =  1
                             * then negate to go down not up
                             * and use integer division of y to only add level every 2(maxlayers)
                             */
                            var pos = new Vector3Int(x, -(y+layer), z);
                            var block = Instantiate(blockPrefab, pos, transform.rotation).GetComponent<Block>();
                            var level = y / maxLayer;
                            block.init(level);
                            //Debug.Log($"pos {pos}:: layer {layer} y {y} level {level}");
                            grid.Add(pos, block);
                        }
                    }
                }
            }
        }
    }
}