using UnityEngine;

namespace WhackTheMole.Scripts.Moles
{
    [CreateAssetMenu(menuName = "Mole")]
    public class MoleConfig : ScriptableObject
    {
        [field: SerializeField] public MoleView ViewPrefab { get; private set; }
        [field: Range(1,10)]
        [field: SerializeField] public int Health { get; private set; }
        [field: Range(1,10)]
        [field: SerializeField] public float Lifetime { get; private set; }
        [field: Range(1,100)]
        [field: SerializeField] public int Reward { get; private set; }
        [field: Range(1,10)]
        [field: SerializeField] public int Damage { get; private set; }

        public MoleData GetMoleData()
        {
            return new MoleData(ViewPrefab, Health, Lifetime, Reward, Damage);
        }
    }
}