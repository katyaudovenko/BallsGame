using System;
using Model.Progress;
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
            if (String.IsNullOrEmpty(json))
            {
                Progress = new ProgressData();
            }
            else
            {
                Progress = JsonUtility.FromJson<ProgressData>(json);
            }
            OnDataLoad?.Invoke();
        }
    }
}