using UnityEngine;

namespace GFA.TPS.MatchSystem
{
    [CreateAssetMenu(menuName = "MatchInstance")]
    public class MatchInstance : ScriptableObject
    {
        public float Time { get; private set; }

        public void AddTime(float delta)
        {
            Time += delta;
        }
    }
}
