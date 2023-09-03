using UnityEngine;

namespace GFA.TPS.BoosterSystem
{
	public abstract class Booster : ScriptableObject
	{
		[SerializeField]
		private string _boosterName;
		public string BoosterName => _boosterName;
		
		[SerializeField]
		private string _description;
		public virtual string Description => _description;
        
		public abstract void OnAdded(BoosterContainer container);
	}
}
