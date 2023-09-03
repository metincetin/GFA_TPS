using System;
using System.Collections.Generic;
using UnityEngine;

namespace GFA.TPS.BoosterSystem
{
    public class BoosterContainer : MonoBehaviour
    {
        private List<Booster> _boosters = new List<Booster>();
        
        public event Action<Booster> BoosterAdded;
        
        public void AddBooster(Booster booster)
        {
            _boosters.Add(booster);
            
            booster.OnAdded(this);
        }
    }
}
