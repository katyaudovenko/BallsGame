using System;
using Model.Progress;
using Services.ServiceLocator;
using UnityEngine;

namespace Services
{
    public class ProgressService : IService
    {
        private const string PlayerProgressKey = "PlayerProgress";
        public ProgressData Progress;
        public event Action OnDataLoad;

        public void Save()
        {
            var json = JsonUtility.ToJson(Progress);
            PlayerPrefs.SetString(PlayerProgressKey, json);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            var json = PlayerPrefs.GetString(PlayerProgressKey, "");
            Progress = string.IsNullOrEmpty(json)
                ? new ProgressData() 
                : JsonUtility.FromJson<ProgressData>(json);
            OnDataLoad?.Invoke();
        }
    }
}