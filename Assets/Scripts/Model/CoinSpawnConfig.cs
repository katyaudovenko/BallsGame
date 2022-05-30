using System;
using Controller.SpawnLogic;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class CoinSpawnConfig
    {
        [Range(1f, 100f)] public float chance;
        public int costBall;
        public BallType ballType;
    }
}