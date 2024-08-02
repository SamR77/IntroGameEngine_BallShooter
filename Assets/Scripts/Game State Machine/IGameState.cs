



public interface IGameState
{
    void EnterState(GameStateManager gameStateManager);
    void UpdateState(GameStateManager gameStateManager);
    void FixedUpdateState(GameStateManager gameStateManager);
    void LateUpdateState(GameStateManager gameStateManager);
    void ExitState(GameStateManager gameStateManager);
}
