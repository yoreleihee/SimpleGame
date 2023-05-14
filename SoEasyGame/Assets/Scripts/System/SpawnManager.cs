using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Literal;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private Gem _gem;
    private Stack<Gem> _gemStack;
    [SerializeField] private int _numberOfGemsToCreate = 6;
    private float[] _xPos = { -5f, 0f, 5f };

    private void Start()
    {
        _gemStack = new Stack<Gem>();
        _gem = Resources.Load<Gem>(PathString.GEM_FILE_PATH);
        
        int randomIndex = Random.Range(0, _xPos.Length);
        float randomX = _xPos[randomIndex];
        
        for (int i = 0; i < _numberOfGemsToCreate; ++i)
        {
            Gem gem = Instantiate(_gem, new Vector3(randomX, transform.position.y, transform.position.z), _gem.transform.rotation);
            
            gem.gameObject.SetActive(false);
            _gemStack.Push(gem);
        }
        
        SpawnRoutine().Forget();
    }

    private async UniTaskVoid SpawnRoutine()
    {
        while (true)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            GetGemFromStack();
        }
    }

    private void GetGemFromStack()
    {
        Gem gem = _gemStack.Pop();
        // 스택 참조 연결
        gem.gameObject.SetActive(true);
        gem.SetStackReference(_gemStack);
    }
}
