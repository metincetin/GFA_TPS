using UnityEngine;

namespace GFA.TPS.MatchSystem
{
	[CreateAssetMenu]
	public class EnemySpawnData : ScriptableObject
	{
		[SerializeField] private SpawnEntry[] _entries;
	}

	[System.Serializable]
	public struct SpawnEntry
	{
		[SerializeField] private int _duration;

		[SerializeField] private GameObject[] _prefabs;

		[SerializeField] private int _spawnCount;
	}
}