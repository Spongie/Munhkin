namespace Munchkin

open DomainTypes

module Battle =
    
    let createBattle monster =
        { MonstersFighting = [monster]; PlayerBuffs = []; MonsterBuffs = [] }

    let addBuff buffCard toMonster battle =
        if toMonster then {battle with MonsterBuffs = buffCard :: battle.MonsterBuffs }
        else
        {battle with MonsterBuffs = buffCard :: battle.PlayerBuffs}

