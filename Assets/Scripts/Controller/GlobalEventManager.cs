using System;
using Controller.States;

namespace Controller
{
    public static class GlobalEventManager
    {
        public static event Action StartGame;
        public static void OnStartGame() => StartGame?.Invoke();
    }
}