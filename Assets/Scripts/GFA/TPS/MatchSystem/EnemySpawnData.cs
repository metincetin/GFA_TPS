using System.Collections;
using UnityEngine;

namespace GFA.TPS.MatchSystem
{
	[CreateAssetMenu]
	public class EnemySpawnData : ScriptableObject
	{
		[SerializeField] private SpawnEntry[] _entries;
		public SpawnEntry[] Entries => _entries;

		public bool TryGetEntryByTime(float time, out SpawnEntry spawnEntry)
		{
			float totalTime = 0;
			
			foreach (var entry in _entries)
			{

				totalTime += entry.Duration;
				
				if (totalTime > time)
				{
					spawnEntry = entry;
					return true;
				}


			}

			spawnEntry = new SpawnEntry();
			return false;
		}
	}

	[System.Serializable]
	public struct SpawnEntry
	{
		[SerializeField] private int _duration;
		public int Duration => _duration;

		[SerializeField] private GameObject[] _prefabs;
		public GameObject[] Prefabs => _prefabs;

		[SerializeField] private int _spawnCount;
		public int SpawnCount => _spawnCount;

	}
}