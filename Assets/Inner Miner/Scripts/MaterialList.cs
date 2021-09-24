using System.Collections.Generic;
using TeddyToolKit.Core;
using UnityEngine;

namespace Inner_Miner.Scripts
{
    //this is a list of materials so that i can drag and rop the materials from project to inspector and use in
    //block scripts for the colours
    public class MaterialList : MonoSingleton<MaterialList>
    {
        public List<Material> Materials;
    }
}