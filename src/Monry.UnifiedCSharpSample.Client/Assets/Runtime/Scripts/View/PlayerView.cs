using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Cysharp.Threading.Tasks.Triggers;
using Monry.UnifiedCSharpSample.Model;
using UnityEngine;
using VContainer;

namespace Monry.Sample.Client.View
{
    public class PlayerView : MonoBehaviour
    {
        [Inject] public Player Player { get; set; }

        private void Awake()
        {
            this.GetAsyncCollisionEnter2DTrigger()
                .Subscribe(collision2D =>
                {
                    var collidable = collision2D.gameObject.GetComponent<IPlayerCollidable>();
                    if (collidable == default)
                    {
                        return;
                    }
                    collidable.OnCollide(Player);
                    Debug.Log($"HP: {Player.Hp}");
                })
                .AddTo(this.GetCancellationTokenOnDestroy());
        }

        private void Start()
        {
            Debug.Log($"Player: {Player.Name} Lv.{Player.Level}");
            Debug.Log($"HP: {Player.Hp}");
        }
    }
}
