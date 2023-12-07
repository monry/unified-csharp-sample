using Monry.UnifiedCSharpSample.Model;
using UnityEngine;

namespace Monry.Sample.Client.View
{
    public class PortionView : MonoBehaviour, IPlayerCollidable
    {
        public void OnCollide(Player player)
        {
            player.Hp += 10;
            Destroy(gameObject);
        }
    }
}
