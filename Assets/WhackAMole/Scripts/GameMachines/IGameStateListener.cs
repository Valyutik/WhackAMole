namespace WhackTheMole.Scripts.GameMachines
{
    public interface IGameStateListener
    {
        void OnStartGame() { }

        void OnPauseGame() { }

        void OnResumeGame() { }
        
        void OnFinishGame() { }
        
    }
}