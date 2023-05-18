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

    private void Start()
    {
        _gemStack = new Stack<Gem>();
        _gem = Resources.Load<Gem>(PathString.GEM_FILE_PATH);
        
        for (int i = 0; i < _numberOfGemsToCreate; ++i)
        {
            Gem gem = Instantiate(_gem);
            
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
