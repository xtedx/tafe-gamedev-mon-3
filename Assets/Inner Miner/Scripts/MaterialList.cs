using System.Collections.Generic;
using TeddyToolKit.Core;
using UnityEngine;

namespace Inner_Miner.Scripts
{
    /// <summary>
    /// Very useful as a bridge between Unity objects and any scripts not directly related.
    /// This is a list of materials so that i can drag and rop the materials from project to inspector and use in
    /// block scripts for the colours.
    /// </summary>
    public class MaterialList : MonoSingleton<MaterialList>
    {
        public List<Material> Materials;
        public ParticleSystem poof;
    }
}