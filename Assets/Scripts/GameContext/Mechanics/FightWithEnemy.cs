using UnityEngine;

public class FightWithEnemy : MonoBehaviour, IConstructListener ,IStartGameListener,IFinishGameListener
{
    public bool IsFighting
    {
        get { return _heroComponent.IsFighting; } 
    } 

    private IFIghtWithEnemyComponent _heroComponent;

    void IConstructListener.Construct(GameContext context)
    {
        _heroComponent=context.GetService<CharacterService>().GetCharacter().Get<IFIghtWithEnemyComponent>();
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
        if(enemy.Get<HidingComponent>().isHiding()==true)
        {
            return true;
        }

        var operation= new FightWihtEnemyOperation(enemy);

        if(_heroComponent.CanFight(operation) == true) 
        {
            return true;
        }

        if(IsFighting==false)
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
        if(operation.IsCompleted==true)
        {
            Debug.Log("Victory");
            //do smth
        }
    }

    public void CanselFight()
    {
        Debug.Log("Cancel");
        _heroComponent.CanselFight();
        //do smth
    }
}
