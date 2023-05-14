using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Literal;

public class SpawnManager : MonoBehaviour
{
    private Gem _gem;

    private void Start()
    {
        _gem = Resources.Load<Gem>(PathString.GEM_FILE_PATH);
        SpawnRoutine().Forget();
    }

    private async UniTaskVoid SpawnRoutine()
    {
        while (true)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            Instantiate(_gem,transform.position, _gem.transform.rotation);
        }
    }
    
}
