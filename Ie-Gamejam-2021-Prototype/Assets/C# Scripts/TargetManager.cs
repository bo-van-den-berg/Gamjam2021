using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetManager : MonoBehaviour
{
    private struct Wave
    {
        public CreateTarget waveTargetCreator;
        public int waveTargetCount;
    }

    private ObjectPool objectPool;

    private CreateTarget createTargetFake;
    private CreateTarget createTargetZombie;
    private CreateTarget createTargetBush;

    private CreateTarget currentCreator;

    private int destroyedCount;

    private List<Wave> Waves = new List<Wave>();

    private int waveIndex;

    private void Awake()
    {
        GetAllComponents();

        SetWaves();

        objectPool = new ObjectPool();

        EventManager.current.objectDeath += TargetDestroyed;
    }

    private void SetWaves()
    {
        Waves.Add(new Wave { waveTargetCreator = createTargetFake, waveTargetCount = 1 });
        Waves.Add(new Wave { waveTargetCreator = createTargetFake, waveTargetCount = 5 });
        Waves.Add(new Wave { waveTargetCreator = createTargetZombie, waveTargetCount = 3 });
        Waves.Add(new Wave { waveTargetCreator = createTargetZombie, waveTargetCount = -1 });
    }

    private int GetNextWaveIndex()
    {
        if (waveIndex < Waves.Count - 1)
        {
            waveIndex++;
        }
        else
        {
            waveIndex = 0;
        }

        return waveIndex;
    }

    private void Update()
    {

        if (Waves[waveIndex].waveTargetCreator.Run(objectPool, Waves[waveIndex].waveTargetCount))
        {
            if (destroyedCount >= Waves[waveIndex].waveTargetCount)
            {
                destroyedCount = 0;

                currentCreator = Waves[GetNextWaveIndex()].waveTargetCreator;
                currentCreator.OnReset();

                EventManager.current.WaveCompleted();
            }
        }

        createTargetBush.Run(objectPool, -1);
    }

    private void GetAllComponents()
    {
        if (TryGetComponent<CreateTargetFake>(out CreateTargetFake iCreateTargetFake))
        {
            createTargetFake = iCreateTargetFake;
        }

        if (TryGetComponent<CreateTargetZombie>(out CreateTargetZombie iCreateTargetZombie))
        {
            createTargetZombie = iCreateTargetZombie;
        }

        if (TryGetComponent<CreateTargetBush>(out CreateTargetBush iCreateTargetBush))
        {
            createTargetBush = iCreateTargetBush;
        }
    }

    private void TargetDestroyed(GameObject iObject)
    {
        destroyedCount++;
    }
}
