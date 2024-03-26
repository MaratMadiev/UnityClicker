using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ResourceBank
    {
        Dictionary<GameResource, ObservableInt> bankDict = new Dictionary<GameResource, ObservableInt>();

        public ObservableInt GetResource(GameResource r)
        { 
            if (!bankDict.ContainsKey(r))
            {
                bankDict[r] = new ObservableInt();
            }

            return bankDict[r];
        }

        public void ChangeResource(GameResource r, int v)
        {
            if (!bankDict.ContainsKey(r))
            {
                bankDict[r] = new ObservableInt();
            }

            bankDict[r].Value += v;
        }
    }
}
