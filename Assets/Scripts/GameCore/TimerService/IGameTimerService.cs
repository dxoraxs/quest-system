namespace QuestSystem.GameCore
{
    public interface IGameTimerService
    {
        void Register(ITickable tickable);
    }
}