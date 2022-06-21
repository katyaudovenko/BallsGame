using System;
using Controller.SpawnLogic;
using UnityEngine;

namespace Model.Infos.SpawnInfo
{
    [Serializable]
    public class CoinSpawnConfig
    {
        [Range(1f, 100f)] [SerializeField] private float chance;
        public float Chance => chance;

        public int costBall;

        [SerializeField] private BallType ballType;
        public BallType BallType => ballType;
    }
}