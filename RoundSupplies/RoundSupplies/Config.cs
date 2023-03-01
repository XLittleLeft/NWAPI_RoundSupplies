using System.ComponentModel;

namespace RoundSupplies.RoundSupplies
{
    internal class Config
    {
        [Description("数量")]
        public ushort ItemNumber { get; set; } = 1;
        [Description("物品")]
        public ItemType ItemType { get; set; } = ItemType.KeycardJanitor;
    }
}
