using UnityEngine;

public class VisitEnemyController : MonoBehaviour,IConstructListener,IStartGameListener,IFinishGameListener
{
    private IEntity _hero;
    private CollisionComponent _heroComponent;
    private FightWithEnemy _fight;


    public void Construct(GameContext context)
    {
        _hero = context.GetService<CharacterService>().GetCharacter();
        _heroComponent = _hero.Get<CollisionComponent>();
        _fight=context.GetService<FightWithEnemy>();
    }

    public void OnStartGame()
    {
        _heroComponent.OnCollisionEntered += OnHeroEntered;
        _heroComponent.OnCollisionExited += OnHeroExited;
    }

    public void OnFinishGame()
    {
        _heroComponent.OnCollisionEntered -= OnHeroEntered;
        _heroComponent.OnCollisionExited -= OnHeroExited;
    }

    private void OnHeroEntered(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IEntity entity) && entity.TryGet(out ComponentObjectType typeComponent) && typeComponent.ObjectType==ObjectType.ENEMY)
        {

            if(_fight.CanFight(entity))
            {
                _fight.StartFight(entity);
            }
        }
    }

    private void OnHeroExited(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IEntity entity) && entity.TryGet(out ComponentObjectType typeComponent) && typeComponent.ObjectType == ObjectType.ENEMY)
        {
            _fight.CanselFight();
        }
    }
}