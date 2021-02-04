using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface CreateTarget
{
    bool Run(ObjectPool iObjectPool, int iMaxCreatedCount);

    void OnReset();
}
