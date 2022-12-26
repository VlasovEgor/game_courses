using UnityEngine;

public class RotateController : MonoBehaviour, IConstructListener, IStartGameListener, IFinishGameListener
{
    private IRotateComponent _rotateComponent;
    private ManipulatorsInput _manipulatorsInput;

    public void Construct(GameContext context)
    {
        _manipulatorsInput = context.GetService<ManipulatorsInput>();
        _rotateComponent = context.GetService<CharacterService>().GetCharacter().Get<IRotateComponent>();
    }

    public void OnStartGame()
    {
        _manipulatorsInput.OnRotate += Rotate;
    }

    public void OnFinishGame()
    {
        _manipulatorsInput.OnRotate -= Rotate;
    }

    private void Rotate(Vector3 rotateVector)
    {
        Debug.Log("б йнмрпнккепе" + rotateVector);
        _rotateComponent.Rotate(rotateVector);
    }
}