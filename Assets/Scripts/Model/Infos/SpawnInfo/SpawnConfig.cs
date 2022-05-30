using System;
using Controller.SpawnLogic;
using UnityEngine;

namespace Model.Infos.SpawnInfo
{
    [Serializable]
    public class SpawnConfig
    {
        [Range(0f,100f)] 
        [SerializeField] private float chance;
        public float Chance => chance;
        
        [SerializeField] private BallType ballType;
        public BallType BallType => ballType;
    }
}