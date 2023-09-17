using UnityEngine;

namespace WhackTheMole.Scripts.Moles
{
    [CreateAssetMenu(menuName = "Mole")]
    public class MoleConfig : ScriptableObject
    {
        [field: SerializeField] public MoleView ViewPrefab { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public float Lifetime { get; private set; }
    }
}