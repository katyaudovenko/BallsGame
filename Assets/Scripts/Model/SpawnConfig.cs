using System;
using Controller.SpawnLogic;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class SpawnConfig
    {
        [Range(0f,100f)] public float chance;
        public BallType ballType;
    }
}