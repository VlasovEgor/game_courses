using System;
using UnityEngine;

public class AttackController : MonoBehaviour, IConstructListener, IStartGameListener, IFinishGameListener
{
    private IShotComponent _shotComponent;
    private IAttackComponent _meleeAttackComponent;
    private ManipulatorsInput _manipulatorsInput;

    public void Construct(GameContext context)
    {
        _manipulatorsInput = context.GetService<ManipulatorsInput>();
        _shotComponent = context.GetService<CharacterService>().GetCharacter().Get<IShotComponent>();
        _meleeAttackComponent= context.GetService<CharacterService>().GetCharacter().Get<IAttackComponent>();
    }
    public void OnStartGame()
    {
        _manipulatorsInput.OnShoot += Shot;
        _manipulatorsInput.OnMeleeAttack += MeleeAttack;
    }

    public void OnFinishGame()
    {
        _manipulatorsInput.OnShoot += Shot;
        _manipulatorsInput.OnMeleeAttack -= MeleeAttack;
    }

    private void Shot()
    {
        _shotComponent.Shoot();
    }

    private void MeleeAttack()
    {
       // _meleeAttackComponent.Attack();
    }
}
