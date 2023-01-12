
public class CharacterConverter 
{
   public void SetupStats(PlayerConfig character,CharacterData data)
   {
        var entity = character.Entity;

        entity.Get<SetDamageComponent>().SetDamage(data.Damage);
        entity.Get<SetHealthPointComponent>().SetHealthPoint(data.CurrentHealthPoints);
        entity.Get<SetLevelComponent>().SetLevel(data.Level);
        entity.Get<SetSpeedComponent>().SetSpedd(data.MoveSpeed);
   }

    public CharacterData ConvertToData(PlayerConfig character)
    {
        var entity = character.Entity;

        var data = new CharacterData
        {
            id = character.PlayerID,
            CurrentHealthPoints = entity.Get<HealthPointComponent>().Value(),
            Level = entity.Get<LevelComponent>().Value(),
            Damage = entity.Get<PlayerDamageComponent>().Value(),
            MoveSpeed = entity.Get<GetSpeedComponent>().Value()
        };

        return data;
    }
}
