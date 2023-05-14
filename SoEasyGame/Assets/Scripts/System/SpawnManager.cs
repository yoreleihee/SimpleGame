using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Literal;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private Gem _gem;

    private void Start()
    {
        _gem = Resources.Load<Gem>(PathString.GEM_FILE_PATH);
        SpawnRoutine().Forget();
    }

    private float[] _xPos = { -5f, 0f, 5f };
    private async UniTaskVoid SpawnRoutine()
    {
        while (true)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            int randomIndex = Random.Range(0, _xPos.Length);
            float randomX = _xPos[randomIndex];
            Instantiate(_gem, new Vector3(randomX, transform.position.y, transform.position.z), _gem.transform.rotation);
        }
    }
    
}
