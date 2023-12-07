using Monry.UnifiedCSharpSample.Model;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Monry.Sample.Client.View
{
    public class EnemyView : MonoBehaviour, IPlayerCollidable
    {
        [SerializeField] private int power = 5;
        private int Power => power;

        private void Awake()
        {
            power = Random.Range(1, 10);
        }

        public void OnCollide(Player player)
        {
            player.Hp -= Power;
            Destroy(gameObject);
        }
    }
}
