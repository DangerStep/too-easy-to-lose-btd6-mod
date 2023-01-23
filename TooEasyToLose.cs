using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using Il2CppAssets.Scripts.Unity;
using MelonLoader;
using TooEasyToLose;

[assembly: MelonInfo(typeof(TooEasyToLose.TooEasyToLose), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace TooEasyToLose;

public class TooEasyToLose : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<TooEasyToLose>("TooEasyToLose Gamemode loaded!");
    }
    public class AllRedBloons : ModRoundSet
    {
        public override string BaseRoundSet => RoundSetType.Default;
        public override int DefinedRounds => BaseRounds.Count;
        public override string DisplayName => "All Red Bloons";
        public override string Icon => VanillaSprites.Red;

        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            foreach (var group in roundModel.groups)
            {
                var bloon = Game.instance.model.GetBloon(group.bloon);
                if (bloon.FindChangedBloonId(bloonModel => bloonModel.isCamo = true, out var NotUsed))
                {
                    group.bloon = BloonType.Red;
                }
            }
            foreach (var group in roundModel.groups)
            {
                var bloon = Game.instance.model.GetBloon(group.bloon);
                if (bloon.FindChangedBloonId(bloonModel => bloonModel.isCamo = false, out var NotUsed))
                {
                    group.bloon = BloonType.Red;
                }
            }
            foreach (var group in roundModel.groups)
            {
                var bloon = Game.instance.model.GetBloon(group.bloon);
                if (bloon.FindChangedBloonId(bloonModel => bloonModel.isMoab = true, out var NotUsed))
                {
                    group.bloon = BloonType.Red;
                }
            }
            foreach (var group in roundModel.groups)
            {
                var bloon = Game.instance.model.GetBloon(group.bloon);
                if (bloon.FindChangedBloonId(bloonModel => bloonModel.isGrow = true, out var NotUsed))
                {
                    group.bloon = BloonType.Red;
                }
            }
            foreach (var group in roundModel.groups)
            {
                var bloon = Game.instance.model.GetBloon(group.bloon);
                if (bloon.FindChangedBloonId(bloonModel => bloonModel.isFortified = true, out var NotUsed))
                {
                    group.bloon = BloonType.Red;
                }
            }
        }
    }
    public class UWillWin : ModGameMode
    {
        public override string Difficulty => DifficultyType.Easy;
        public override string BaseGameMode => GameModeType.None;
        public override string DisplayName => "Too Easy To Lose";
        public override string Icon => VanillaSprites.Red;
        public override string Description => "I bet you can't lose on this game mode";
        public override void ModifyBaseGameModeModel(ModModel modgame)
        {
            modgame.UseRoundSet<AllRedBloons>();
            modgame.SetStartingCash(999999);
            modgame.SetStartingHealth(99999);
            modgame.SetSellMultiplier(999);
            modgame.SetEndingRound(10);
        }

    }
}