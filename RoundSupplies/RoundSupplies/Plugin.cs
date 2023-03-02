using InventorySystem;
using MEC;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Core.Items;
using PluginAPI.Enums;
using PluginAPI.Events;
using System;
using System.Threading.Tasks;

namespace RoundSupplies.RoundSupplies
{
    internal class Plugin
    {
        Random Random = new Random();

        [PluginEntryPoint("RoundSupplies","1.0.2","give something to class d when player spawn","X小左(XLittleLeft)")]
        void Enabled()
        {
            EventManager.RegisterEvents(this);
        }
        [PluginEvent(ServerEventType.PlayerSpawn)]
        void onPlayerSpawn(Player player,RoleTypeId roleTypeId)
        {
            Timing.CallDelayed(1f, () =>
            {
                if (Config.RandomGive)
                {
                    if (player.Role is RoleTypeId.ClassD && Random.Next(5) < 2)
                    {
                        for (int i = 0; i < Config.ItemNumber; i++)
                        {
                            player.AddItem(Config.ItemType);
                        }
                    }
                }
                else
                {
                    if (player.Role is RoleTypeId.ClassD)
                    {
                        for (int i = 0; i < Config.ItemNumber; i++)
                        {
                            player.AddItem(Config.ItemType);
                        }
                    }
                }
            });
        }

        [PluginConfig]
        public Config Config;

    }
}
