using MEC;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace RoundSupplies.RoundSupplies
{
    internal class Plugin
    {
        [PluginEntryPoint("RoundSupplies","1.0","give something to class d when round start","X小左(XLittleLeft)")]
        void Enabled()
        {
            EventManager.RegisterEvents(this);
        }
        [PluginEvent(ServerEventType.PlayerSpawn)]
        void onPlayerSpawn(Player player,RoleTypeId roleTypeId)
        {
            Timing.CallDelayed(4f, () =>
            {
                if (roleTypeId.GetTeam() != Team.SCPs)
                {
                    switch (roleTypeId)
                    {
                        case RoleTypeId.ClassD:
                            player.AddAmmo(ItemType.KeycardJanitor, Config.ItemNumber);
                            player.AddAmmo(ItemType.Flashlight, Config.ItemNumber);
                            break;
                    }
                }
            });
        }


        [PluginConfig]
        public Config Config;

    }
}
