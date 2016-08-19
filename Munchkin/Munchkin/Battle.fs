namespace Munchkin

open DomainTypes
open Player 

module Battle =
    
    let createBattle monster =
        { MonstersFighting = [monster]; PlayerBuffs = []; MonsterBuffs = [] }

    let addBuff buffCard toMonster battle =
        if toMonster then {battle with MonsterBuffs = buffCard :: battle.MonsterBuffs }
        else
        {battle with MonsterBuffs = buffCard :: battle.PlayerBuffs}

    let getPlayerTotalLevel battle state =
        battle.PlayerBuffs
        |>List.map (fun x -> x.Bonus)
        |>List.sum
        |> (+) (getPlayerLevel  state.CurrentPlayer)
