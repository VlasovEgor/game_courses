using UnityEngine;

public class FightWithEnemyProcessor : MonoBehaviour, IConstructListener ,IStartGameListener,IFinishGameListener
{
    public bool IsFighting
    {
        get { return _heroComponent.IsFighting; } 
    } 

    private IFightWithEnemyComponent _heroComponent;

    void IConstructListener.Construct(GameContext context)
    {
        _heroComponent=context.GetService<CharacterService>().GetCharacter().Get<IFightWithEnemyComponent>();
    }

    void IStartGameListener.OnStartGame()
    {
        _heroComponent.OnFinished += FinishFight;
    }

    void IFinishGameListener.OnFinishGame()
    {
        _heroComponent.OnFinished -= FinishFight;
    }

    public bool CanFight(IEntity enemy)
    {
        if(enemy.Get<IHidingComponent>().IsHiding() == true)
        {
            return true;
        }

        var operation= new FightWihtEnemyOperation(enemy);

        if(_heroComponent.CanFight(operation) == true) 
        {
            return true;
        }

        if(IsFighting == false)
        {
            return true;
        }

        return false;
    }

    public void StartFight(IEntity enemy)
    {
        Debug.Log("Start");

        var operation= new FightWihtEnemyOperation(enemy);
        _heroComponent.StartFight(operation);
    }

    private  void FinishFight(FightWihtEnemyOperation operation)
    {   
        if(operation.IsCompleted == true)
        {
            Debug.Log("Victory");
            //do smth
        }
    }

    public void CancelFight()
    {
        Debug.Log("Cancel");
        _heroComponent.CancelFight();
        //do smth
    }
}
