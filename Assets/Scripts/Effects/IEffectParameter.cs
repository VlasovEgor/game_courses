
public interface IEffectParameter
{
    EffectParameterKey Name { get; }
}

public interface IEffectParameter<out T> : IEffectParameter
{
    T Value { get; }
}