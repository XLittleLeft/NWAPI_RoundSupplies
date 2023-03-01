using InventorySystem;
using MEC;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Core.Items;
using PluginAPI.Enums;
using PluginAPI.Events;
using System.Threading.Tasks;

namespace RoundSupplies.RoundSupplies
{
    internal class Plugin
    {
        [PluginEntryPoint("RoundSupplies","1.0.1","give something to class d when player spawn","X小左(XLittleLeft)")]
        void Enabled()
        {
            EventManager.RegisterEvents(this);
        }
        [PluginEvent(ServerEventType.PlayerSpawn)]
        void onPlayerSpawn(Player player,RoleTypeId roleTypeId)
        {
            Timing.CallDelayed(1f, () =>
            {
                if (player.Role is RoleTypeId.ClassD)
                {
                    for (int i = 0;i < Config.ItemNumber;i++)
                    {
                        player.AddItem(Config.ItemType);
                    }
                }
            });
        }

        [PluginConfig]
        public Config Config;

    }
}
